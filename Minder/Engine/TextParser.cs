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
		public const string  YEAR = @"\b\d{4,4}";
		
		
		
		public TextParser()
		{
		}
		
		public static bool Parse(string text, out DateTime date, out string leftText)
		{
			leftText = text;
			date = DateTime.MinValue;
			if (TryParseMinutesOrHours(text, ref date, ref leftText))
				return true;
			if (TryParseDateTime(text, ref date, ref leftText))
				return true;
			if (TryParseTime(text, ref date, ref leftText))
				return true;
			return false;
		}
		
		public static bool TryParseDateTime(string text, ref DateTime date, ref string leftText)
		{
			Match timeMatch = Regex.Match(text, DATE_TIME_STRING);
			if (timeMatch.Success == false)
				return false;
			string dateString = timeMatch.Value;
			// Jei pradžioj nėra nurodyta metų
			if (Regex.IsMatch(timeMatch.Value, YEAR) == false)
				dateString = DateTime.Now.Year + "." + dateString;
			if (DateTime.TryParse(dateString, out date) == false)
				return false;
			leftText = leftText.Replace(timeMatch.Value, string.Empty).Trim();
			return true;
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
			MatchCollection minutesCollection = Regex.Matches(text, MINUTES_STRING);
			MatchCollection hoursCollection = Regex.Matches(text, HOURS_STRING);
			if (minutesCollection.Count == 0 && hoursCollection.Count == 0)
				return false;
			
			Match minutesMatch = null;
			Match hoursMatch = null;
			if (minutesCollection.Count > 0)
				minutesMatch = minutesCollection[minutesCollection.Count - 1];
			if (hoursCollection.Count > 0)
				hoursMatch = hoursCollection[hoursCollection.Count - 1];
			
			string minutesString = minutesMatch != null ? minutesMatch.Value : string.Empty;
			string hoursString = hoursMatch != null ? hoursMatch.Value : string.Empty;
			
			decimal.TryParse(RemoveMinutesSymbol(minutesString), out minutes);
			decimal.TryParse(RemoveHoursSymbol(hoursString), out hours);
			date = DateTime.Now.AddHours((double)hours).AddMinutes((double)minutes);
			if (minutesMatch != null)
				leftText = leftText.Replace(minutesString, string.Empty);
			if (hoursMatch != null)
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
