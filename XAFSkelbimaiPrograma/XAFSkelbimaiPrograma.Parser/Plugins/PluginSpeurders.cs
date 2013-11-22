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
    class PluginSpeurders : IPlugin
    {
        private UserParseInfoDto m_info;

        public List<AdvertDto> Parse(string url, UserParseInfoDto info)
        {
            m_info = info;
            string source = new SourceHelper().GetSource(url);
            List<string> parts = ParseToParts(source);
            return ParseToAdvertDtos(parts);
        }

        private List<string> ParseToParts(string source)
        {
            List<string> parts = Regex.Split(source, "data-ad-id=\"").ToList();
            if (parts.Count != 0)
                parts.RemoveAt(0);
            return parts;

        }

        private List<AdvertDto> ParseToAdvertDtos(List<string> parts)
        {
            List<AdvertDto> result = new List<AdvertDto>();

            foreach (string part in parts)
            {
                //				if(part.IndexOf("<h4>") == -1)
                //					continue;

                AdvertDto advert = new AdvertDto();

                advert.Name = GetName(part);
                advert.UrlLink = GetLink(part);
                advert.Price = GetPrice(part);
                advert.Image = GetImage(part);

                result.Add(advert);
            }

            return result;
        }

        #region GetFunctions
        private string GetName(string part)
        {
            try
            {
                string[] parts = Regex.Split(part, "<h2>");
                string[] parts1 = Regex.Split(parts[1], "</h2>");
                return parts1[0];
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "<a href=\"");
            string[] parts1 = Regex.Split(parts[1], ".html");
            return "http://www.speurders.nl" + parts1[0] + ".html";
        }

        private string GetPrice(string part)
        {
            try
            {
                string[] parts = Regex.Split(part, "&euro");
                if (parts.Length == 1)
                    return string.Empty;
                string[] parts1 = Regex.Split(parts[1], "</");
                return parts1[0]
                    .Replace("\t", string.Empty)
                    .Replace("\n", string.Empty)
                    .Replace(";", string.Empty)
                    .Replace("nbsp", string.Empty)
                    .Replace("&", string.Empty).Trim();
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        private Image GetImage(string part)
        {
            if (m_info == null || m_info.Photo == false)
                return null;

            try
            {
                part = part.Replace(":", string.Empty).Replace("(", string.Empty);
                string[] parts = Regex.Split(part, "style=\"background-image url'//");
                if (parts.Length == 1)
                    return null;
                string[] parts2 = Regex.Split(parts[1], "'");
                if (parts2.Length == 1)
                    return null;
                return new SourceHelper().GetImage("http://" + parts2[0]);
            }
            catch (Exception e)
            {
                if (e.Message.IndexOf("(404) Not Found") == -1)
                    throw e;
                else
                    return null;
            }

        }
        #endregion

        public string UniqueCode
        {
            get { return "Speurders.nl"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://www.speurders.nl/overzicht/autos/ford/f_automodel-Focus/f_particulier_zakelijk-particulier/?fh_sort_by=-sort_tijd&excludeEroAds=1",
                "http://www.speurders.nl/overzicht/autos/bmw/f_automodel-X5/f_particulier_zakelijk-particulier/?fh_sort_by=-sort_tijd",
                "http://www.speurders.nl/overzicht/autos/f_particulier_zakelijk-particulier,zakelijk/f_bouwjaar-na%202004,2000%20tot%202004/?order_direction=desc&order_by=date&local-postcode=&query=motorschade&max_prijs=&local-distance_value=0&min_prijs="
            });
            }
        }
    }
}
