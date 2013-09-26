/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.16
 * Time: 17:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Minder.Engine.Parse
{
	public class CultureDataUK : CultureDataConverter, ICultureData
	{
		public const string NAME = "English (United Kingdom)";
		private CultureInfo m_cultureInfo = new CultureInfo("en-GB");
		
		public const string MINUTES_STRING = @"\b\d+[.]{0,1}\d*((min\.)|(min\b)|(m\.)|(m\b))";
		public const string HOURS_STRING = @"\b\d+[.]{0,1}\d*((h\.)|(h\b))";
		public const string TIME_STRING = @"\b\d{1,2}[:]\d{1,2}[:]{0,1}\d{0,2}$";
		public const string DATE_TIME_STRING = @"\b\d{1,2}(\.|-|\\|/){0,1}\d{1,2}(\.|-|\\|/)\d{0,4}[ ]\d{1,2}[:]\d{1,2}[:]{0,1}\d{0,2}$";
		public const string YEAR = @"\b\d{4,4}";
		
		Dictionary<string, Converter> m_converters = new System.Collections.Generic.Dictionary<string, Converter>();
		
		public CultureDataUK()
		{
			m_converters.Add(@"\b((tomorrow)|(next day))((\b)|(\.))", Tommorow);
		}
		
		#region Properties
		public CultureInfo CultureInfo {
			get {
				return m_cultureInfo;
			}
		}
		public string MinutesRegex {
			get {
				return MINUTES_STRING;
			}
		}
		
		public string HoursRegex {
			get {
				return HOURS_STRING;
			}
		}
		
		public string TimeRegex {
			get {
				return TIME_STRING;
			}
		}
		
		public string DateTimeRegex {
			get {
				return DATE_TIME_STRING;
			}
		}
		
		public string YearRegex {
			get {
				return YEAR;
			}
		}
		
		public string Name {
			get {
				return NAME;
			}
		}
		
		public System.Collections.Generic.Dictionary<string, Converter> Converters {
			get {
				return m_converters;
			}
		}
		#endregion
		
		public string AddYearToMonthAndDay(string dateTimeNoYear)
		{
			return dateTimeNoYear.Replace(" ", string.Format("/{0} ", DateTime.Now.Year));
		}
	}
}
