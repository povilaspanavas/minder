using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using XAFSkelbimaiPrograma.Parser.Helpers;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    class PluginAutotrader : IPlugin
    {

        public List<AdvertDto> Parse(string url, UserParseInfoDto info)
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
                AdvertDto advert = new AdvertDto();
                advert.Name = GetName(part);
                advert.UrlLink = GetLink(part);
                advert.Year = GetYear(part);
                advert.Price = GetPrice(part);
               // advert.Image = GetImage(part);
                result.Add(advert);
            }

            return result;
        }

        #region Get functions
        private string GetName(string part)
        {
            string[] parts = Regex.Split(part, "title=\"");
            string[] parts2 = Regex.Split(parts[1], "\"");
            return parts2[0];
        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "href='");
            string[] parts2 = Regex.Split(parts[1], "'");
            string[] parts3 = Regex.Split(parts2[0], "/sort");
            return parts3[0];
        }

        private string GetYear(string part)
        {
            string[] parts = Regex.Split(part, "advertTitleSub\">");
            if (parts.Length == 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "<");
            return parts2[0];
        }

        private string GetPrice(string part)
        {
            string[] parts = Regex.Split(part, "deal-price\" >");
            if (parts.Length == 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "<");
            return parts2[0].Replace("&pound;", string.Empty);
        }

        //private string GetImage(string part)
        //{
        //    if (ImageHelper.LoadImages() == false)
        //        return string.Empty;

        //    string[] parts = Regex.Split(part, "<img src=\"");
        //    if (parts.Length == 1)
        //        return string.Empty;
        //    string[] parts2 = Regex.Split(parts[1], "\"");
        //    return ImageHelper.ConvertToBase64(parts2[0]);
        //}
        #endregion

        private List<string> ParseToParts(string source)
        {
            List<string> parts = Regex.Split(source, "<div class=\"advertMainImageContainer\">").ToList();
            if (parts.Count != 0)
                parts.RemoveAt(0);
            return parts;
        }

        public string UniqueCode
        {
            get { return "Autotrader.co.uk"; }
        }

        public List<string> TestLinks
        {
            get { return new List<string>(new string[] 
            { 
                "http://www.autotrader.co.uk/search/used/cars/volkswagen/polo/postcode/e151af/radius/1500/onesearchad/used%2Cnearlynew%2Cnew/quicksearch/true/page/1/sort/locasc"
            }); }
        }
    }
}
