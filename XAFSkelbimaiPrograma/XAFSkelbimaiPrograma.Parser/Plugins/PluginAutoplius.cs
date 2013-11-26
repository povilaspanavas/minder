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
    class PluginAutoplius : IPlugin
    {
        private UserParseInfoDto m_info;

        public List<AdvertDto> Parse(string url, UserParseInfoDto info)
        {
            m_info = info;
            string source = new SourceHelper().GetSource(url);
            if (source.IndexOf("JÅ«s virÅijote leistinÄ") != -1)
            {
                source = new SourceHelper().GetSourceViaVpn(url);
                new LogDBHelper().Log(new Exception("Viršytas autoplius.lt limitas"), null, LogType.ParserError);
            }
            List<string> parts = ParseToParts(source);
            return ParseToAdvertDtos(parts);
        }

        private List<string> ParseToParts(string source)
        {
            string[] parts = Regex.Split(source, "<div class=\"item\">");
            List<string> result = new List<string>(parts);
            if (result.Count != 0)
            {
                result.RemoveAt(0);
                if (result.Count != 0)
                    result.RemoveAt(result.Count - 1); //paskutinį išmetam
            }
            return result;
        }

        private List<AdvertDto> ParseToAdvertDtos(List<string> parts)
        {
            List<AdvertDto> result = new List<AdvertDto>();

            foreach (string part in parts)
            {
                AdvertDto advert = new AdvertDto();
                advert.Name = GetName(part);
                advert.Year = GetYear(part);
                advert.Column1 = GetFuelType(part);
                advert.Price = GetPrice(part);
                advert.Image = GetImage(part);
                //advert. = GetCity(part);
                advert.UrlLink = GetLink(part);
                result.Add(advert);
            }

            return result;
        }

        private string GetName(string part)
        {
            string[] parts = Regex.Split(part, "title-list\\\">");
            string[] parts2 = Regex.Split(parts[1], ".html\\\" title=\\\"");
            string[] parts3 = Regex.Split(parts2[1], "\\\"");
            return parts3[0];
        }

        private string GetYear(string part)
        {
            string[] parts = Regex.Split(part, "Pagaminimo data\\\">");
            string[] parts2 = Regex.Split(parts[1], "</span>");
            return parts2[0];
        }

        private string GetFuelType(string part)
        {
            string[] parts = Regex.Split(part, "Kuro tipas\\\">");
            if (parts.Length == 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "</span>");
            return parts2[0];
        }

        private string GetPrice(string part)
        {
            string[] parts = Regex.Split(part, "\">Kaina: <strong>");
            string[] parts2 = Regex.Split(parts[1], "</strong>");
            return parts2[0];
        }

        private string GetCity(string part)
        {
            string[] parts = Regex.Split(part, "\\\"Miestas\\\">");
            string[] parts2 = Regex.Split(parts[1], "</span>");
            return parts2[0];
        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "<a href=\\\"");
            string[] parts2 = Regex.Split(parts[1], "\\\"");
            return parts2[0];
        }

        private Image GetImage(string sourcePart)
        {
            if (m_info == null || m_info.Photo == false)
                return null;

            string[] split = Regex.Split(sourcePart, "src=\"");
            if (split.Length < 2)
                return null;
            string[] split1 = Regex.Split(split[1], "\"");
            if (split1.Length < 2)
                return null;

            return new SourceHelper().GetImage(split1[0]);
        }

        public string UniqueCode
        {
            get { return "Autoplius.lt"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            {
                "http://auto.plius.lt/skelbimai/naudoti-automobiliai",
                "http://auto.plius.lt/skelbimai/naudoti-automobiliai?make_id_list=97&make_id[97]=0",
                "http://auto.plius.lt/skelbimai/naudoti-automobiliai?make_id_list=72&make_id[72]=0",
                "http://auto.plius.lt/skelbimai/motociklai-vandens-transportas-apranga/motociklai?order_direction=DESC&order_by=1&engine_capacity_from=500&make_date_from=2005"
            });
            }
        }
    }
}
