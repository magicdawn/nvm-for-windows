using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVM.Languages
{
    public class SimplifiedChinese : I18n
    {
        public SimplifiedChinese()
        {
            // HelpMsg
            this.Help_HelpMessage = "查看此帮助信息";
            this.Install_HelpMessage = "安装某一版本node";
            this.Uninstall_HelpMsg = "卸载某一版本node";
            this.Use_HelpMsg = "切换至某一版本node";
            this.List_HelpMsg = "查看所有已安装的版本";

            this.Setup_HelpMsg = "将 nvm.exe 添加至PATH环境变量";
            this.Unsetup_HelpMsg = "将 nvm.exe 从PATH环境变量中移除";

            // install
            this.MustSpecifyVersion = "必须指定版本 !";
            this.DirAlreadyExistsAndContinue = "文件夹已经存在,继续下载";
            this.Downloading = "正在下载";
            this.DownloadFailed = "下载失败 , 请检查 网络 & 版本号 是否存在";
            this.DownloadSucceed = "下载成功";
            this.InstalledSucceed = "安装成功";
            this.UseUseToSwitch = "  使用 `nvm use <ver>` 切换到 {0}";
            this.Version_HelpMsg = "查看nvm.exe 版本号";

            // list
            this.InstalledVersions = "已安装版本 :";

            // setup
            this.NvmExeAlreadyInPath = "nvm.exe 已经在PATH环境变量中 !";
            this.SucceedAddNvmExeToPath = "nvm.exe 成功添加至PATH环境变量";

            // uninstall
            this.NodeNotInstalled = "还未安装 node {0} , 无需卸载 !";
            this.Uninstalling = "正在卸载";
            this.SucceedUninstalled = "成功卸载";

            // unsetup
            this.SucceedRemoveNvmExeFromPath = "成功将 nvm.exe 从PATH去除";

            // use
            this.Use_NodeNotInstalled = "还未安装 node {0}";
            this.UsingThisVersion_NoNeedToSwitch = "正在使用 node {0} , 不用切换版本";
            this.SucceedSwitchingVersion = "成功切换到 node {0}";

            this.NoCommandFound = "未识别命令";
        }
    }
}
