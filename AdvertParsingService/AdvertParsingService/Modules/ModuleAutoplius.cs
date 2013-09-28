/*
 * Created by SharpDevelop.
 * User: Ignas T60
 * Date: 2013-09-28
 * Time: 20:55
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
	/// Description of ModuleAutoplius.
	/// </summary>
	public class ModuleAutoplius : IModule
	{
		public List<Advert> Parse(string url)
		{
			string source = GetSource(url);
			List<string> parts = ParseToParts(source);
			return ParseToAdverts(parts);
		}
		
		private List<string> ParseToParts(string source)
		{
			string[] parts = Regex.Split(source, "<div class=\"item\">");
			List<string> result = new List<string>(parts);
			if(result.Count != 0)
			{
				result.RemoveAt(0);
				if(result.Count != 0)
					result.RemoveAt(result.Count-1); //paskutinį išmetam
			}
			return result;
		}
		
		private List<Advert> ParseToAdverts(List<string> parts)
		{
			List<Advert> result = new List<Advert>();
			
			foreach(string part in parts)
			{
				Advert advert = new Advert();
				advert.Name = GetName(part);
				advert.YearA = GetYear(part);
//				advert.Column3 = GetFuelType(part);
				advert.Price = GetPrice(part);
//				advert.Column5 = GetCity(part);
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
			if(parts.Length == 1)
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
		
		private string GetSource(string url)
		{
			WebClient webClient = new WebClient();
//			webClient.Headers["Accept-Language"] = "lt-LT";
			string source = webClient.DownloadString(url);
			webClient.Dispose();
			return source;
		}
	}
}
