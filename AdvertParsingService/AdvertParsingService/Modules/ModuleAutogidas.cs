﻿/*
 * Created by SharpDevelop.
 * User: Ignas T60
 * Date: 2013-09-28
 * Time: 15:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

using AdvertModel;

namespace AdvertParsingService.Modules
{
	/// <summary>
	/// Description of ModuleAutogidas.
	/// </summary>
	public class ModuleAutogidas : IModule
	{
		private const string m_firstPattern = "<div class=\"sk-sar\">";
		private const string m_secondPattern = "<td class=\"tceil-1\">";
		
		public ModuleAutogidas()
		{
		}
		
		public List<Advert> Parse(string url)
		{
			List<Advert> result = new List<Advert>();
			
			string source = GetSource(url);
			List<Advert> objectList = MakeObjectsFromSource(source);
			result.AddRange(objectList);
			
			return result;
		}
		
		private string GetSource(string url)
		{
			WebClient webClient = new WebClient();
			webClient.Headers["Accept-Language"] = "lt-LT";
			string source = webClient.DownloadString(url);
			webClient.Dispose();
			return source;
		}
		
		private List<Advert> MakeObjectsFromSource(string source)
		{
			if(string.IsNullOrEmpty(source))
				return new List<Advert>();
			string[] splitedFirst = Regex.Split(source, m_firstPattern);
			List<Advert> result = new List<Advert>();
			
			if(splitedFirst.Length == 1)
				return result;
			
			string[] splitedSecond = Regex.Split(splitedFirst[1], m_secondPattern);
			
			for(int i=1; i<splitedSecond.Length; i++)
			{
				Advert advert = CreateObject(splitedSecond[i]);
				result.Add(advert);
			}
			
			return result;
		}
		
		private Advert CreateObject(string sourcePart)
		{
			Advert advert = new Advert();
			advert.UrlLink = GetFields.GetLink(sourcePart);
			advert.Name = GetFields.GetName(sourcePart);
//			advert. = GetFields.GetFuelType(sourcePart);
			advert.YearA = GetFields.GetYear(sourcePart);
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
            get { throw new NotImplementedException(); }
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