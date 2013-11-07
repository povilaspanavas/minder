using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XAFSkelbimaiPrograma.Parser.Helpers;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    class PluginLeboncoin : IPlugin
    {
        public List<AdvertDto> Parse(string url, UserParseInfoDto info)
        {
            string source = new SourceHelper().GetSource(url);
            List<string> parts = ParseToParts(source);
            List<AdvertDto> adverts = ParseToAdvertDtos(parts);

            return adverts;
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
                advert.Column1 = GetDetail(part);
                //advert.Image = GetImage(part);


                result.Add(advert);
            }

            return result;
        }

        private string GetName(string part)
        {
            string[] parts = Regex.Split(part, "title=\"");
            string[] parts2 = Regex.Split(parts[1], "\">");
            return parts2[0];
        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "\"");
            return "http://www.leboncoin.fr" + parts[0];
        }

        private string GetPrice(string part)
        {
            string[] parts = Regex.Split(part, "<div class=\"price\">");
            if (parts.Length == 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "&nbsp;&euro;");
            return parts2[0].Replace("\\n", string.Empty).Trim();
        }

        private string GetDetail(string part)
        {
            string[] parts = Regex.Split(part, "<div class=\"placement\">");
            if (parts.Length == 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "</div>");
            return parts2[0].Replace("\n", string.Empty).Replace(" ", string.Empty).Trim();
        }

        //private string GetImage(string part)
        //{
        //    if (ImageHelper.LoadImages() == false)
        //        return string.Empty;

        //    string[] parts = Regex.Split(part, "<img src=\"");
        //    if (parts.Length == 1)
        //        return string.Empty;
        //    string[] parts2 = Regex.Split(parts[1], "\"");
        //    return ImageHelper.ConvertToBase64(parts2[0].Trim());
        //}

        private List<string> ParseToParts(string source)
        {
            List<string> result = new List<string>();
            string[] parts = Regex.Split(source, "<div class=\"list-lbc\">");
            string[] parts2 = Regex.Split(parts[1], "<a href=\"http://www.leboncoin.fr");

            foreach (string part in parts2)
            {
                if (part.IndexOf("<div class=\"lbc\">") != -1)
                    result.Add(part);
            }

            return result;
        }

        public string UniqueCode
        {
            get { return "Leboncoin.fr"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://www.leboncoin.fr/voitures/offres/bourgogne/nievre/?f=a&th=1"
            });
            }
        }
    }
}
