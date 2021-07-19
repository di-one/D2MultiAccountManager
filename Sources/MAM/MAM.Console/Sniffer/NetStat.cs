using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MAM.Console.Sniffer
{
    public static class NetStat
    {
        public static List<string> GetTCPServerIPs(Process d2Process)
        {
            Process pro = new Process();
            pro.StartInfo.FileName = "cmd.exe";
            pro.StartInfo.UseShellExecute = false;
            pro.StartInfo.RedirectStandardInput = true;
            pro.StartInfo.RedirectStandardOutput = true;
            pro.StartInfo.RedirectStandardError = true;
            pro.StartInfo.CreateNoWindow = true;
            pro.Start();
            pro.StandardInput.WriteLine("netstat -ano");
            pro.StandardInput.WriteLine("exit");
            Regex reg = new Regex("\\s+", RegexOptions.Compiled);
            string line = null;

            List<string> ips = new List<string>();

            while ((line = pro.StandardOutput.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.StartsWith("TCP", StringComparison.OrdinalIgnoreCase))
                {
                    line = reg.Replace(line, ",");
                    string[] arr = line.Split(',');
                    if (arr[4] == d2Process.Id.ToString())
                    {
                        string soc = arr[2];
                        string[] split = soc.Split(':');

                        string ipAndPort = split[0] + ":" + arr[1].Split(':')[1];
                        ips.Add(ipAndPort);
                    }
                }
            }

            pro.Close();
            return ips;
        }
    }
}
