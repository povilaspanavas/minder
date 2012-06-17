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
		
		public TextParser()
		{
		}
		
		public static bool Parse(string text, out DateTime date, out string leftText)
		{
			decimal hours = 0.00m; decimal minutes = 0.00m; date = DateTime.MinValue;
			Match minutesMatch = Regex.Match(text, MINUTES_STRING);
			Match hoursMatch = Regex.Match(text, HOURS_STRING);
			string minutesString = minutesMatch.Value;
			string hoursString = hoursMatch.Value;
			leftText = text;
			
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
