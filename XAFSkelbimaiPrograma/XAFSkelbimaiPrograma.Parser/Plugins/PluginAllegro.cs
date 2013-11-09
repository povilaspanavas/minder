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
    public class PluginAllegro : IPlugin
    {
        private UserParseInfoDto m_info = null;
        public const string IMG_PREFIX = "http://img18.allegroimg.pl/photos/128x96/";
        public List<AdvertDto> Parse(string url, UserParseInfoDto info)
        {
            m_info = info;
            string source = new SourceHelper().GetSource(url);
            List<string> parts = ParseToParts(source);
            return ParseToAdvertDtos(parts);
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
                //advert.Column4 = GetExpiry(part);
                advert.Year = GetYear(part);
                advert.Image = GetImage(part);

                result.Add(advert);
            }

            return result;
        }

        #region fields func
        private string GetName(string part)
        {
            string[] parts = Regex.Split(part, "<h2>");
            if (parts.Length <= 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "<span>");
            string[] parts3 = Regex.Split(parts2[1], "</span>");
            return parts3[0];
        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "<h2>");
            if (parts.Length <= 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "<a href=\"");
            string[] parts3 = Regex.Split(parts2[1], "\">");
            return "http://allegro.pl" + parts3[0];
        }

        private string GetPrice(string part)
        {
            string[] parts = Regex.Split(part, "buy-now dist\">");
            if (parts.Length <= 1)
                parts = Regex.Split(part, "price\">");
            string[] parts2 = Regex.Split(parts[1], "</span>");
            string[] parts3 = Regex.Split(parts2[1], "<span");
            return parts3[0].Trim();
        }

        //private string GetExpiry(string part)
        //{
        //    string[] parts = Regex.Split(part, "expiry\">");
        //    if (parts.Length <= 1)
        //        return string.Empty;
        //    string[] parts2 = Regex.Split(parts[1], ">");
        //    string[] parts3 = Regex.Split(parts2[1], "</strong");
        //    return parts3[0].Trim();
        //}

        private Image GetImage(string part)
        {
            if (m_info == null || m_info.Photo == false)
                return null;

            string[] parts = Regex.Split(part, IMG_PREFIX);
            if (parts.Length < 2)
                return null;
            string[] parts2 = Regex.Split(parts[1], "\"");
            if (parts2.Length < 2)
                return null;
            return new SourceHelper().GetImage(IMG_PREFIX + parts2[0]);
        }

        private string GetYear(string part)
        {
            string[] parts = Regex.Split(part, "Rok produkcji");
            if (parts.Length <= 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "</span></dd>");
            string result = parts2[0].Replace("</span></dt><dd><span>", string.Empty);
            return result.Trim();
        }

        #endregion

        private List<string> ParseToParts(string source)
        {
            List<string> parts = Regex.Split(source, "<article id=\"").ToList();
            if (parts.Count > 0)
                parts.RemoveAt(0);

            return parts;
        }

        public string UniqueCode
        {
            get { return "Allegro.pl"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
                {
                    "http://allegro.pl/listing/listing.php?category=1454&sg=0&order=qd&string=Zara&change_view=1",
                    "http://allegro.pl/ogrod-meble-ogrodowe-82256?order=qd&string=",
                    "http://allegro.pl/samochody-149?a_text_i%5B1%5D%5B0%5D=2008&a_text_i%5B1%5D%5B1%5D=2010&a_text_i%5B4%5D%5B0%5D=&a_text_i%5B4%5D%5B1%5D=&a_text_i%5B5%5D%5B0%5D=&a_text_i%5B5%5D%5B1%5D=&a_text_i_enabled%5B1%5D%5B0%5D=1&a_text_i_enabled%5B1%5D%5B1%5D=1&change_view=Poka%C5%BC%C2%A0%3E&distance=1&limit=180&listing=1&offerTypeAdvert=0&offerTypeAuction=0&offerTypeBuyNow=0&order=p&price_enabled=1&price_from=5000&price_to=30000&startingTime=1&startingTime_enabled=1&state=0"
                }
                    );
            }
        }
    }
}
