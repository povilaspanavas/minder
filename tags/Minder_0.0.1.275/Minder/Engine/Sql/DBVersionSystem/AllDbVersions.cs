/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.09.15
 * Time: 00:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.DB;
using Minder.Sql.DBVersionSystem;

namespace Minder.Engine.Sql.DBVersionSystem
{
	[DBHistory]
	public class AllDbVersions
	{
		[DBVersion(1, "Adds DBVersion's table", "2012.09.15 00:16:00")]
		public void Version1()
		{
			GenericDbHelper.RunDirectSql("CREATE TABLE Minder.DB_VERSION (ID INTEGER PRIMARY KEY, VERSION_NR INTEGER NOT NULL, " +
			                             "DATE_VERSION TEXT, COMMENT TEXT)");
		}
	}
}
