using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVM
{
    public abstract class I18n
    {
        static I18n()
        {
            var code = System.Globalization.CultureInfo.CurrentUICulture.Name;

            if(code == "zh-CN") // zh-CN 系统中文,显示中文
            {
                Get = new Languages.SimplifiedChinese();
            }
            else
            {
                Get = new Languages.English();
            }
        }
        public static I18n Get;

        #region 字段
        public string Help_HelpMessage; // 帮助命令 的帮助信息
        public string Install_HelpMessage;
        public string List_HelpMsg;
        public string Setup_HelpMsg;
        public string Uninstall_HelpMsg;
        public string Unsetup_HelpMsg;
        public string Use_HelpMsg;

        // install
        public string MustSpecifyVersion;
        public string DirAlreadyExistsAndContinue;
        public string Downloading;
        public string DownloadFailed;
        public string DownloadSucceed;
        public string InstalledSucceed;
        public string UseUseToSwitch;

        // list
        public string InstalledVersions;

        // setup
        public string NvmExeAlreadyInPath;
        public string SucceedAddNvmExeToPath;

        // uninstall
        public string NodeNotInstalled;
        public string Uninstalling;
        public string SucceedUninstalled;

        // unsetup
        public string SucceedRemoveNvmExeFromPath;

        // use
        public string Use_NodeNotInstalled;
        public string UsingThisVersion_NoNeedToSwitch;
        public string SucceedSwitchingVersion;


        public string NoCommandFound; // 未识别命令
        #endregion
    }
}
