/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.12
 * Time: 23:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Minder.Static;

namespace Minder.Sql
{
	/// <summary>
	/// Description of DBTypesConverter.
	/// </summary>
	public class DBTypesConverter
	{
		public static string AddQuotes(string s)
		{
			if (string.IsNullOrEmpty(s))
				return "''";
			else
				return string.Format("'{0}'", FixSingleQuote(s));
		}
		/// <summary>
		/// Doesn't include mili seconds
		/// 
		/// Example: 2010.11.15 05:29:58
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		[Obsolete("Geriau turbūt ToFullDateStringByCultureInfo naudoti")]
		public static string ToFullDateString(DateTime dateTime)
		{
			return string.Format("{0:yyyy.MM.dd HH:mm:ss}", dateTime);
		}

	    public static string ShortDateFormat
	    {
	        get { return StaticData.Settings.CultureData.CultureInfo.DateTimeFormat.ShortDatePattern; }
	    }

	    public static string TimeFormat
	    {
            get { return StaticData.Settings.CultureData.CultureInfo.DateTimeFormat.LongTimePattern; }
	    }

	    public static string FullDateFormat
	    {
	        get { return ShortDateFormat + " " + TimeFormat; }
	    }

		/// <summary>
		/// Not tested for use in db
		/// </summary>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static string ToFullDateStringByCultureInfo(DateTime dateTime)
		{
			return string.Format("{0} {1}", dateTime.ToShortDateString(), string.Format("{0:HH:mm:ss}", dateTime));
		}
		
		public static string ToFullDateStringByCultureInfoWithQuotes(DateTime dateTime)
		{
			return AddQuotes(ToFullDateStringByCultureInfo(dateTime));
		}
		
		[Obsolete("Turbūt geriau naudoti ToFullDateStringByCultureInfoWithQuotes")]
		public static string ToFullDateStringWithQuotes(DateTime dateTime)
		{
			return AddQuotes(ToFullDateString(dateTime));
		}
		
		[Obsolete]
		public static string TodayToFullDateString()
		{
			return ToFullDateString(DateTime.Now);
		}
		
		[Obsolete]
		public static string TodayToFullDateStringAddQuotes()
		{
			return ToFullDateStringWithQuotes(DateTime.Now);
		}
		
		/// <summary>
		/// Tiesiog apostropus (single quote) keičia į dvigubą single quote, tada
		/// tokie stringai tampa validžiais sql užklausose.
		/// 
		/// First time for me problem occured in ELK 39 document,
		/// where strings were used in sql containing symbol ' (apostrophe)
		/// </summary>
		/// <returns></returns>
		public static string FixSingleQuote(string text)
		{
			return text.Replace("'", "''");
		}
	}
}
