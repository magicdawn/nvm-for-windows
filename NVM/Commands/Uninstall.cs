using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Magicdawn;

namespace NVM.Commands
{
    public class Uninstall : Command
    {
        public Uninstall()
        {
            this.Usage = "nvm uninstall <version>";
            this.HelpMsg = I18n.Get.Uninstall_HelpMsg;
        }

        public override void Execute(IEnumerable<string> args)
        {
            var ver = args.FirstOrDefault();
            if(string.IsNullOrWhiteSpace(ver))
            {
                Magicdawn.ConsoleX.Error(I18n.Get.MustSpecifyVersion);
                Console.WriteLine();
                Console.WriteLine("Usage : {0}",this.Usage);
                return;
            }

            // 卸载某一版本
            ver = Util.EnsureVer(ver);

            var dir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                ver
            );

            if(!Directory.Exists(dir))
            {
                ConsoleX.Warn(I18n.Get.NodeNotInstalled,ver);
                return;
            }

            Console.WriteLine("{1} node {0} ...",ver,I18n.Get.Uninstalling);
            Directory.Delete(dir,true);
            ConsoleX.Success("{1} node {0} ...",ver,I18n.Get.SucceedUninstalled);
        }
    }
}
