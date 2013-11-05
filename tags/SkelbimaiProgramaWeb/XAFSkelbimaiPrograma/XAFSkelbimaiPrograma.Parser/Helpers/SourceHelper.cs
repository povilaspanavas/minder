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
        public string GetSource(string link) //TODO Need implement proxy
        {
            WebClient webClient = new WebClient();
            webClient.Headers["Accept-Language"] = "lt-LT";
            string source = webClient.DownloadString(link);
            webClient.Dispose();
            return source;
        }

        public Image GetImage(string link)
        {
            WebClient wc = new WebClient();
            byte[] bytes = wc.DownloadData(link);
            MemoryStream ms = new MemoryStream(bytes);
            Image img = Image.FromStream(ms);
            return img;
        }

    }
}
