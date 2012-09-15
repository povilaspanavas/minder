/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.09.15
 * Time: 00:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using Core;
using Core.DB;
using Core.DB.Connections;
using Minder.Objects;
using Minder.Sql;
using Minder.Sql.DBVersionSystem;
using NUnit.Framework;

namespace Minder.Tests.DB
{
	[DBHistory]
	public class TestDBVersionsFile
	{
		[DBVersion(1, "Adds DBVersion's table", "2012.09.15 00:16:00")]
		public void Version()
		{
			GenericDbHelper.RunDirectSql("CREATE TABLE TROL_TEST (ID INTEGER PRIMARY KEY, VERSION_NR INTEGER NOT NULL, " +
			                             "COMMENT TEXT)");
			GenericDbHelper.RunDirectSql("INSERT TROL_TEST (VERSION_NR, COMMENT) VALUES (5, '2011.10.10', 'Komentaras')");
		}
	}
	
	[TestFixture]
	public class TestDBVersionSystem
	{
		[TestFixtureSetUp]
		public void InitOnce()
		{
			ConfigLoader.Load(@"c:\Dokumentai\Projektai\Minder1\Minder.Tests\bin\Debug\CoreConfig.xml");
//			DbHelper.TestMode = true;
			try
			{
				using (IConnection con = new ConnectionCollector().GetConnection())
				{
					new DbHelper().CreateTable();
				}
			} catch (Exception ex) { ex.ToString(); }
		}
		
		[Test]
		public void TestCollectsAllVersionsFromAssembly()
		{
			DBVersionRepository repo = new DBVersionRepository()
				.AddVersions(typeof(TestDBVersionSystem).Assembly)
				;
			Assert.AreEqual(1, repo.VersionsTable.Count);
		}
		
		[Test]
		public void TestExecutesDBVersions()
		{
			DBVersionRepository repo = new DBVersionRepository()
				.AddVersions(typeof(TestDBVersionSystem).Assembly)
				;
			
			new DBVersionSystemRunner().ExecuteUpdateToDB(repo);
			using (IConnection con = new ConnectionCollector().GetConnection())
			{
				IDataReader reader = con.ExecuteReader("SELECT COUNT(*) FROM TROL_TEST");
				Assert.IsTrue(reader.Read());
				Assert.AreEqual(1, reader.GetInt32(0));
			}
		}
	}
}
