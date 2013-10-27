using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XAFSkelbimaiPrograma.Parser.Helpers;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    class PluginFinn : IPlugin
    {

        public List<AdvertDto> Parse(string url)
        {
            string source = new SourceHelper().GetSource(url);
            List<string> parts = ParseToParts(source);
            return ParseToAdvertDtos(parts);
        }

        private List<AdvertDto> ParseToAdvertDtos(List<string> parts)
        {
            List<AdvertDto> adverts = new List<AdvertDto>();

            foreach (string part in parts)
            {
                AdvertDto advert = new AdvertDto();
                advert.Name = GetName(part);
                advert.UrlLink = GetLink(part);
                advert.Year = GetYear(part);
                advert.Price = GetPrice(part);
                //advert.Image = GetImage(part);

                adverts.Add(advert);

            }

            return adverts;
        }

        #region get functions

        private string GetName(string part)
        {
            string[] parts = Regex.Split(part, "<h2 data-automation-id=\"heading\"");
            parts = Regex.Split(parts[1], ">");
            string[] parts2 = Regex.Split(parts[2], "</a");
            return parts2[0].Trim();
        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "<a href=\"");
            string[] parts2 = Regex.Split(parts[1], "\"");
            return parts2[0].Trim();
        }

        private string GetYear(string part)
        {
            try
            {
                string[] parts = Regex.Split(part, "rsmodell");
                string[] parts2 = Regex.Split(parts[1], "&nbsp;");
                string[] parts3 = Regex.Split(parts2[0], "\">");
                return parts3[parts3.Length - 1].Trim().Replace("</div>", string.Empty);
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        private string GetPrice(string part)
        {
            try
            {
                string[] parts = Regex.Split(part, "Pris");
                string[] parts2 = Regex.Split(parts[1], "</div>");
                string[] parts3 = Regex.Split(parts2[1], "\">");
                return parts3[parts3.Length - 1].Replace("&nbsp;", string.Empty)
                    .Replace("\n", string.Empty).Trim().Replace("&#160;", string.Empty);

                //				return string.Empty;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion

        private List<string> ParseToParts(string source)
        {
            string[] parts = Regex.Split(source, "<div class=\"photoframe\">");
            List<string> result = new List<string>(parts);
            if (result.Count != 0)
                result.RemoveAt(0);
            return result;
        }

        public string UniqueCode
        {
            get { return "Finn.no"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://www.finn.no/finn/car/used/result?periode=1&sort=0"
                
            });
            }
        }
    }
}
