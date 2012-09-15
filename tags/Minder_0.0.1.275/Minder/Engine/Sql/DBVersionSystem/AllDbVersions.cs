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
		public void Version()
		{
			GenericDbHelper.RunDirectSql("CREATE TABLE DB_VERSION (ID INTEGER PRIMARY KEY, VERSION_NR INTEGER NOT NULL, " +
			                             "DATE_VERSION TEXT, COMMENT TEXT)");
		}
		
		[DBVersion(2, "Adds Task.IsDeleted, Task.LastModifyDate.", "2012.09.15 00:43:00")]
		public void Version2()
		{
			GenericDbHelper.RunDirectSql("ALTER TABLE TASK ADD LAST_MODIFY_DATE TEXT");
			GenericDbHelper.RunDirectSql("ALTER TABLE TASK ADD IS_DELETED TEXT");
		}
	}
	
}
