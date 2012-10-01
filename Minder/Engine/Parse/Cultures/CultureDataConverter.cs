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
	public abstract class CultureDataConverter
	{
		#region Converters
		public string Tommorow()
		{
			return DateTime.Now.AddDays(1).ToShortDateString();
		}
		
		public string Monday()
		{
			return GetNextDateForDay(DateTime.Now, DayOfWeek.Monday).ToShortDateString();
		}
		
		public string Tuesday()
		{
			return GetNextDateForDay(DateTime.Now, DayOfWeek.Tuesday).ToShortDateString();
		}
		
		public string Wednesday()
		{
			return GetNextDateForDay(DateTime.Now, DayOfWeek.Wednesday).ToShortDateString();
		}
		
		public string Thursday()
		{
			return GetNextDateForDay(DateTime.Now, DayOfWeek.Thursday).ToShortDateString();
		}
	
		public string Friday()
		{
			return GetNextDateForDay(DateTime.Now, DayOfWeek.Friday).ToShortDateString();
		}
		
		public string Saturday()
		{
			return GetNextDateForDay(DateTime.Now, DayOfWeek.Saturday).ToShortDateString();
		}
		
		public string Sunday()
		{
			return GetNextDateForDay(DateTime.Now, DayOfWeek.Sunday).ToShortDateString();
		}
		
		/// <summary>
		/// Finds the next date whose day of the week equals the specified day of the week.
		/// </summary>
		/// <param name="startDate">
		///		The date to begin the search.
		/// </param>
		/// <param name="desiredDay">
		///		The desired day of the week whose date will be returneed.
		/// </param>
		/// <returns>
		///		The returned date occurs on the given date's week.
		///		If the given day occurs before given date, the date for the
		///		following week's desired day is returned.
		/// </returns>
		public static DateTime GetNextDateForDay( DateTime startDate, DayOfWeek desiredDay )
		{
			// Given a date and day of week,
			// find the next date whose day of the week equals the specified day of the week.
			return startDate.AddDays( DaysToAdd( startDate.DayOfWeek, desiredDay ) );
		}
	
		/// <summary>
		/// Calculates the number of days to add to the given day of
		/// the week in order to return the next occurrence of the
		/// desired day of the week.
		/// 
		/// http://angstrey.com/index.php/2009/04/25/finding-the-next-date-for-day-of-week/
		/// </summary>
		/// <param name="current">
		///		The starting day of the week.
		/// </param>
		/// <param name="desired">
		///		The desired day of the week.
		/// </param>
		/// <returns>
		///		The number of days to add to <var>current</var> day of week
		///		in order to achieve the next <var>desired</var> day of week.
		/// </returns>
		public static int DaysToAdd( DayOfWeek current, DayOfWeek desired )
		{
			// f( c, d ) = g( c, d ) mod 7, g( c, d ) > 7
			//           = g( c, d ), g( c, d ) < = 7
			//   where 0 <= c < 7 and 0 <= d < 7
	
			int c = (int)current;
			int d = (int)desired;
			int n = (7 - c + d);
	
			return (n > 7) ? n % 7 : n;
		}
	
		#endregion
	}
}
