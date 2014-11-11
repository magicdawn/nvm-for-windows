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

            // 是否是相同版本
            var currentVersion = Util.GetCurrentVer();
            if(ver == currentVersion) // don't need to switch
            {
                ConsoleX.Warn(I18n.Get.UsingThisVersion_NoNeedToSwitch,ver);
                return;
            }

            // use 某一版本
            var path = Util.Path;
            var root = AppDomain.CurrentDomain.BaseDirectory;

            if(currentVersion != null) // 包含一个版本
            {
                var paths = path.Split(';');
                for(int i = 0;i < path.Length;i++)
                {
                    if(paths[i].StartsWith(root + "v"))
                    {
                        paths[i] = dir; // path[i] 原来 version , dir new version , 替换掉
                        break;
                    }
                }
                path = string.Join(";",paths);
            }
            else // 不包含,直接append
            { 
                path = dir + ";" + path; // 将 dir append至path
            }

            Util.Path = path; // 设置PATH
            ConsoleX.Success(I18n.Get.SucceedSwitchingVersion,ver);
        }
    }
}
