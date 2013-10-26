using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using XAFSkelbimaiPrograma.Parser.Helpers;

namespace XAFSkelbimaiPrograma.Parser.Plugins
{
    class PluginAutogidas : IPlugin
    {
        private const string m_firstPattern = "<div class=\"sk-sar\">";
		private const string m_secondPattern = "<td class=\"tceil-1\">";

        public PluginAutogidas()
        {
 
        }

		public List<AdvertDto> Parse(string url)
		{
            List<AdvertDto> result = new List<AdvertDto>();

            string source = new SourceHelper().GetSource(url);
            List<AdvertDto> objectList = MakeObjectsFromSource(source);
            result.AddRange(objectList);
			
            return result;
		}

        private List<AdvertDto> MakeObjectsFromSource(string source)
        {
            if (string.IsNullOrEmpty(source))
                return new List<AdvertDto>();
            string[] splitedFirst = Regex.Split(source, m_firstPattern);
            List<AdvertDto> result = new List<AdvertDto>();

            if (splitedFirst.Length == 1)
                return result;

            string[] splitedSecond = Regex.Split(splitedFirst[1], m_secondPattern);

            for (int i = 1; i < splitedSecond.Length; i++)
            {
                AdvertDto advert = CreateObject(splitedSecond[i]);
                result.Add(advert);
            }

            return result;
        }

        private AdvertDto CreateObject(string sourcePart)
		{
            AdvertDto advert = new AdvertDto();
            advert.UrlLink = GetFields.GetLink(sourcePart);
            advert.Name = GetFields.GetName(sourcePart);
            advert.Column1 = GetFields.GetFuelType(sourcePart);
            advert.Year = GetFields.GetYear(sourcePart);
            advert.Price = GetFields.GetPrice(sourcePart);
            //			advert. = GetFields.GetCity(sourcePart);

            return advert;
		}
		
//		public string Name {
//			get {
//				return "Autogidas.lt";
//			}
//		}
//		
//		public string FileName {
//			get {
//				return "SkelbimaiPrograma.Autogidas.dll";
//			}
//		}
//		
//		public string UrlColumnName {
//			get {
//				return "COLUMN1";
//			}
//		}


        public List<string> TestLinks
        {
            get { return new List<string>(new string[] 
            { 
                "http://www.autogidas.lt/automobiliai/?f_1=&f_model_14=--------&f_41=&f_42=&f_215=&f_216=&f_2=&f_245=Visos+%C5%A1alys&f_60=728&f_376=&search=Surasti&f_50=ivedimo_laika_asc" 
            
            }); }
        }

        public string UniqueCode
        {
            get { return "Autogidas.lt"; }
        }
    }
	
	public static class GetFields
	{
		public static string GetLink(string sourcePart)
		{
			string[] split = Regex.Split(sourcePart, "<a href=\"");
			string[] split1 = Regex.Split(split[1], "\\\" >");
			return split1[0];
		}
		
		public static string GetName(string sourcePart)
		{
			string[] split = Regex.Split(sourcePart, " alt=\"");
			string[] split1 = Regex.Split(split[1], "\" width=\"");
//			split1 = Regex.Split(split1[0], "\"><div class=\"sereyo_box\">");
			
			return split1[0].Remove(split1[0].Length - 5, 5);
			
		}
		
		public static string GetFuelType(string sourcePart)
		{
			string[] split = Regex.Split(sourcePart, "<span class=\"ttitle2\">");
			string[] split1 = Regex.Split(split[1], ",");
			return split1[0];
		}
		
		public static string GetYear(string sourcePart)
		{
			string[] split = Regex.Split(sourcePart, " alt=\"");
			string[] split1 = Regex.Split(split[1], "\" width=\"");
			string[] split2 = Regex.Split(split1[0], " ");
			return split2[split2.Length-1];
		}
		
		public static string GetPrice(string sourcePart)
		{
			string[] split = Regex.Split(sourcePart, "<td class=\"tceil-4\"><span class=\"ttitle1\">");
			string[] split1 = Regex.Split(split[1], "<br /><span class=");
			return split1[0];
		}
		
		public static string GetCity(string sourcePart)
		{
			string[] split = Regex.Split(sourcePart, "</span></div><span class=\"ttitle3\">");
			string[] split1 = Regex.Split(split[1], "</span></div></td><td class=\"tceil-3\">");
			return split1[0];
		}
	}
    
}
