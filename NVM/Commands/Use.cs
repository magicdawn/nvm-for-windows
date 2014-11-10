using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Magicdawn;

namespace NVM.Commands
{
    public class Use : Command
    {
        public Use()
        {
            this.Usage = "nvm use <version>";
            this.HelpMsg = I18n.Get.Use_HelpMsg;
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

            ver = Util.EnsureVer(ver);

            var dir = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                ver
            );

            if(!Directory.Exists(dir))
            {
                ConsoleX.Warn(I18n.Get.Use_NodeNotInstalled,ver);
                return;
            }

            // use 某一版本
            var path = Environment.GetEnvironmentVariable("PATH",EnvironmentVariableTarget.Machine);
            var pattern = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\",@"\\") + @"(v[\d.]+)";
            var m = Regex.Match(path,pattern);

            if(m != null && m.Groups[1].Value == ver) // don't need to switch
            {
                ConsoleX.Warn(I18n.Get.UsingThisVersion_NoNeedToSwitch,ver);
                return;
            }

            // 切换至ver
            if(m == null) // 不包含 node.exe 目录
            {
                path = dir + ";" + path; // 将 dir append至path
            }
            else // 已经包含,替换
            {
                path = path.Replace(m.Value,dir);
            }
            Environment.SetEnvironmentVariable("PATH",path,EnvironmentVariableTarget.Machine);
            ConsoleX.Success(I18n.Get.SucceedSwitchingVersion,ver);
        }
    }
}
