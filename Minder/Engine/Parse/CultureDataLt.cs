﻿/*
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
	public class CultureDataLt : ICultureData
	{
		
		public const string  MINUTES_STRING = @"\b\d*[,]{0,1}\d*((min\.)|(min\b)|(m\.)|(m\b))";
		public const string  HOURS_STRING = @"\b\d*[,]{0,1}\d*((val\.)|(val\b)|(v\.)|(v\b)|(h\.)|(h\b))";
		public const string  TIME_STRING = @"\b\d{1,2}[:]\d{1,2}[:]{0,1}\d{0,2}$";
		public const string  DATE_TIME_STRING = @"\b\d{0,4}(\.|-|\\){0,1}\d{1,2}(\.|-|\\)\d{1,2}[ ]\d{1,2}[:]\d{1,2}[:]{0,1}\d{0,2}$";
		public const string  YEAR = @"\b\d{4,4}";
		
		
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
	}
}
