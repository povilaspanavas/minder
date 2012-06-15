﻿/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.15
 * Time: 13:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.SQLite;
using EasyRemainder.Objects;
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
			try
			{
				using (DBConnection con = new DBConnection())
				{
					con.CreateTable();
				}
			} catch {}
		}
		
		[SetUp]
		public void InitEveryTime()
		{
			Task.DeleteAll();
		}
		
		[Test]
		public void TestSave()
		{
			DateTime now = DateTime.Now;
			Task task = new Task("Darbas", now, "sourceId|15");
			task.Save();
			using (DBConnection con = new DBConnection())
			{
				SQLiteDataReader reader = con.ExecuteQuery("SELECT NAME, DATE_REMAINDER, SOURCE_ID FROM TASK");
				Assert.IsTrue(reader.Read());
				Assert.AreEqual(task.Text, reader.GetString(0));
				Assert.AreEqual(DBTypesConverter.ToFullDateString(task.DateRemainder), reader.GetString(1));
				Assert.AreEqual(task.SourceId, reader.GetString(2));
			}
		}
		
		[Test]
		public void TestDelete()
		{
			Task task = new Task("Darbas", DateTime.Now, "sourceId|15");
			task.Save();
			task.Delete();
			
			using (DBConnection con = new DBConnection())
			{
				SQLiteDataReader reader = con.ExecuteQuery("SELECT NAME, DATE_REMAINDER, SOURCE_ID FROM TASK");
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
	}
}
