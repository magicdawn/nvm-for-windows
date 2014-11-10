using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magicdawn;

namespace NVM.Commands
{
    public class Setup : Command
    {
        public Setup()
        {
            this.Usage = "nvm setup";
            this.HelpMsg = I18n.Get.Setup_HelpMsg;
        }

        public override void Execute(IEnumerable<string> args)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var path = System.Environment.GetEnvironmentVariable("PATH",EnvironmentVariableTarget.Machine);

            // nvm.exe
            if(path.EndsWith(dir,StringComparison.OrdinalIgnoreCase) ||
                path.IndexOf(dir + ";",StringComparison.OrdinalIgnoreCase) > -1)
            {
                ConsoleX.Warn(I18n.Get.NvmExeAlreadyInPath);
                return;
            }

            path += ";" + dir;
            System.Environment.SetEnvironmentVariable("PATH",path,EnvironmentVariableTarget.Machine);
            ConsoleX.Success(I18n.Get.SucceedAddNvmExeToPath);
        }
    }
}