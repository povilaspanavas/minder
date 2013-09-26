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
using Minder.Engine.Sql.DBVersionSystem;
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
			                             "COMMENT VARCHAR(255))");
			GenericDbHelper.RunDirectSql("INSERT INTO TROL_TEST (VERSION_NR, COMMENT) VALUES (5, \"Komentaras\")");
		}
	}
	
	[TestFixture]
	public class TestDBVersionSystem
	{
		[TestFixtureSetUp]
		public void InitOnce()
		{
			ConfigLoader.Load(@"CoreConfig.xml");
			try {
				GenericDbHelper.DropAllTables();
				new AllDbVersions().Version();
			}
			catch {}
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
			new DBVersionSystem(new DBVersionRepository().AddVersions(typeof(TestDBVersionsFile).Assembly)).UpdateToNewest();
			using (IConnection con = new ConnectionCollector().GetConnection())
			{
				// DB Version was executed?
				IDataReader reader = con.ExecuteReader("SELECT COUNT(*) FROM TROL_TEST");
				Assert.IsTrue(reader.Read());
				Assert.AreEqual(1, reader.GetInt32(0));
				
				// Version number was written?
				Assert.AreEqual(1, DBVersionSystem.GetCurrentVersion());
				
				// DB version information is written corretly (was bug, which duplicated lines)
				reader = con.ExecuteReader("SELECT COUNT(*) FROM DB_VERSION");
				Assert.IsTrue(reader.Read());
				Assert.AreEqual(1, reader.GetInt32(0));
			}
		}
	}
}
