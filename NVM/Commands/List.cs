using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Magicdawn;

namespace NVM.Commands
{
    public class List : Command
    {
        public List()
        {
            this.Usage = "nvm list";
            this.HelpMsg = I18n.Get.List_HelpMsg;
        }

        public override void Execute(IEnumerable<string> args)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var curVer = Util.GetCurrentVer();

            var q = from d in Directory.GetDirectories(dir,"v*")
                    select Path.GetFileName(d);

            Console.WriteLine(I18n.Get.InstalledVersions);
            Console.WriteLine();
            foreach(var d in q)
            {
                if(d == curVer)
                {
                    ConsoleX.WriteLine(" * " + d,ConsoleColor.Yellow);
                    continue;
                }
                Console.WriteLine("   " + d);
            }
        }
    }
}
