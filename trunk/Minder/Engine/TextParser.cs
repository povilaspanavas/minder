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
	public class TextParserException : Exception
	{
//		public TextParserException(string message)
//		{
//			this. = message;
//		}
	}
	/// <summary>
	/// Description of TextParser.
	/// </summary>
	public class TextParser
	{
		public const string  MINUTES_STRING = @"\b\d*[,]{0,1}\d*(min.|min|m.|m)";
		public const string  HOURS_STRING = @"\b\d*[,]{0,1}\d*(h|h.|v|v.|val|val.)";
		
		public TextParser()
		{
		}
		
		public void Parse(string text, out decimal hours, out decimal minutes, out string leftText)
		{
			hours = 0.00m; minutes = 0.00m;
			Match minutesMatch = Regex.Match(text, MINUTES_STRING);
			Match hoursMatch = Regex.Match(text, HOURS_STRING);
			string minutesString = minutesMatch.Value;
			string hoursString = hoursMatch.Value;
			if (minutesMatch.Success == false && hoursMatch.Success == false)
				throw new TextParserException();
			
			decimal.TryParse(RemoveMinutesSymbol(minutesString), out minutes);
			decimal.TryParse(RemoveHoursSymbol(hoursString), out hours);
			
			leftText = text;
			if (minutesMatch.Success)
				leftText = leftText.Replace(minutesString, string.Empty);
			if (hoursMatch.Success)
				leftText = leftText.Replace(hoursString, string.Empty);
			leftText = leftText.Trim();
		}
		
		public string RemoveMinutesSymbol(string minutesString)
		{
			return minutesString.Replace("min.", string.Empty).Replace("min", string.Empty).Replace("m.", string.Empty)
				.Replace("m", string.Empty);
		}
		
		public string RemoveHoursSymbol(string minutesString)
		{
			return minutesString.Replace("val.", string.Empty).Replace("val", string.Empty).Replace("v.", string.Empty)
				.Replace("v", string.Empty).Replace("h.", string.Empty).Replace("h", string.Empty);
		}
	}
}
