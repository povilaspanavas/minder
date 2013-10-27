using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XAFSkelbimaiPrograma.Parser.Helpers;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    class PluginSkelbiu : IPlugin
    {
        
        public List<AdvertDto> Parse(string url)
        {
            string source = new SourceHelper().GetSource(url);
            List<string> parts = ParseToParts(source);
            return ParseToAdvertDtos(parts);
        }

        private List<AdvertDto> ParseToAdvertDtos(List<string> parts)
        {
            List<AdvertDto> result = new List<AdvertDto>();

            foreach (string part in parts)
            {
                if (part.IndexOf("passivatedAdURL") != -1) //Parduotas
                    continue;

                AdvertDto advert = new AdvertDto();
                advert.Name = GetName(part);
                advert.UrlLink = GetLink(part);
                //advert.Column3 = GetDate(part);
                advert.Price = GetPrice(part);

                result.Add(advert);
            }

            return result;
        }

        private string GetName(string part)
        {
            string[] parts = Regex.Split(part, ".html\"");
            string[] parts2 = Regex.Split(parts[1], "</a>");
            string result = parts2[0].Replace(">", string.Empty).Trim();
            result = Regex.Replace(result, "</em", string.Empty); //Čia tagai būna, kai dar papildomai ieškoma langelyje
            result = Regex.Replace(result, "<em", string.Empty);
            return result;
        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "<a href=\\\"");
            string[] parts2 = Regex.Split(parts[1], "\\\" >");
            return "http://skelbiu.lt" + parts2[0];
        }

        private string GetDate(string part)
        {
            try
            {
                string[] parts = Regex.Split(part, "adsDate\\\">");
                string[] parts2 = Regex.Split(parts[1], "</div>");
                return parts2[0].Trim();
            }
            catch
            {
                return "Nepavyko nustatyti";
            }

        }

        private string GetPrice(string part)
        {
            try
            {
                string[] parts = Regex.Split(part, "adsPrice\">");
                if (parts.Length == 1)
                    return string.Empty;
                string[] parts2 = Regex.Split(parts[1], "</div>");
                string result = Regex.Replace(parts2[0], "\t", string.Empty);
                result = Regex.Replace(result, "\n", string.Empty);
                result = Regex.Replace(result, "\r", string.Empty);
                result = result.Trim();

                if (result.Equals("&nbsp;"))
                    return "Nenurodyta";

                return result;
            }
            catch
            {
                return string.Empty;
            }

        }

        private List<string> ParseToParts(string source)
        {
            string[] parts = Regex.Split(source, "class=\"adsImage\">");
            List<string> result = new List<string>(parts);
            result.RemoveAt(0);
            return result;
        }

        public string UniqueCode
        {
            get { return "Skelbiu.lt"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://www.skelbiu.lt/skelbimai/?cities=465&distance=0&mainCity=0&search=1&category_id=82&keywords=&type=0&orderBy=1&detailsSearch=0&cost_min=300&cost_max=900",
                "http://www.skelbiu.lt/skelbimai/nekilnojamasis-turtas/namai/",
                "http://www.skelbiu.lt/skelbimai/transportas/kita/",
                "http://www.skelbiu.lt/skelbimai/?cities=0&distance=0&mainCity=0&search=1&category_id=4744&keywords=iphone+4&type=0&orderBy=2&detailsSearch=1&cost_min=700&cost_max=960"
                
            });
            }
        }
    }
}
