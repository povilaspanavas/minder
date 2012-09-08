/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.15
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Minder.Objects;
using Minder.Sql;
using NUnit.Framework;

namespace Minder.Tests.DB
{
	[TestFixture]
	public class TestDBConnection
	{
		DateTime now = DateTime.Now;
		
		[TestFixtureSetUp]
		public void InitOnce()
		{
			DBConnection.TestMode = true;
			try
			{
				using (DBConnection con = new DBConnection())
				{
					con.CreateTable();
				}
			} catch (Exception ex) { ex.ToString(); }
		}
		
		[SetUp]
		public void InitEveryTime()
		{
			Task.DeleteAll();
		}
		
		[Test]
		public void TestCreateTable()
		{
			DateTime yesterday = now.AddDays(-1);
			Task task1 = new Task("Pirma", yesterday, "sourceIdPirma");
			task1.Save();
			
			DateTime tomorrow = now.AddDays(1);
			Task task2 = new Task("Antra", tomorrow, "sourceIdAntra");
			task2.Save();
			using (DBConnection con = new DBConnection())
			{
				List<Task> tasks = con.LoadTasksForShowing();
				Assert.AreEqual(1, tasks.Count);
				Assert.AreEqual(task1.Text, tasks[0].Text);
				Assert.AreEqual(task1.SourceId, tasks[0].SourceId);
			}
		}
	}
}
