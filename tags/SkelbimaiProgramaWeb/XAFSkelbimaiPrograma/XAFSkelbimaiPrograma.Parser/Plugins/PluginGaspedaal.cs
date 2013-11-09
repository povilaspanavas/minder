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
    class PluginGaspedaal : IPlugin
    {
        private UserParseInfoDto m_info;
        public const string IMG_PREFIX = "http://www.gaspedaal.nl/";
        public List<AdvertDto> Parse(string url, UserParseInfoDto info)
        {
            m_info = info;
            string source = new SourceHelper().GetSource(url);
            List<string> parts = ParseToParts(source);
            return ParseToAdvertDtos(parts);
        }

        private List<string> ParseToParts(string source)
        {
            List<string> parts = Regex.Split(source, "occLijst").ToList();
            if (parts.Count != 0)
                parts.RemoveAt(0);
            else
                parts = new List<string>();
            if (parts.Count != 0)
                parts.RemoveAt(0);

            return parts;
        }

        private List<AdvertDto> ParseToAdvertDtos(List<string> parts)
        {
            List<AdvertDto> result = new List<AdvertDto>();

            foreach (string part in parts)
            {
                AdvertDto advert = new AdvertDto();
                advert.Name = GetName(part);
                advert.UrlLink = GetLink(part);
                advert.Price = GetPrice(part);
                advert.Year = GetYear(part);
                advert.Image = GetImage(part);

                result.Add(advert);
            }

            return result;
        }
        #region get functions
        private string GetName(string part)
        {
            string[] parts = Regex.Split(part, "</b></a>");
            string[] parts2 = Regex.Split(parts[0], "<b>");
            string result = parts2[parts2.Length - 1];
            return result;
        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "<a href=\"");
            string[] parts2 = Regex.Split(parts[1], "\"");
            string result = parts2[0];
            return result;
        }

        private string GetPrice(string part)
        {
            string[] parts = Regex.Split(part, "kr prijs\"><b>");
            if (parts.Length == 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "</b>");
            string result = parts2[0].Replace("&euro;", string.Empty);
            return result;
        }

        private string GetYear(string part)
        {
            string[] parts = Regex.Split(part, "kr prijs\"><b>");
            string[] parts2 = Regex.Split(parts[0], "\"kr\">");
            string[] parts3 = Regex.Split(parts2[parts2.Length - 1], "</div>");
            string result = parts3[0];
            return result;
        }

        private Image GetImage(string part)
        {
                if (m_info == null || m_info.Photo == false)
                    return null;

                part = part.Replace("[", string.Empty);
                string[] parts = Regex.Split(part, "\"foto\":\"");
                if (parts.Length == 1)
                    return null;
                string[] parts2 = Regex.Split(parts[1], "\"");
                if (parts2.Length == 1)
                    return null;
                parts2[0] = parts2[0].Replace("\\", string.Empty);
                if (parts2[0].Contains("http://") || parts2[0].Contains("https://"))
                    parts2[0].Replace("w=640&h=480", "w=160&h=120");
                else
                    parts2[0] = IMG_PREFIX + parts2[0];
                return new SourceHelper().GetImage(parts2[0]);
        }
        #endregion


        public string UniqueCode
        {
            get { return "Gaspedaal.nl"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://www.gaspedaal.nl/BMW/3-serie/?srt=bj",
                "http://www.gaspedaal.nl/Audi/?srt=pr&uz=1"
            });
            }
        }
    }
}
