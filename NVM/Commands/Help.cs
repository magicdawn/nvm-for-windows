using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magicdawn;

namespace NVM.Commands
{
    class Help : Command
    {
        public Help()
        {
            this.Usage = "nvm help [command]";
            this.HelpMsg = I18n.Get.Help_HelpMessage;
        }

        public override void Execute(IEnumerable<string> args)
        {
            Console.Write("\nAnother『 ");
            ConsoleX.Write("Node Version Manager",ConsoleColor.Green);
            Console.WriteLine(" 』Tool for Windows ");

            Console.WriteLine();
            ConsoleX.WriteLine("Usage :",ConsoleColor.Cyan);

            var maxUsageLength = 0;
            Command.Commands.ForEach(c => {
                if(maxUsageLength < c.Usage.Length)
                {
                    maxUsageLength = c.Usage.Length;
                }
            });
            maxUsageLength += 4;
            Command.Commands.ForEach(c => {
                Console.Write("    "); // 4 spaces
                Console.Write(c.Usage.PadRight(maxUsageLength));
                Console.WriteLine(c.HelpMsg);
            });

            // Alias
            Console.WriteLine();
            ConsoleX.WriteLine("Command Alias :",ConsoleColor.Cyan);

            var maxKeyLength = 0;
            Command.AliasMap.ToList().ForEach(p => {
                if(p.Key.Length > maxKeyLength)
                {
                    maxKeyLength = p.Key.Length;
                }
            });
            Command.AliasMap.ToList().ForEach(p => {
                Console.Write("    "); // 4 spaces
                Console.Write(p.Key.PadRight(maxKeyLength));
                Console.Write(" -> ");
                Console.WriteLine(p.Value);
            });

            Console.WriteLine();
            ConsoleX.WriteLine("  BY Magicdawn<784876393@qq.com>",ConsoleColor.Yellow);
            ConsoleX.WriteLine("  Homepage : https://github.com/magicdawn/nvm-for-windows",ConsoleColor.Magenta);
        }
    }
}