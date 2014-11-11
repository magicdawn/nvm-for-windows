using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace NVM
{
    public class Util
    {
        // change version here
        public const string Version = "0.0.2";

        // delegate PATH actions to `Util.Path` property
        public static string Path
        {
            get
            {
                return Environment.GetEnvironmentVariable("PATH",EnvironmentVariableTarget.Machine);
            }
            set
            {
                Environment.SetEnvironmentVariable("PATH",value,EnvironmentVariableTarget.Machine);
            }
        }

        public static string EnsureVer(string ver)
        {
            if(ver[0] != 'v')
            {
                if(ver[0] == 'V')
                {
                    ver = ver.ToLower();
                }
                else
                {
                    ver = "v" + ver;
                }
            }

            return ver;
        }

        public static string GetCurrentVer()
        {
            var path = Environment.GetEnvironmentVariable("PATH",EnvironmentVariableTarget.Machine);
            var dir = AppDomain.CurrentDomain.BaseDirectory; // ends with \

            foreach(var p in path.Split(';'))
            {
                if(p.StartsWith(dir + "v",StringComparison.OrdinalIgnoreCase)) // /v0.10.33/node.exe
                {
                    var ver = p.Substring(dir.Length); // v0.10.33
                    if(!string.IsNullOrWhiteSpace(ver))
                    {
                        return ver;
                    }
                }
            }

            return null;
        }
    }
}
