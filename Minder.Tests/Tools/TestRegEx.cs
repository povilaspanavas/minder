/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.16
 * Time: 12:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text.RegularExpressions;
using Minder.Engine;
using Minder.Engine.Parse;
using NUnit.Framework;

namespace Minder.Tests.Tools
{
	[TestFixture]
	public class TestRegEx
	{
		[Test]
		public void TestMethod()
		{
			Assert.AreEqual("15m", Regex.Match("Nupirkti pieno 15m", @"\d*m$").Value);
			Assert.AreEqual("5m", Regex.Match("Nupirkti pieno 5m", @"\d*m$").Value);
			Assert.AreEqual("1234min", Regex.Match("Nupirkti pieno 1234min", @"\d*min$").Value);
			Assert.AreEqual("2m", Regex.Match("Nupirkti pieno 2m", @"\d*m$").Value);
			
			// Turi būti gale
			Assert.IsFalse(Regex.IsMatch("Nupirkti pieno 15m blabla", @"\d*m$"));
			Assert.IsFalse(Regex.IsMatch("Nupirkti pieno 15m blabla", @"\d*m$"));
			
			// Parenkamas iš galo jei yra du
			Assert.AreEqual("21m", Regex.Match("Nupirkti pieno 15m blabla 21m", @"\d*m$").Value);
			
			// Viena paieška visiems variantams
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 15m", @"\d*(m|m.|min|min.)$"));
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 15min", @"\d*(m|m.|min|min.)$"));
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 15min.", @"\d*(m|m.|min|min.)$"));
			
			// Su kablialiu
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 15min.", @"\b\d*(m|m.|min|min.)$"));
			Assert.AreEqual("15,5min.", Regex.Match("Nupirkti pieno 15,5min.", @"\b\d*[,]\d*(m|m.|min|min.)$").Value);
			Assert.AreEqual("15min.", Regex.Match("Nupirkti pieno 15min.", @"\b\d*[,]{0,1}\d*(m|m.|min|min.)$").Value);
		}
		
		[Test]
		public void TestTime()
		{
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 15:10:01", CultureDataLt.TIME_STRING));
			Assert.AreEqual("15:10:01", Regex.Match("Nupirkti pieno 15:10:01", CultureDataLt.TIME_STRING).Value);
			
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 15:10", CultureDataLt.TIME_STRING));
			Assert.AreEqual("15:10", Regex.Match("Nupirkti pieno 15:10", CultureDataLt.TIME_STRING).Value);
			
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 5:1", CultureDataLt.TIME_STRING));
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 5:1:3", CultureDataLt.TIME_STRING));
			
		}
		
		[Test]
		public void TestDateAndTime()
		{
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 06.11 15:30", CultureDataLt.DATE_TIME_STRING));
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 06\\11 15:30", CultureDataLt.DATE_TIME_STRING));
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 06-11 15:30", CultureDataLt.DATE_TIME_STRING));
			
			Assert.AreEqual("06.11 15:30", Regex.Match("Nupirkti pieno 06.11 15:30", CultureDataLt.DATE_TIME_STRING).Value);
			
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 2012.06.11 15:30:10", CultureDataLt.DATE_TIME_STRING));
			Assert.AreEqual("2012.06.11 15:30:10", Regex.Match("Nupirkti pieno 2012.06.11 15:30:10",  CultureDataLt.DATE_TIME_STRING).Value);
			
			Assert.IsTrue(Regex.IsMatch("Nupirkti pieno 2012-06-11 15:30:10", CultureDataLt.DATE_TIME_STRING));
			Assert.AreEqual("2012-06-11 15:30:10", Regex.Match("Nupirkti pieno 2012-06-11 15:30:10",  CultureDataLt.DATE_TIME_STRING).Value);
		
		}
		
		[Test]
		public void TestNormalMinutesParsing()
		{
//			string pattern = @"\b\d*[,]{0,1}\d*((min.)\b)|(min\b)|(m.\b))";
			string pattern = @"\b\d*[,]{0,1}\d*((min\.)|(min\b)|(m\.)|(m\b))";
			string text = "Nupirkti pieno 15m.";
			Assert.IsTrue(Regex.IsMatch(text, pattern));
			Assert.AreEqual(1, Regex.Matches(text, pattern).Count);
			Assert.AreEqual("15m.", Regex.Match(text, pattern).Value);
			
			text = "Nupirkti pieno 15min.";
			Assert.IsTrue(Regex.IsMatch(text, pattern));
			Assert.AreEqual("15min.", Regex.Match(text, pattern).Value);
			
			text = "Nupirkti pieno 15mi";
			Match match = Regex.Match(text, pattern);
			Assert.IsFalse(Regex.IsMatch(text, pattern));
		}
		
	}
}
