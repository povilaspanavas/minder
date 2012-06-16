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
	}
}
