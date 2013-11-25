using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace XAFSkelbimaiPrograma.Parser.Helpers
{
    public class SourceHelper
    {
        private List<string> m_proxies;

        public string GetSource(string link) //TODO Need implement proxy
        {
            WebClient webClient = new WebClient();
            //webClient.Headers["Accept-Language"] = "lt-LT";
            string source = webClient.DownloadString(link);
            webClient.Dispose();
            return source;
        }

        public string GetSourceByProxy(string link)
        {
            int tryCount = 3;

            while (tryCount != 0)
            {
                try
                {
                    InitProxyList();
                    WebClient client = new WebClient();
                    WebProxy wp = new WebProxy(GetRandomProxy());
                    client.Proxy = wp;
                    string str = client.DownloadString(link);
                    client.Dispose();
                    return str;
                }
                catch (Exception)
                {
                    tryCount--;
                }
                
            }
            throw new Exception("Not work proxy IP");
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

        private string GetRandomProxy()
        {
            lock (m_proxies)
            {
                int start = 0;
                int end = m_proxies.Count - 1;
                int ticks = (int)DateTime.Now.Ticks;
                Random random = new Random(ticks);
                int randomInt = random.Next(start, end);
                return m_proxies[randomInt];
            }
        }

        private void InitProxyList()
        {
            if (m_proxies != null)
                return;

            m_proxies = new List<string>();
            lock (m_proxies)
            {
                string[] proxiesFromFile = File.ReadAllLines("ProxyList.txt");
                m_proxies.AddRange(proxiesFromFile);
            }
        }

    }
}
