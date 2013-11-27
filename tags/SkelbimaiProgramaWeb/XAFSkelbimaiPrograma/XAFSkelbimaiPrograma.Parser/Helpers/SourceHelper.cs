using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace XAFSkelbimaiPrograma.Parser.Helpers
{
    public class SourceHelper
    {
        private List<string> m_vpnList;

        public string GetSource(string link) //TODO Need implement proxy
        {
            WebClient webClient = new WebClient();
            //webClient.Headers["Accept-Language"] = "lt-LT";
            string source = webClient.DownloadString(link);
            webClient.Dispose();
            return source;
        }

        [Obsolete("Reikia ant normalaus proxio pakabinti")]
        public string GetSourceViaVpn(string link)
        {
            //Connect
            InitVpnList();
            lock (m_vpnList)
            {
                Process.Start("rasdial.exe", m_vpnList[0]);
                try
                {
                    string[] parts = Regex.Split(m_vpnList[0], " ");
                    Process.Start("rasdial.exe", parts[0] + " /d");
                    parts = Regex.Split(m_vpnList[1], " ");
                    Process.Start("rasdial.exe", parts[0] + " /d");
                    parts = Regex.Split(m_vpnList[0], " ");

                    WebClient webClient = new WebClient();
                    string source = webClient.DownloadString(link);
                    webClient.Dispose();

                    Process.Start("rasdial.exe", parts[0] + " /d");
                    return source;
                }
                catch
                {
                    string[] parts = Regex.Split(m_vpnList[0], " ");
                    Process.Start("rasdial.exe", parts[0] + " /d");
                    Process.Start("rasdial.exe", m_vpnList[1]);

                    WebClient webClient = new WebClient();
                    //webClient.Headers["Accept-Language"] = "lt-LT";
                    string source = webClient.DownloadString(link);
                    webClient.Dispose();
                    parts = Regex.Split(m_vpnList[1], " ");
                    Process.Start("rasdial.exe", parts[0] + " /d");
                    return source;
                }
            }
           
        }

        public Image GetImage(string link)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(link);
            MemoryStream ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);
            return img;
        }

        //Privates ------------------------------------------------------

        private void InitVpnList()
        {
            if (m_vpnList != null)
                return;

            m_vpnList = new List<string>();
            lock (m_vpnList)
            {
                string[] proxiesFromFile = File.ReadAllLines("VpnList.txt");
                m_vpnList.AddRange(proxiesFromFile);
            }
        }

    }
}
