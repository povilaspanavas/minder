/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.15
 * Time: 15:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Minder.Engine;
using Minder.Objects;
using NUnit.Framework;

namespace Minder.Tests
{
	[TestFixture]
	public class TestTaskController
	{
		[Test]
		public void TestParseMinutes()
		{
			Task task = new Task().ParseString("Parodyk pranešimą|15");
			Assert.AreEqual("Parodyk pranešimą", task.Text);
			Assert.AreEqual(task.DateRemainder.ToShortDateString(), task.DateRemainder.ToShortDateString());
			Assert.AreEqual(task.DateRemainder.ToShortTimeString(), task.DateRemainder.ToShortTimeString());
		}
	}
}
