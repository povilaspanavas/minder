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
    public class PluginAutoScout24 : IPlugin
    {
        public const string LINK_PREFIX = "http://www.autoscout24.de/Details.aspx?id=";
        public const string IMG_PREFIX = "http://pic3.autoscout24.net/images-small/";
        private UserParseInfoDto m_info = null;

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
                advert.Image = GetImage(part);
                result.Add(advert);
            }

            return result;
        }

        #region Get functions
        private string GetName(string part)
        {
            try
            {
                string result = string.Empty;
                string[] parts = Regex.Split(part, "\"mk\":\"");
                string[] parts2 = Regex.Split(parts[1], "\"");
                result += parts2[0] + " ";

                parts = Regex.Split(part, "\"md\":\"");
                parts2 = Regex.Split(parts[1], "\"");
                result += parts2[0] + " ";

                parts = Regex.Split(part, "\"vr\":\"");
                if (parts.Length > 1) //buna kartais čia null, ir nėra kabučių
                {
                    parts2 = Regex.Split(parts[1], "\"");
                    result += parts2[0];
                }

                return result;
            }
            catch (Exception e)
            {
                
                throw e;
            }
            
        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "\"ei\":");
            string[] parts2 = Regex.Split(parts[1], ",");
            return LINK_PREFIX + parts2[0];
        }

        private string GetYear(string part)
        {
            string[] parts = Regex.Split(part, "\"fr\":\"");
            string[] parts2 = Regex.Split(parts[1], "\"");
            return parts2[0].Replace("\\", string.Empty);
        }

        private string GetPrice(string part)
        {
            string[] parts = Regex.Split(part, "\"pp\":\"");
            string[] parts2 = Regex.Split(parts[1], "\"");
            return parts2[0];
        }

        private Image GetImage(string part)
        {
            if (m_info == null || m_info.Photo == false)
                return null;

            part = part.Replace("[", string.Empty);
            string[] parts = Regex.Split(part, "\"il\":\"");
            if (parts.Length == 1)
                return null;
            string[] parts2 = Regex.Split(parts[1], "\"");
            return new SourceHelper().GetImage(IMG_PREFIX + parts2[0].Replace("\\", string.Empty));
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
            List<string> parts = Regex.Split(source, "{\"ei\":").ToList();
            if (parts.Count != 0)
                parts.RemoveAt(0);
            return parts;
        }

        public string UniqueCode
        {
            get { return "AutoScout24.de"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://fahrzeuge.autoscout24.de/?atype=C&make=74&model=2084&mmvmk0=74&mmvmd0=2084&mmvco=1&fregfrom=1999&priceto=1000&cy=D&zipc=D&zipr=200&ustate=N,U&sort=price&results=20&page=1&event=addB||firstreg",
                "http://fahrzeuge.autoscout24.de/?atype=C&make=9&model=1619&mmvmk0=9&mmvmd0=1619&mmvco=1&fregfrom=1988&fregto=1991&priceto=1500&cy=B,D,F,L,NL,A&ustate=A,N,U&sort=age&desc=1&results=20&page=1"
            });
            }
        }
    }
}
