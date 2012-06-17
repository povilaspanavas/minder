﻿/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.16
 * Time: 17:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using Minder.Engine;

namespace Minder.Tests.Logic
{
	[TestFixture]
	public class TestTextParser
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
			
		}
	}
}
