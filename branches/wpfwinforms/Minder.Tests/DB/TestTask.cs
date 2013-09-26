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
using Core;
using Core.DB;
using Core.DB.Connections;
using Minder.Objects;
using Minder.Sql;
using NUnit.Framework;

namespace Minder.Tests.DB
{

	[TestFixture]
	public class TestTask
	{
		[TestFixtureSetUp]
		public void InitOnce()
		{
			ConfigLoader.Load(@"CoreConfig.xml");
//			DbHelper.TestMode = true;
			try
			{
				using (IConnection con = new ConnectionCollector().GetConnection())
				{
					GenericDbHelper.DropAllTables();
					new DbHelper().CreateTable();
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
			
		}
		
		[Test]
		public void TestSave()
		{
			DateTime now = DateTime.Now;
			Task task = new Task("Darbas", now, "sourceId|15");
			task.Save();
			using (IConnection con = new ConnectionCollector().GetConnection())
			{
				IDataReader reader = con.ExecuteReader("SELECT NAME, DATE_REMAINDER, SOURCE_ID, SHOWED FROM TASK");
				Assert.IsTrue(reader.Read());
				Assert.AreEqual(task.Text, reader.GetString(0));
				Assert.AreEqual(DBTypesConverter.ToFullDateStringByCultureInfo(task.DateRemainder), reader.GetString(1));
				Assert.AreEqual(task.SourceId, reader.GetString(2));
				Assert.AreEqual(0, reader.GetInt32(3));
			}
		}
		
		[Ignore("ID automatiškai neužsisetina į objektą, tai neina paprstai update pdaryti")]
		[Test]
		public void TestUpdate()
		{
			DateTime now = DateTime.Now;
			Task task = new Task("Darbas", now, "sourceId|15");
			task.Save();
			
			task.DateRemainder = now.AddYears(1);
			task.Text = "Krabas";
			task.Showed = true;
			task.SourceId = "skriptas";
			task.Update();
			
			using (IConnection con = new ConnectionCollector().GetConnection())
			{
				IDataReader reader = con.ExecuteReader("SELECT NAME, DATE_REMAINDER, SOURCE_ID, SHOWED FROM TASK");
				Assert.IsTrue(reader.Read());
				Assert.AreEqual(task.Text, reader.GetString(0));
				Assert.AreEqual(DBTypesConverter.ToFullDateStringByCultureInfo(task.DateRemainder), reader.GetString(1));
				Assert.AreEqual(task.SourceId, reader.GetString(2));
				Assert.AreEqual(1, reader.GetInt32(3));
			}
		}
		
		[Test]
		public void TestDelete()
		{
			Task task = new Task("Darbas", DateTime.Now, "sourceId|15");
			task.Save();
			task.Delete();
			
			using (IConnection con = new ConnectionCollector().GetConnection())
			{
				IDataReader reader = con.ExecuteReader("SELECT NAME, DATE_REMAINDER, SOURCE_ID FROM TASK");
				Assert.IsTrue(reader.Read());
			}
		}
		
		[Test]
		public void TestDeleteAll()
		{
			Task task1 = new Task("Darbas", DateTime.Now, "sourceId|15");
			task1.Save();
			Task task2 = new Task("Darbas2", DateTime.Now, "sourceId|15");
			task2.Save();
			Task.DeleteAll();
		}
		
		[Test]
		public void TestLoadTasksForShowing()
		{
			Task task1 = new Task("Darbas", DateTime.Now.AddSeconds(-1), "sourceId|sekundė-1");
			task1.Save();
			Task task2 = new Task("Darbas2", DateTime.Now.AddMonths(-1), "sourceId|mėnuo-1");
			task2.Save();
			Task task3 = new Task("Darbas3", DateTime.Now.AddMinutes(1), "sourceId|mintė+1");
			task3.Save();
			
			using (IConnection con = new ConnectionCollector().GetConnection())
			{
				List<Task> tasks = new DbHelper().LoadTasksForShowing();
				Assert.AreEqual(2, tasks.Count);
			}
		}
	}
}
