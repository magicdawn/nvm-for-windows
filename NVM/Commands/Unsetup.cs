using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVM.Commands
{
    public class Unsetup : Command
    {
        public Unsetup()
        {
            this.Usage = "nvm unsetup";
            this.HelpMsg = I18n.Get.Unsetup_HelpMsg;
        }

        public override void Execute(IEnumerable<string> args)
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            var path = Environment.GetEnvironmentVariable("PATH",EnvironmentVariableTarget.Machine);

            var q = from p in path.Split(';')
                    where !dir.Equals(p,StringComparison.OrdinalIgnoreCase) // 取出 这个nvm.exe 所在dir
                    select p;

            path = string.Join(";",q);
            Environment.SetEnvironmentVariable("PATH",path,EnvironmentVariableTarget.Machine);
            Magicdawn.ConsoleX.Success(I18n.Get.SucceedRemoveNvmExeFromPath);
        }
    }
}
