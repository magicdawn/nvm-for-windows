using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace NVM.Commands
{
    class Install : Command
    {
        public Install()
        {
            this.Usage = "nvm install <version>";
            this.HelpMsg = I18n.Get.Install_HelpMessage;
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

            // ensure version include `v`
            // `nvm i v0.10.32`
            // `nvm i 0.10.32`
            ver = Util.EnsureVer(ver);

            // check directory exists
            var dir = Path.Combine(
                System.AppDomain.CurrentDomain.BaseDirectory,
                ver
            );

            if(Directory.Exists(dir))
            {
                Magicdawn.ConsoleX.Write(I18n.Get.DirAlreadyExistsAndContinue +
                    "<y/n> ",ConsoleColor.Yellow);
                var answer = Console.ReadLine().ToLowerInvariant();
                if(!(answer == "y" || answer == "yes")) // when answer = yes || y , continue
                {
                    return;
                }
            }
            else
            {
                Directory.CreateDirectory(dir);
            }

            string node_exe_file = Path.Combine(dir,"node.exe"); // local file node.exe path

            // decide the node.exe url
            string node_exe_url;
            if(System.Environment.Is64BitOperatingSystem)
            {
                node_exe_url = "http://nodejs.org/dist/{0}/x64/node.exe".format(ver);
            }
            else
            {
                node_exe_url = "http://nodejs.org/dist/{0}/node.exe".format(ver);
            }

            // begin download
            var client = new WebClient();
            Console.WriteLine(I18n.Get.Downloading + " node {0} ...",ver);
            if(!Magicdawn.WebClientHelper.TryDownload(client,node_exe_url,node_exe_file)) // try 5 times
            {
                // fail
                Magicdawn.ConsoleX.Error("node {0} {1} !",ver,I18n.Get.DownloadFailed);
                return;
            }

            // success
            Magicdawn.ConsoleX.Success("node {0} {1} !",ver,I18n.Get.DownloadSucceed);
            Console.WriteLine("  url : {0}",node_exe_url);
            Console.WriteLine("  file : {0}",node_exe_file);

            // npm
            // decide nmp version
            // https://raw.githubusercontent.com/joyent/node/v0.11.14/deps/npm/package.json
            var json = client.DownloadString("https://raw.githubusercontent.com/joyent/node/{0}/deps/npm/package.json".format(ver));
            var npm_ver = Regex.Match(json,@"""version"": *""([\d.]+)""").Groups[1].Value;

            // download npm zip file
            var npm_zip_file = Path.Combine(dir,"npm-v{0}.zip".format(npm_ver));
            var npm_zip_url = "https://github.com/npm/npm/archive/v{0}.zip".format(npm_ver);
            Console.WriteLine(I18n.Get.Downloading + " npm-v{0}.zip ...",npm_ver);
            if(!Magicdawn.WebClientHelper.TryDownload(client,npm_zip_url,npm_zip_file))
            {
                // fail
                Magicdawn.ConsoleX.Error("npm-v{0}.zip {1} !",npm_ver,I18n.Get.DownloadFailed);
                return;
            }
            Magicdawn.ConsoleX.Success("npm-v{0}.zip {1}",npm_ver,I18n.Get.DownloadSucceed);

            // unzip
            using(var zip = Ionic.Zip.ZipFile.Read(npm_zip_file))
            {
                // 放至 node_modules/npm
                // zip文件结构
                // npm-1.2.3.zip
                //   npm-1.2.3/
                //     cli.js
                //     package.json


                var target = Path.Combine(dir,"node_modules");
                zip.ExtractAll(target);

                // 重命名文件夹
                var npm_vxx_dir_name = zip[0].FileName;
                var old = Path.Combine(target,npm_vxx_dir_name);
                var newDir = Path.Combine(target,"npm");
                Directory.Move(old,newDir);

                // 复制bin
                File.Copy(dir + @"\node_modules\npm\bin\npm",dir + @"\npm");
                File.Copy(dir + @"\node_modules\npm\bin\npm.cmd",dir + @"\npm.cmd");
            }

            Magicdawn.ConsoleX.Success("npm v{0} {1}",npm_ver,I18n.Get.InstalledSucceed);

            Console.WriteLine();
            Console.WriteLine(I18n.Get.UseUseToSwitch,ver);
        }
    }
}
