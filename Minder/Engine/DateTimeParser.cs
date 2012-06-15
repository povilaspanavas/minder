/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.09
 * Time: 23:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Minder.Engine
{
	/// <summary>
	/// Description of DateTimeParser.
	/// </summary>
	public class DateTimeParser
	{
		string originalDateTime;
		
		public string OriginalDateTime {
			get { return originalDateTime; }
			set { originalDateTime = value; }
		}
		
		string leftText;
		
		public string LeftText {
			get { return leftText; }
			set { leftText = value; }
		}
		
		public DateTime ParseDateTime(ref string text)
		{
			return DateTime.Now;
		}
	}
}
