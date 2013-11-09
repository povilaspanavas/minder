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
    class PluginMarktplaats : IPlugin
    {
        private UserParseInfoDto m_info;

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
                advert.Year = GetYear(part);
                advert.Image = GetImage(part);

                result.Add(advert);
            }

            return result;
        }

        #region AdvertDto functions
        private string GetName(string part)
        {
            string[] parts = Regex.Split(part, "<span class=\"mp-listing-title wrapped\"");
            string[] parts2 = Regex.Split(parts[1], "title=\"");
            string[] parts3 = Regex.Split(parts2[1], "\">");
            return parts3[0];
        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "<a href=\"");
            string[] parts2 = Regex.Split(parts[1], ".html");
            return parts2[0] + ".html";
        }

        private string GetPrice(string part)
        {

            string[] parts = Regex.Split(part, "class=\"price\">");
            if (parts.Length == 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "</span>");
            string result = parts2[0];
            result = Regex.Replace(result, "&euro;&nbsp;", string.Empty);
            return result;



        }

        private string GetYear(string part)
        {
            try
            {
                string[] parts = Regex.Split(part, "<span class=\"mp-listing-attributes\">");
                if (parts.Length == 1)
                    return string.Empty;
                string[] parts2 = Regex.Split(parts[1], "</span>");
                return parts2[0];
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

            part = part.Replace(":", string.Empty).Replace("(", string.Empty);
            string[] parts = Regex.Split(part, "style=\"background-image url'//");
            if (parts.Length < 2)
                return null;
            string[] parts2 = Regex.Split(parts[1], "'");
            if (parts2.Length < 2)
                return null;
            return new SourceHelper().GetImage("http://" + parts2[0]);
        }
        #endregion

        private List<string> ParseToParts(string source)
        {
            string[] parts = Regex.Split(source, "<td class=\"column-thumb\">");
            List<string> result = parts.ToList();
            result.RemoveAt(0);

            return result;
        }

        public string UniqueCode
        {
            get { return "Marktplaats.nl"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://www.marktplaats.nl/z/auto-s/nissan.html?categoryId=135&attributes=S%2C1019&sortBy=SortIndex&sortOrder=decreasing",
                "http://www.marktplaats.nl/z/auto-s/volkswagen.html?categoryId=157&view=lr",
                "http://www.marktplaats.nl/z.html?categoryId=93&attributes=&query=&searchOnTitleAndDescription=true&priceFrom=&priceTo=&yearFrom=&yearTo=&attributes=&mileageFrom=&mileageTo=&attributes=&attributes=&attributes=&postcode=&distance=0&startDateFrom=ALWAYS#"
            });
            }
        }
    }
}
