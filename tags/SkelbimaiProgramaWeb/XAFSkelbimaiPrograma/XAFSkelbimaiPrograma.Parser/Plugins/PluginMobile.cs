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
    class PluginMobile : IPlugin
    {
        private UserParseInfoDto m_info;

        public List<AdvertDto> Parse(string url, UserParseInfoDto info)
        {
            m_info = info;
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
                if (part.IndexOf("<dl>") != -1 ||
                   part.IndexOf("topOfPageTitle") != -1 ||
                   part.IndexOf("listEntryTitle") == -1)
                    continue;

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

        #region AdvertDtoFields
        private string GetName(string part)
        {
            string[] parts = Regex.Split(part, "listEntryTitle");
            string[] parts2 = Regex.Split(parts[1], "</a>");
            string[] parts3 = Regex.Split(parts2[0], "\">");
            return parts3[parts3.Length - 1];
        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "href=\"");
            string[] parts2 = Regex.Split(parts[1], "\"");
            string[] parts3 = Regex.Split(parts2[0], ".html");
            return parts3[0] + ".html";
        }

        private string GetPrice(string part)
        {
            string[] parts = Regex.Split(part, "priceGross\">");
            string[] parts2 = Regex.Split(parts[1], "</div>");
            return parts2[0];
        }

        private string GetYear(string part)
        {
            string[] parts = Regex.Split(part, "<div class=\"firstRegistration\">");
            if (parts.Length == 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "</div>");
            string result = Regex.Replace(parts2[0], "EZ&nbsp;", string.Empty);
            result = Regex.Replace(result, "FR&nbsp;", string.Empty);
            result = Regex.Replace(result, "\n", string.Empty).Trim();
            return result;
        }

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
        #endregion

        private List<string> ParseToParts(string source)
        {
            string[] parts = Regex.Split(source, "vehicleDetails");
            List<string> result = parts.ToList();
            List<string> resultFiltered = new List<string>();
            foreach (string part in result)
            {
                if (part.Equals(" "))
                    continue;

                resultFiltered.Add(part);
            }

            if (resultFiltered.Count < 2)
                return new List<string>();
            resultFiltered.RemoveAt(0);

            return resultFiltered;
        }

        public string UniqueCode
        {
            get { return "Mobile.de"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://suchen.mobile.de/auto/bmw.html?scopeId=C&isSearchRequest=true&lang=de&sortOption.sortBy=price.consumerGrossEuro&makeModelVariant1.makeId=3500&ambitCountry=",
                "http://suchen.mobile.de/auto/ford-focus.html?useCase=MiniSearch&isSearchRequest=true&minFirstRegistrationDate=1999-01-01&maxFirstRegistrationDate=2003-12-31&ambitCountry=&export=ALSO_EXPORT&damageUnrepaired=ALSO_DAMAGE_UNREPAIRED&__lp=1254&scopeId=C&sortOption.sortBy=creationTime&sortOption.sortOrder=DESCENDING&makeModelVariant1.makeId=9000&makeModelVariant1.modelId=20&makeModelVariant1.searchInFreetext=false&makeModelVariant2.searchInFreetext=false&makeModelVariant3.searchInFreetext=false&makeModelVariantExclusion1.searchInFreetext=false&lang=en&frequence=DAILY"
                
            });
            }
        }
    }
}
