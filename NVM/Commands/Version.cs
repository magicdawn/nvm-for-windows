using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magicdawn;

namespace NVM.Commands
{
    public class Version : Command
    {
        public Version()
        {
            this.Usage = "nvm version";
            this.HelpMsg = I18n.Get.Version_HelpMsg;
        }

        public override void Execute(IEnumerable<string> args)
        {
            Console.WriteLine();
            Console.WriteLine("nvm.exe version : {0}",Util.Version);
        }
    }
}
