﻿/*
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
	public delegate string Converter();
	
	public interface ICultureData
	{
		string Name {get;} // Just for information
		CultureInfo CultureInfo {get;}
		string MinutesRegex {get;}
		string HoursRegex {get;}
		string TimeRegex{get;}
		string DateTimeRegex{get;}
		string YearRegex{get;}
		string AddYearToMonthAndDay(string dateTimeNoYear);
		
		/// <summary>
		/// For example, text Monday converts to Monday's date
		/// Tommorow converts to tomorrows's date
		/// </summary>
		Dictionary<string, Converter> Converters {get;}
	}
}
