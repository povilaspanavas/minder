/*
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
		[Test]
		public void TestSaveLoad()
		{
			DateTime now = DateTime.Now;
			Task task = new Task("Darbas", now);
			task.Save();
			using (DBConnection con = new DBConnection())
			{
				SQLiteDataReader reader = con.ExecuteQuery("SELECT NAME, DATE_REMAINDER FROM TASK");
				Assert.IsTrue(reader.Read());
				Assert.AreEqual(task.Text, reader.GetString(0));
				Assert.AreEqual(DBTypesConverter.ToFullDateString(task.DateRemainder), reader.GetString(1));
			}
		}
	}
}
