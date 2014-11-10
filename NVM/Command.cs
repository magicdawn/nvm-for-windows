using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVM
{
    public abstract class Command
    {
        #region static member
        public static List<Command> Commands = new List<Command>(); // all commands
        static Command()
        {
            // Commands field
            var query = from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                        where t.Namespace == "NVM.Commands" && t.BaseType == typeof(Command)
                        select Activator.CreateInstance(t) as Command;
            Commands.AddRange(query);
        }

        // command alias map
        public static Dictionary<string,string> AliasMap = new Dictionary<string,string>() { 
            { "i","install" },
            { "un" ,"uninstall"},
            { "ls","list" }
        };

        // dispatch command
        public static Command GetCommand(string[] args)
        {
            string cmd;
            if(args.Length < 1) // just run `nvm`
            {
                cmd = "help";
            }
            else
            {
                cmd = args[0]; // `nvm i`
                while(AliasMap.ContainsKey(cmd)) // i -> install
                {
                    cmd = AliasMap[cmd]; // cmd = AliasMap[i] = install
                }
            }

            foreach(var c in Commands)
            {
                if(c.GetName().Trim().ToLowerInvariant() == cmd)
                {
                    return c;
                }
            }

            return null; // no command match
        }
        #endregion

        #region Command Class Member
        public string Usage; // 使用说明
        public string HelpMsg; // 帮助信息
        public virtual string GetName() // 默认 当前类型 , 小写
        {
            return this.GetType().Name.ToLowerInvariant();
        }
        public abstract void Execute(IEnumerable<string> args); // execute this command 
        #endregion
    }
}