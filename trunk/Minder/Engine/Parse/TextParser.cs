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

namespace Minder.Engine.Parse
{
	public class TextParser
	{
		private static ICultureData m_cultureData = new CultureDataLT();
		public static ICultureData CultureData {
			get {
				return m_cultureData;
			}
			set {
				m_cultureData = value;
			}
			
		}
		
		public TextParser()
		{
		}
		
		public static bool Parse(string text, out DateTime date, out string leftText)
		{
			if (string.IsNullOrEmpty(text) == false)
				text = text.Trim();
			leftText = text;
			date = DateTime.MinValue;
			try
			{
				if (ParseTomorrow(ref text))
				{
					leftText = text;
					if (TryParseDateTime(text, ref date, ref leftText))
						return true;
				}
				else
				{
					if (TryParseBySeperator("|", text, ref date, ref leftText))
						return true;
					if (TryParseMinutesOrHours(text, ref date, ref leftText))
						return true;
					if (TryParseDateTime(text, ref date, ref leftText))
						return true;
					if (TryParseTime(text, ref date, ref leftText))
						return true;
				}
				return false;
			}
			catch {
				return false;
			}
		}
		
		/// <summary>
		/// Jei randa žodį rytoj, tai keičia jį iškart į kitos dienos datą
		/// 
		/// O tada teksto parsinimas vyksta standartiškai ir būtent sekantys
		/// parseriai nustatys, kad ten yra kažkokia konkreti data
		/// </summary>
		/// <param name="leftText"></param>
		public static bool ParseTomorrow(ref string text)
		{
			MatchCollection tommorowMatches = Regex.Matches(text, m_cultureData.TomorrowRegex);
			Match tommorowMatch = null;
			if (tommorowMatches.Count > 0)
			{
				string newDate = DateTime.Now.AddDays(1).ToShortDateString();
					if (tommorowMatches.Count == 1)
				{
					tommorowMatch = tommorowMatches[0];
					text = text.Replace(tommorowMatch.Value, newDate);
					return true;
				}
				// pvz Pasukti dėl ryt susitikimo ryt 10:00. Turim tik paskutinį ryt nutrinti
				if (tommorowMatches.Count > 1)
				{
					tommorowMatch = tommorowMatches[tommorowMatches.Count - 1];
					int lastIndex = text.LastIndexOf(tommorowMatch.Value);
					text = text.Substring(0, lastIndex) + newDate + text.Substring(lastIndex + tommorowMatch.Value.Length);
					return true;
				}
			}
			return false;
		}
		
		public static bool TryParseBySeperator(string seperator, string text, ref DateTime date, ref string leftText)
		{
			if (text.Contains(seperator) == false)
				return false;
			decimal minutes;
			leftText = text.Substring(0, text.IndexOf(seperator));
			string time = text.Substring(text.IndexOf(seperator) + 1);
			if (decimal.TryParse(time, out minutes) == false)
				return false;
			date = DateTime.Now.AddMinutes((double)minutes);
			return true;
		}
		
		public static bool TryParseDateTime(string text, ref DateTime date, ref string leftText)
		{
			Match timeMatch = Regex.Match(text, m_cultureData.DateTimeRegex);
			if (timeMatch.Success == false)
				return false;
			string dateString = timeMatch.Value;
			// Jei pradžioj nėra nurodyta metų
			if (Regex.IsMatch(timeMatch.Value, m_cultureData.YearRegex) == false)
				dateString = m_cultureData.AddYearToMonthAndDay(dateString);
			if (DateTime.TryParse(dateString, out date) == false)
				return false;
			leftText = leftText.Replace(timeMatch.Value, string.Empty).Trim();
			return true;
		}
		
		public static bool TryParseTime(string text, ref DateTime date, ref string leftText)
		{
			Match timeMatch = Regex.Match(text, m_cultureData.TimeRegex);
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
			Match minutesMatch = null;
			Match hoursMatch = null;
			
			// *** HOURS ***
			MatchCollection hoursCollection = Regex.Matches(text, m_cultureData.HoursRegex);
			if (hoursCollection.Count > 0)
			{
				hoursMatch = hoursCollection[hoursCollection.Count - 1];
				leftText = leftText.Replace(hoursMatch.Value, string.Empty);
			}
			
			// *** MINUTES ***
			MatchCollection minutesCollection = Regex.Matches(leftText, m_cultureData.MinutesRegex);
			if (minutesCollection.Count > 0)
			{
				minutesMatch = minutesCollection[minutesCollection.Count - 1];
				leftText = leftText.Replace(minutesMatch.Value, string.Empty); // we must remove point from "15h.20min"
			}
			
			if (minutesCollection.Count == 0 && hoursCollection.Count == 0)
				return false;
			
			leftText = leftText.Trim();
			
			string minutesString = minutesMatch != null ? minutesMatch.Value : string.Empty;
			string hoursString = hoursMatch != null ? hoursMatch.Value : string.Empty;
			
			decimal.TryParse(RemoveMinutesSymbol(minutesString), out minutes);
			decimal.TryParse(RemoveHoursSymbol(hoursString), out hours);
			date = DateTime.Now.AddHours((double)hours).AddMinutes((double)minutes);
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
