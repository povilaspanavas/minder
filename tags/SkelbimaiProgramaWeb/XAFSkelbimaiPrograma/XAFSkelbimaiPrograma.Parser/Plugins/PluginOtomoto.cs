﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XAFSkelbimaiPrograma.Parser.Helpers;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    class PluginOtomoto : IPlugin
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

        #region get functions
        private string GetName(string part)
        {
            string[] parts = Regex.Split(part, "<a href=");
            string[] parts2 = Regex.Split(parts[1], "\">");
            string[] parts3 = Regex.Split(parts2[1], "</a>");
            return parts3[0].Replace("\n", string.Empty);

        }

        private string GetLink(string part)
        {
            string[] parts = Regex.Split(part, "<a href=\"");
            string[] parts2 = Regex.Split(parts[1], "\"");
            if (parts2[0].IndexOf("allegro") != -1)
                return parts2[0];
            return "http://www.otomoto.pl" + parts2[0];
        }

        private string GetPrice(string part)
        {
            string[] parts = Regex.Split(part, "\"om-price-primary\">");
            if (parts.Length <= 1)
                return string.Empty;

            string[] parts2 = Regex.Split(parts[1], "</strong>");
            return parts2[0]
                .Replace("<strong>", string.Empty)
                .Replace("\n", string.Empty)
                .Trim();
        }

        private string GetYear(string part)
        {
            string[] parts = Regex.Split(part, "<span>Rocznik</span>:");
            if (parts.Length <= 1)
                return string.Empty;
            string[] parts2 = Regex.Split(parts[1], "</strong>");
            return parts2[0].Replace("<strong>", string.Empty).Trim();
        }

        private Image GetImage(string sourcePart)
        {
            if (m_info == null || m_info.Photo == false)
                return null;

            string[] split = Regex.Split(sourcePart, "data-photo=\"");
            if (split.Length < 2)
                return null;
            string[] split1 = Regex.Split(split[1], "\"");
            if (split1.Length < 2)
                return null;

            return new SourceHelper().GetImage(split1[0].Trim());
        }
        #endregion

        private List<string> ParseToParts(string source)
        {
            List<string> parts = Regex.Split(source, "<article").ToList();
            if (parts.Count > 0)
                parts.RemoveAt(0);
            if (parts.Count > 0)
                parts.RemoveAt(0);

            return parts;
        }

        public string UniqueCode
        {
            get { return "Otomoto.pl"; }
        }

        public List<string> TestLinks
        {
            get
            {
                return new List<string>(new string[] 
            { 
                "http://otomoto.pl/osobowe/volkswagen/polo,iii/"
                
            });
            }
        }
    }
}