using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVM
{
    class Program
    {
        static void Main(string[] args)
        {
            // mock
            // args = new string[] { "help" };

            var cmd = Command.GetCommand(args);

            if(cmd == null)
            {
                Magicdawn.ConsoleX.Error(I18n.Get.NoCommandFound,args[0]);
                return;
            }

            cmd.Execute(args.Skip(1));

            //Console.ReadKey();
        }
    }
}