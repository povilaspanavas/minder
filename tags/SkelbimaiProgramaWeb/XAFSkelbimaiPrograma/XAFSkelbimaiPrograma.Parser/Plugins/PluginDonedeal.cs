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
    class PluginDonedeal : IPlugin
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
                advert.Year = GetYear(part);
                advert.Price = GetPrice(part);
                // advert.Column5 = GetCountry(part);
                advert.Image = GetImage(part);

                result.Add(advert);
            }


            return result;
        }

        private string GetName(string part)
        {
            string[] split = Regex.Split(part, "alt=\"");
            if (split.Length == 1)
                return "Nėra pavadinimo";
            string[] split2 = Regex.Split(split[1], "\"");
            return split2[0];
        }

        private string GetLink(string part)
        {
            string[] split = Regex.Split(part, "<a href=\"");
            string[] split2 = Regex.Split(split[1], "\"");
            return split2[0];
        }

        private string GetYear(string part)
        {
            string[] split = Regex.Split(part, "This vehicle ad was registered");
            if (split.Length == 1)
                return string.Empty;
            string[] split2 = Regex.Split(split[1], "\">");
            string[] split3 = Regex.Split(split2[1], "<");
            return split3[0];
        }

        private string GetPrice(string part)
        {
            string[] split = Regex.Split(part, "class=\"price\">");
            if (split.Length == 1)
                return string.Empty;
            string[] split2 = Regex.Split(split[1], "<");

            return split2[0].Replace("&euro;", string.Empty);
        }

        //private string GetCountry(string part)
        //{
        //    string[] split = Regex.Split(part, "class=\"county\">");
        //    if (split.Length == 1)
        //        return string.Empty;
        //    string[] split2 = Regex.Split(split[1], "<");

        //    return split2[0];
        //}

        private Image GetImage(string sourcePart)
        {
            if (m_info == null || m_info.Photo == false)
                return null;

            string[] split = Regex.Split(sourcePart, "<img src=\"");
            if (split.Length < 2)
                return null;
            string[] split1 = Regex.Split(split[1], "\"");
            if (split1.Length < 2)
                return null;
            return new SourceHelper().GetImage(split1[0]);
        }

        private List<string> ParseToParts(string source)
        {
            string[] parts = Regex.Split(source, "class=\"saveThisAd\" id=\"");
            List<string> result = parts.ToList();
            if (result.Count != 0)
                result.RemoveAt(0);

            return result;
        }

        public string UniqueCode
        {
            get { return "Donedeal.ie"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://cars.donedeal.ie/find/cars/for-sale/Ireland/?filter%28max_engine%29=Max+Litres&filter%28max_mileage%29=Max+KM&filter%28max_price%29=Max+Price&filter%28max_year%29=Max+Year&filter%28min_engine%29=Min+Litres&filter%28min_mileage%29=Min+KM&filter%28min_price%29=Min+Price&filter%28min_year%29=Min+Year&multiFilter%28transmission%29=Manual&source=all"
                
            });
                //return new List<string>();
            }
        }
    }
}
