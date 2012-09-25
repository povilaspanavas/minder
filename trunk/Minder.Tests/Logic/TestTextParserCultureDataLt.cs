/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.16
 * Time: 17:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Minder.Engine.Parse;
using NUnit.Framework;
using Minder.Engine;

namespace Minder.Tests.Logic.Cultures
{
	[TestFixture]
	public class TestTextParserCultureDataLt
	{
		[Test]
		public void TestMethod_Only_Minutes()
		{
			DateTime now = DateTime.Now;
			DateTime date; string leftText;
			Assert.IsTrue(TextParser.Parse("Susitikimas 15min", out date, out leftText));
			Assert.AreEqual(now.AddHours(0).AddMinutes(15).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(0).AddMinutes(15).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 15,5min", out date, out leftText);
			Assert.AreEqual(now.AddHours(0).AddMinutes(15.5).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(0).AddMinutes(15.5).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 10m", out date, out leftText);
			Assert.AreEqual(now.AddHours(0).AddMinutes(10).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(0).AddMinutes(10).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 10m.", out date, out leftText);
			Assert.AreEqual(now.AddHours(0).AddMinutes(10).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(0).AddMinutes(10).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 20min.", out date, out leftText);
			Assert.AreEqual(now.AddHours(0).AddMinutes(20).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(0).AddMinutes(20).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
		}
		
		[Test]
		public void TestMethod_Only_Minutes_Debug()
		{
			DateTime now = DateTime.Now;
			DateTime date; string leftText;
			TextParser.Parse("Susitikimas 10m.", out date, out leftText);
			Assert.AreEqual(now.AddHours(0).AddMinutes(10).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(0).AddMinutes(10).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
		}
		
		[Test]
		public void TestMethod_Only_Hours()
		{
			DateTime now = DateTime.Now;
			DateTime date; string leftText;
			TextParser.Parse("Susitikimas 15val.", out date, out leftText);
			Assert.AreEqual(now.AddHours(15).AddMinutes(0).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(15).AddMinutes(0).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 15,5val", out date, out leftText);
			Assert.AreEqual(now.AddHours(15.5).AddMinutes(0).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(15.5).AddMinutes(0).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 20v.", out date, out leftText);
			Assert.AreEqual(now.AddHours(20).AddMinutes(0).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(20).AddMinutes(0).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 20v", out date, out leftText);
			Assert.AreEqual(now.AddHours(20).AddMinutes(0).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(20).AddMinutes(0).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 10h.", out date, out leftText);
			Assert.AreEqual(now.AddHours(10).AddMinutes(0).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(10).AddMinutes(0).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 10h", out date, out leftText);
			Assert.AreEqual(now.AddHours(10).AddMinutes(0).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(10).AddMinutes(0).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
		}
		
		[Test]
		public void TestMethod_Hours_Minutes()
		{
			DateTime now = DateTime.Now;
			DateTime date; string leftText;
			Assert.IsTrue(TextParser.Parse("Susitikimas 15val.20min", out date, out leftText));
			Assert.AreEqual(now.AddHours(15).AddMinutes(20).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(15).AddMinutes(20).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			Assert.IsTrue(TextParser.Parse("Susitikimas 15v 20m", out date, out leftText));
			Assert.AreEqual(now.AddHours(15).AddMinutes(20).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(15).AddMinutes(20).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
		}
		
		[Test]
		public void TestMethod_Time()
		{
			DateTime now = DateTime.Now;
			DateTime dateRemind = new DateTime(now.Year, now.Month, now.Day, 15, 20, 0);
			DateTime date; string leftText;
			Assert.IsTrue(TextParser.Parse("Susitikimas 15:20", out date, out leftText));
			Assert.AreEqual(dateRemind.ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(dateRemind.ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
		}
		
		[Test]
		public void TestMethod_Date_Time()
		{
			DateTime now = DateTime.Now;
			DateTime dateRemind = new DateTime(2012, 06, 01, 15, 20, 0);
			DateTime date; string leftText;
			Assert.IsTrue(TextParser.Parse("Susitikimas 2012.06.01 15:20", out date, out leftText));
			Assert.AreEqual(dateRemind.ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(dateRemind.ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			dateRemind = new DateTime(2012, 06, 01, 15, 20, 10);
			Assert.IsTrue(TextParser.Parse("Susitikimas 2012-06-01 15:20:10", out date, out leftText));
			Assert.AreEqual(dateRemind.ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(dateRemind.ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			dateRemind = new DateTime(2012, 06, 02, 15, 20, 10);
			Assert.IsTrue(TextParser.Parse("Susitikimas 06.02 15:20:10", out date, out leftText));
			Assert.AreEqual(dateRemind.ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(dateRemind.ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
		}
		
		[Test]
		public void Test_Time_And_Tomorrowe()
		{
			DateTime now = DateTime.Now;
			DateTime dateRemind = new DateTime(now.Year, now.Month, now.Day, 10, 05, 00).AddDays(1);
			DateTime date; string leftText;
			Assert.IsTrue(TextParser.Parse("Susitikimas ryt 10:05", out date, out leftText));
			Assert.AreEqual("Susitikimas", leftText);
			Assert.AreEqual(dateRemind.ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(dateRemind.ToShortTimeString(), date.ToShortTimeString());
			
			// Nepalaikoma, nes data prieš laiką turėtų eiti
			Assert.IsFalse(TextParser.Parse("Susitikimas 10:05 ryt", out date, out leftText));
		}
		
		[Test]
		public void Test_Tommorow_Twice()
		{
			DateTime now = DateTime.Now;
			DateTime dateRemind = new DateTime(now.Year, now.Month, now.Day, 12, 20, 00).AddDays(1);
			DateTime date; string leftText;
			Assert.IsTrue(TextParser.Parse("Susitikimas ryt po ryt 12:20", out date, out leftText));
			Assert.AreEqual("Susitikimas ryt po", leftText);
			Assert.AreEqual(dateRemind.ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(dateRemind.ToShortTimeString(), date.ToShortTimeString());
		}
		
		[Test]
		public void Test_Minutes_Twice()
		{
			DateTime dateRemind = DateTime.Now.AddMinutes(20);
			DateTime date; string leftText;
			Assert.IsTrue(TextParser.Parse("Susitikimas po 40min 20m", out date, out leftText));
			Assert.AreEqual(dateRemind.ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(dateRemind.ToShortTimeString(), date.ToShortTimeString());
		}
		
		[Test]
		public void Test_Hours_Twice()
		{
			DateTime dateRemind = DateTime.Now.AddHours(4);
			DateTime date; string leftText;
			Assert.IsTrue(TextParser.Parse("Susitikimas po 5h 4val.", out date, out leftText));
			Assert.AreEqual(dateRemind.ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(dateRemind.ToShortTimeString(), date.ToShortTimeString());
		}
		
		[Test]
		public void Test_BugFix_Minutes_15mi()
		{
			DateTime date; string leftText;
			Assert.IsFalse(TextParser.Parse("Susitikimas po 15mi", out date, out leftText));
		}
		
		[Test]
		public void Test_BugFix_Minutes_15va()
		{
			DateTime date; string leftText;
			Assert.IsFalse(TextParser.Parse("Susitikimas po 15va", out date, out leftText));
		}
		
		[Test]
		public void Test_BugFix_Too_Large_Int()
		{
			DateTime date; string leftText;
			Assert.IsFalse(TextParser.Parse("Susitikimas po 131456313256131654651321m", out date, out leftText));
			Assert.IsFalse(TextParser.Parse("Susitikimas po 131456313256131654651321v", out date, out leftText));
			Assert.IsFalse(TextParser.Parse("Susitikimas po 131456313256131654651321val.", out date, out leftText));
		}
		
		[Test]
		public void Test_BugFix_Minutes_m_h_v()
		{
			DateTime date; string leftText;
			Assert.IsFalse(TextParser.Parse("Susitikimas po m", out date, out leftText));
			Assert.IsFalse(TextParser.Parse("Susitikimas po min.", out date, out leftText));
			Assert.IsFalse(TextParser.Parse("Susitikimas po h", out date, out leftText));
			Assert.IsFalse(TextParser.Parse("Susitikimas po h.", out date, out leftText));
			Assert.IsFalse(TextParser.Parse("Susitikimas po v", out date, out leftText));
			Assert.IsFalse(TextParser.Parse("Susitikimas po v.", out date, out leftText));
			Assert.IsFalse(TextParser.Parse("Susitikimas po val.", out date, out leftText));
		}
	}
}
