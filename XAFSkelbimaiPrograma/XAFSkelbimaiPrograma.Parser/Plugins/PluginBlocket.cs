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
    class PluginBlocket : IPlugin
    {
        private UserParseInfoDto m_info;

        public List<AdvertDto> Parse(string url, UserParseInfoDto info)
        {
            m_info = info;
            string source = new SourceHelper().GetSource(url);
            return ParserSource(source);
        }

        private List<AdvertDto> ParserSource(string source)
        {
            List<string> smallSources = ParseAdvertDtoSmallSource(source);
            if (smallSources.Count != 0)
                smallSources.RemoveAt(0);
            List<AdvertDto> result = new List<AdvertDto>();

            foreach (string part in smallSources)
            {
                AdvertDto advert = new AdvertDto();
                advert.Name = GetName(part);
                advert.UrlLink = GetLink(part);
               // advert. = GetDateTime(sourcePart);
                advert.Price = GetPrice(part);
                advert.Image = GetImage(part);
                result.Add(advert);
            }

            return result;
        }

        private string GetPrice(string sourcePart)
        {
            string[] parts = Regex.Split(sourcePart, "<p class=\"list_price\">");
            if (parts.Length == 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "</p>");
            string result = Regex.Replace(Regex.Replace(parts2[0], "\\n", string.Empty), "\\t", string.Empty);
            result = Regex.Replace(Regex.Replace(result, ":", string.Empty), "-", string.Empty);
            return CheckPrice(result);
        }

        private string CheckPrice(string price)
        {
            string result = string.Empty;

            foreach (char c in price)
            {
                try
                {
                    int tempInt = Convert.ToInt32(c.ToString());
                    result += c.ToString();
                }
                catch
                {
                    if (c.ToString().Equals(" ") == false)
                        break;
                    else
                        result += c.ToString();
                }
            }

            return result;
        }

        private string GetName(string sourcePart)
        {
            string[] parts = Regex.Split(sourcePart, "class=\"item_link\" href=\"");
            string[] parts2 = Regex.Split(parts[1], "\">");
            string[] parts3 = Regex.Split(parts2[1], "</a>");
            return parts3[0];
        }

        private string GetLink(string sourcePart)
        {
            try
            {
                string[] parts = Regex.Split(sourcePart, "class=\"item_link\" href=\"");
                string[] parts2 = Regex.Split(parts[1], "\">");
                return parts2[0];
            }
            catch
            { return null; }
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
            if (split1[0].Equals("/img/transparent.gif"))
                return null;
            if (split1[0].IndexOf("none.gif") != -1)
                return null;
            return new SourceHelper().GetImage(split1[0]);
        }

        //private string GetDateTime(string sourcePart)
        //{
        //    string result = string.Empty;
        //    string[] parts = Regex.Split(sourcePart, "class=\"list_date\">");
        //    string[] parts2 = Regex.Split(parts[1], "<span class=\"list_time\">");
        //    result = Regex.Replace(Regex.Replace(parts2[0], "\\n", string.Empty), "\\t", string.Empty);
        //    string[] parts3 = Regex.Split(parts2[1], "</span>");
        //    result += string.Format(" {0}", parts3[0]);
        //    return result;
        //}

        private List<string> ParseAdvertDtoSmallSource(string source)
        {
            string[] smallSources = Regex.Split(source, "<div class=\"image_container");
            List<string> resultList = new List<string>(smallSources);
            resultList.RemoveAt(0);
            return resultList;
        }

        public string UniqueCode
        {
            get { return "Blocket.se"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://www.blocket.se/hela_sverige?q=&cg=1240&w=3&st=s&ps=&pe=&c=&ca=14&l=0&md=th",
                "http://www.blocket.se/hela_sverige?q=&cg=1020&w=3&st=s&ps=&pe=4&mys=1995&mye=&ms=&me=&cxpf=&cxpt=&gb=&fu=2&cxdw=&ca=14&l=0&md=th&cb=40",
                "http://www.blocket.se/hela_sverige/bilar?ca=14&w=3&cg=1020&cb=22&cbl1=20&st=s&fu=2&l=0&md=th&mys=1995&pe=6"
            });
            }
        }
    }
}
