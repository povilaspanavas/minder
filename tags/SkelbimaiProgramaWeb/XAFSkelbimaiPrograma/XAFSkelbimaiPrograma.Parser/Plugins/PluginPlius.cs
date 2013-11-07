using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XAFSkelbimaiPrograma.Parser.Helpers;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    class PluginPlius : IPlugin
    {
        public List<AdvertDto> Parse(string url, UserParseInfoDto info)
        {
            string source = new SourceHelper().GetSource(url);
            List<string> sourceParts = ParseAdvertDtoSmallSource(source);
            return ParseToAdvertDtos(sourceParts);
        }

        private List<AdvertDto> ParseToAdvertDtos(List<string> sourceParts)
        {
            List<AdvertDto> result = new List<AdvertDto>();

            foreach (string part in sourceParts)
            {
                AdvertDto advert = new AdvertDto();
                advert.Name = GetName(part);
                advert.UrlLink = GetLink(part);
                //advert.Column3 = GetDate(part);
                advert.Price = GetPrice(part);

                result.Add(advert);
            }

            return result;
        }

        private string GetName(string sourcePart)
        {
            string[] splited = Regex.Split(sourcePart, "title=\"");
            string[] splited2 = Regex.Split(splited[1], "\" href");
            return splited2[0];
        }

        private string GetLink(string sourcePart)
        {
            string[] splited = Regex.Split(sourcePart, "href=\"");
            string[] splited2 = Regex.Split(splited[1], "\">");
            return splited2[0];
        }

        private string GetDate(string sourcePart)
        {
            string[] splited = Regex.Split(sourcePart, "</div></div>");
            string result = Regex.Replace(splited[0], "<br />", " ");
            result = Regex.Replace(result, "\t", string.Empty);
            result = Regex.Replace(result, "\n", string.Empty);
            return result;
        }

        private string GetPrice(string sourcePart)
        {
            string[] splited = Regex.Split(sourcePart, "Lt</div>");
            if (splited.Length == 1)
                return string.Empty;
            string[] splited2 = Regex.Split(splited[0], "<div class=\"section\">");
            return splited2[splited2.Length - 1] + "Lt";
        }

        private List<string> ParseAdvertDtoSmallSource(string source)
        {
            string[] smallSources = Regex.Split(source, "<div class=\"list-date\"><div class=\"section\">");
            List<string> result = new List<string>(smallSources);
            if (result.Count != 0)
                result.RemoveAt(0);
            return result;
        }

        public string UniqueCode
        {
            get { return "Plius.lt"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://www.plius.lt/skelbimai?fk_place_regions_id=10",
                "http://www.plius.lt/skelbimai?fk_place_regions_id=8",
                "http://www.plius.lt/skelbimai?fk_place_regions_id=2"
                
            });
            }
        }
    }
}
