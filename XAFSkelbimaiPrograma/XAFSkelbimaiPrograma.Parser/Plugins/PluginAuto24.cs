using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XAFSkelbimaiPrograma.Parser.Helpers;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    public class PluginAuto24 : IPlugin
    {
        private UserParseInfoDto m_info = null;

        public List<AdvertDto> Parse(string url, UserParseInfoDto info)
        {
            m_info = info;
            string source = new SourceHelper().GetSource(url);
            return ParseSource(source);
        }

        private List<AdvertDto> ParseSource(string source)
        {
            List<string> parts = SplitToParts(source);
            List<AdvertDto> result = new List<AdvertDto>();

            foreach (string part in parts)
            {
                if (part.IndexOf("SEB Liising") != -1)
                    continue;

                AdvertDto advert = new AdvertDto();
                advert.Name = GetName(part);
                advert.Image = GetImage(part);
                advert.Year = GetYear(part);
                advert.Price = GetPrice(part);
                advert.UrlLink = GetLink(part);
                
                result.Add(advert);
            }


            return result;
        }

        private string GetName(string part)
        {
            string[] parts = Regex.Split(part, "<a href=\\\"");
            string[] parts2 = Regex.Split(parts[1], "\">");
            string[] parts3 = Regex.Split(parts2[1], "</a>");

            return parts3[0].Trim();
        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "<a href=\\\"");
            string[] parts2 = Regex.Split(parts[1], "\">");

            return string.Format("http://www.auto24.ee{0}", parts2[0].Trim());
        }

        private string GetPrice(string part)
        {
            string[] parts = Regex.Split(part, "class=\"price\">");
            if (parts.Length < 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "</td>");

            string result = string.Empty;

            foreach (char r in parts2[0].Trim())
            {
                try
                {
                    int tempInt = Convert.ToInt32(r.ToString());
                    result += r.ToString();
                }
                catch
                {
                }

            }

            return result;
        }

        private string GetYear(string part)
        {
            try
            {
                string[] parts = Regex.Split(part, "class=\"year\">");
                if (parts.Length < 1)
                    return string.Empty;
                string[] parts2 = Regex.Split(parts[1], "</td>");

                return parts2[0];
            }
            catch (Exception)
            {

                throw;
            }

        }

        private Image GetImage(string part)
        {
            if (m_info == null || m_info.Photo == false)
                return null;

            string[] parts = Regex.Split(part, "<img src=\"");
            if (parts.Length < 2)
                return null;
            string[] parts2 = Regex.Split(parts[1], "\"");
            if (parts2.Length < 2)
                return null;
            return new SourceHelper().GetImage(parts2[0]);
        }

        //[Obsolete("Neaišku kas čia ir ar išvis reikia")]
        //private string GetFuelType(string part)
        //{
        //    string[] parts = Regex.Split(part, "class=\"fuel\">");
        //    if (parts.Length < 1)
        //        return string.Empty;
        //    string[] parts2 = Regex.Split(parts[1], "</td>");

        //    return parts2[0];
        //}

        private List<string> SplitToParts(string source)
        {
            string[] parts = Regex.Split(source, "block");
            List<string> result = new List<string>(parts);
            result.RemoveAt(0);
            result.RemoveAt(0);
            return result;
        }


        public string UniqueCode
        {
            get { return "Auto24.ee"; }
        }

        public List<string> TestLinks
        {
            get { return new List<string>(new string[] 
            {
                "http://www.auto24.ee/kasutatud/nimekiri.php?bn=2&bi=EUR&ab=0&ae=2&af=50&ag=1&otsi=otsi",
                "http://rus.auto24.ee/kasutatud/nimekiri.php?bn=2&a=100&aj=&a=0&j=0&b=1&bw=165&c=&b2=0&bw2=0&c2=&b3=0&bw3=0&c3=&f1=1998&f2=&g1=&g2=&bi=EUR&k1=&k2=&l1=&l2=&h=0&i=0&p=0&m=0&n=0&ab=0&ac=0&ad=0&ae=2&af=50&by=0&ag=0&ag=1&otsi=%D0%BF%D0%BE%D0%B8%D1%81%D0%BA",
                "http://rus.auto24.ee/kasutatud/nimekiri.php?bn=2&a=100&aj=&a=0&j=0&b=0&bw=0&c=&b2=0&bw2=0&c2=&b3=0&bw3=0&c3=&f1=2001&f2=&g1=&g2=&bi=EUR&k1=&k2=&l1=&l2=&h=0&i=0&p=0&m=0&n=0&ab=0&ac=0&ad=1&ae=2&af=50&by=0&ag=0&ag=1&otsi=%D0%BF%D0%BE%D0%B8%D1%81%D0%BA"
            }); }
        }
    }
}
