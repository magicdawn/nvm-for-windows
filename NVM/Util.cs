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
            var pattern = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\",@"\\") + @"(v[\d.]+)";
            var m = Regex.Match(path,pattern);

            if(m == null)
            {
                return null;
            }

            return m.Groups[1].Value;
        }
    }    
}
