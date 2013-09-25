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
	public class CultureDataLT : CultureDataConverter, ICultureData
	{
		public const string NAME = "Lithuanian";
		private CultureInfo m_cultureInfo = new CultureInfo("lt-Lt");
		
		public const string MINUTES_STRING = @"\b\d+[,]{0,1}\d*((min\.)|(min\b)|(m\.)|(m\b))";
		public const string HOURS_STRING = @"\b\d+[,]{0,1}\d*((val\.)|(val\b)|(v\.)|(v\b)|(h\.)|(h\b))";
		public const string TIME_STRING = @"\b\d{1,2}[:]\d{1,2}[:]{0,1}\d{0,2}$";
		public const string DATE_TIME_STRING = @"\b\d{0,4}(\.|-|\\){0,1}\d{1,2}(\.|-|\\)\d{1,2}[ ]\d{1,2}[:]\d{1,2}[:]{0,1}\d{0,2}$";
		public const string YEAR = @"\b\d{4,4}";
		
		Dictionary<string, Converter> m_converters = new System.Collections.Generic.Dictionary<string, Converter>();
		
		public CultureDataLT()
		{
			m_converters.Add(@"\b((ryt)|(rytoj))((\b)|(\.))", Tommorow);
			m_converters.Add(@"\b((pirmadien(i|į))|(pirm))((\.)|(\b))", Monday);
			m_converters.Add(@"\b((antradien(i|į))|(antr))((\.)|(\b))", Tuesday);
			m_converters.Add(@"\b((tre(č|c)iadien(i|į))|(tre(č|c)))((\.)|(\b))", Wednesday);
			m_converters.Add(@"\b((ketvirtadien(i|į))|(ketv))((\.)|(\b))", Thursday);
			m_converters.Add(@"\b((penktadien(i|į))|(penkt)|(penk))((\.)|(\b))", Friday);
			m_converters.Add(@"\b(((š|s)e(š|s)tadien(i|į))|((š|s)e(š|s)t))((\.)|(\b))", Saturday);
			m_converters.Add(@"\b((sekmadien(i|į))|(sekm))((\.)|(\b))", Sunday);
		}
		
		public string AddYearToMonthAndDay(string dateTimeNoYear)
		{
			return DateTime.Now.Year + "." + dateTimeNoYear;
		}
		
		#region Properties
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
		
		public CultureInfo CultureInfo {
			get {
				return m_cultureInfo;
			}
		}
		#endregion
	}
}
