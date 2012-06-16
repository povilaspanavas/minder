/*
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
			decimal hours; decimal minutes; string leftText;
			TextParser.Parse("Susitikimas 15min", out hours, out minutes, out leftText);
			Assert.AreEqual(0.0m, hours);
			Assert.AreEqual(15m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 15,5min", out hours, out minutes, out leftText);
			Assert.AreEqual(0.0m, hours);
			Assert.AreEqual(15.5m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 10m", out hours, out minutes, out leftText);
			Assert.AreEqual(0.0m, hours);
			Assert.AreEqual(10m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 10m.", out hours, out minutes, out leftText);
			Assert.AreEqual(0.0m, hours);
			Assert.AreEqual(10m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 20min.", out hours, out minutes, out leftText);
			Assert.AreEqual(0.0m, hours);
			Assert.AreEqual(20m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
		}
		
		[Test]
		public void TestMethod_Only_Hours()
		{
			decimal hours; decimal minutes; string leftText;
			TextParser.Parse("Susitikimas 15val.", out hours, out minutes, out leftText);
			Assert.AreEqual(15.0m, hours);
			Assert.AreEqual(0.0m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 15,5val", out hours, out minutes, out leftText);
			Assert.AreEqual(15.5m, hours);
			Assert.AreEqual(0.0m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 20v.", out hours, out minutes, out leftText);
			Assert.AreEqual(20.0m, hours);
			Assert.AreEqual(0.0m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 20v", out hours, out minutes, out leftText);
			Assert.AreEqual(20.0m, hours);
			Assert.AreEqual(0.0m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 10h.", out hours, out minutes, out leftText);
			Assert.AreEqual(10.0m, hours);
			Assert.AreEqual(0.0m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 10h", out hours, out minutes, out leftText);
			Assert.AreEqual(10.0m, hours);
			Assert.AreEqual(0.0m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
		}
		
		[Test]
		public void TestMethod_Hours_Minutes()
		{
			decimal hours; decimal minutes; string leftText;
			TextParser.Parse("Susitikimas 15val.20min", out hours, out minutes, out leftText);
			Assert.AreEqual(15.0m, hours);
			Assert.AreEqual(20.0m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
			
			TextParser.Parse("Susitikimas 15v 20m", out hours, out minutes, out leftText);
			Assert.AreEqual(15.0m, hours);
			Assert.AreEqual(20.0m, minutes);
			Assert.AreEqual("Susitikimas", leftText);
		}
	}
}
