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
using Minder.Static;
using NUnit.Framework;
using Minder.Engine;

namespace Minder.Tests.Logic
{
	[TestFixture]
	public class TestTextParserCultureDataUk
	{
		private ICultureData m_initialCultureInfo = null;
		
		[TestFixtureSetUp]
		public void ChangeCulture()
		{
			m_initialCultureInfo = StaticData.Settings.CultureData;
			StaticData.Settings.CultureData = new CultureDataUK();
			TextParser.CultureData = StaticData.Settings.CultureData;
		}
		
		[TestFixtureTearDown]
		public void RestoreCulture()
		{
			TextParser.CultureData = m_initialCultureInfo;
			StaticData.Settings.CultureData = m_initialCultureInfo;
		}
		
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
			Assert.IsFalse(TextParser.Parse("Susitikimas 15val.", out date, out leftText));
//			Assert.AreEqual(now.AddHours(15).AddMinutes(0).ToShortDateString(), date.ToShortDateString());
//			Assert.AreEqual(now.AddHours(15).AddMinutes(0).ToShortTimeString(), date.ToShortTimeString());
//			Assert.AreEqual("Susitikimas", leftText);
			
			Assert.IsFalse(TextParser.Parse("Susitikimas 15,5val", out date, out leftText));
			Assert.AreEqual(now.AddHours(15.5).AddMinutes(0).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(15.5).AddMinutes(0).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			Assert.IsFalse(TextParser.Parse("Susitikimas 20v.", out date, out leftText));
			Assert.AreEqual(now.AddHours(20).AddMinutes(0).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(20).AddMinutes(0).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			Assert.IsFalse(TextParser.Parse("Susitikimas 20v", out date, out leftText));
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
			Assert.IsTrue(TextParser.Parse("Susitikimas 15h.20min", out date, out leftText));
			Assert.AreEqual(now.AddHours(15).AddMinutes(20).ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(now.AddHours(15).AddMinutes(20).ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			Assert.IsTrue(TextParser.Parse("Susitikimas 15h 20m", out date, out leftText));
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
			Assert.IsTrue(TextParser.Parse("Susitikimas 01/06/2012 15:20", out date, out leftText));
			Assert.AreEqual(dateRemind.ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(dateRemind.ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			dateRemind = new DateTime(2012, 06, 01, 15, 20, 10);
			Assert.IsTrue(TextParser.Parse("Susitikimas 01-06-2012 15:20:10", out date, out leftText));
			Assert.AreEqual(dateRemind.ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(dateRemind.ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
			
			dateRemind = new DateTime(2012, 06, 02, 15, 20, 10);
			Assert.IsTrue(TextParser.Parse("Susitikimas 02/06 15:20:10", out date, out leftText));
			Assert.AreEqual(dateRemind.ToShortDateString(), date.ToShortDateString());
			Assert.AreEqual(dateRemind.ToShortTimeString(), date.ToShortTimeString());
			Assert.AreEqual("Susitikimas", leftText);
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
			Assert.IsTrue(TextParser.Parse("Susitikimas po 5h 4h.", out date, out leftText));
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
			Assert.IsFalse(TextParser.Parse("Susitikimas po 15ha", out date, out leftText));
		}
		
		[Test]
		public void Test_BugFix_Too_Large_Int()
		{
			DateTime date; string leftText;
			Assert.IsFalse(TextParser.Parse("Susitikimas po 131456313256131654651321m", out date, out leftText));
			Assert.IsFalse(TextParser.Parse("Susitikimas po 131456313256131654651321h", out date, out leftText));
			Assert.IsFalse(TextParser.Parse("Susitikimas po 131456313256131654651321h.", out date, out leftText));
		}
	}
}
