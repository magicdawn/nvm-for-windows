using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NVM.Languages
{
    public class English : I18n
    {
        public English()
        {
            // HelpMsg
            this.Help_HelpMessage = "show this message";
            this.Install_HelpMessage = "install node@version";
            this.Uninstall_HelpMsg = "uninstall node@version";
            this.Use_HelpMsg = "switch to node@version";
            this.List_HelpMsg = "list all installed versions";

            this.Setup_HelpMsg = "add nvm.exe to PATH environment variable";
            this.Unsetup_HelpMsg = "remove nvm.exe from PATH environment variable";

            // install
            this.MustSpecifyVersion = "must specify a version !";
            this.DirAlreadyExistsAndContinue = "directory already exists,continue";
            this.Downloading = "downloading";
            this.DownloadFailed = "download failed , please check Network and the version argument";
            this.DownloadSucceed = "downlod complete";
            this.InstalledSucceed = "installed complete";
            this.UseUseToSwitch = "  use `nvm use <ver>` switch to {0}";

            // list
            this.InstalledVersions = "Installed Versions :";

            // setup
            this.NvmExeAlreadyInPath = "nvm.exe already in the PATH variable !";
            this.SucceedAddNvmExeToPath = "nvm.exe has been add to the PATH variable";

            // uninstall
            this.NodeNotInstalled = "node {0} is not installed , no need to unistall !";
            this.Uninstalling = "uninstalling";
            this.SucceedUninstalled = "success to uninstall";

            // unsetup
            this.SucceedRemoveNvmExeFromPath = "nvm.exe has been removed from the PATH variable";

            // use
            this.Use_NodeNotInstalled = "node {0} not installed !";
            this.UsingThisVersion_NoNeedToSwitch = "using node {0} , no need to switch !";
            this.SucceedSwitchingVersion = "switched to node {0}";

            this.NoCommandFound = "command not supported !";
        }
    }
}
