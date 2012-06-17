/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.16
 * Time: 17:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text.RegularExpressions;

namespace Minder.Engine
{
	/// <summary>
	/// TODO palaikyti
	/// Palaikyti 11:50 formatą
	/// 2011 05 10 11:10 ir pan.formatus
	/// </summary>
	public class TextParser
	{
		public const string  MINUTES_STRING = @"\b\d*[,]{0,1}\d*(min.|min|m.|m)";
		public const string  HOURS_STRING = @"\b\d*[,]{0,1}\d*(val.|val|v.|v|h.|h)";
		public const string  TIME_STRING = @"\b\d{1,2}[:]\d{1,2}[:]{0,1}\d{0,2}$";
		public const string  DATE_TIME_STRING = @"\b\d{0,4}(\.|-|\\){0,1}\d{1,2}(\.|-|\\)\d{1,2}[ ]\d{1,2}[:]\d{1,2}[:]{0,1}\d{0,2}$";
		
		
		
		public TextParser()
		{
		}
		
		public static bool Parse(string text, out DateTime date, out string leftText)
		{
			leftText = text;
			date = DateTime.MinValue; 
			if (TryParseMinutesOrHours(text, ref date, ref leftText))
				return true;
			if (TryParseTime(text, ref date, ref leftText))
				return true;
			return false;
		}
		
		public static bool TryParseTime(string text, ref DateTime date, ref string leftText)
		{
			Match timeMatch = Regex.Match(text, TIME_STRING);
			if (timeMatch.Success == false)
				return false;
			if (DateTime.TryParse(timeMatch.Value, out date) == false)
				return false;
			leftText = leftText.Replace(timeMatch.Value, string.Empty).Trim();
			return true;
		}




		public static bool TryParseMinutesOrHours(string text, ref DateTime date, ref string leftText)
		{
			decimal hours = 0.00m;
			decimal minutes = 0.00m;
			Match minutesMatch = Regex.Match(text, MINUTES_STRING);
			Match hoursMatch = Regex.Match(text, HOURS_STRING);
			string minutesString = minutesMatch.Value;
			string hoursString = hoursMatch.Value;
			if (minutesMatch.Success == false && hoursMatch.Success == false)
				return false;
			decimal.TryParse(RemoveMinutesSymbol(minutesString), out minutes);
			decimal.TryParse(RemoveHoursSymbol(hoursString), out hours);
			date = DateTime.Now.AddHours((double)hours).AddMinutes((double)minutes);
			if (minutesMatch.Success)
				leftText = leftText.Replace(minutesString, string.Empty);
			if (hoursMatch.Success)
				leftText = leftText.Replace(hoursString, string.Empty);
			leftText = leftText.Trim();
			return true;
		}
		
		public static string RemoveMinutesSymbol(string minutesString)
		{
			return minutesString.Replace("min.", string.Empty).Replace("min", string.Empty).Replace("m.", string.Empty)
				.Replace("m", string.Empty);
		}
		
		public static string RemoveHoursSymbol(string minutesString)
		{
			return minutesString.Replace("val.", string.Empty).Replace("val", string.Empty).Replace("v.", string.Empty)
				.Replace("v", string.Empty).Replace("h.", string.Empty).Replace("h", string.Empty);
		}
	}
}
