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
using Minder.Objects;
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
		
		[DBVersion(2, "Adds Task.IsDeleted, Task.LastModifyDate", "2012.09.15 00:43:00")]
		public void Version2()
		{
			GenericDbHelper.RunDirectSql("ALTER TABLE TASK ADD LAST_MODIFY_DATE TEXT");
			GenericDbHelper.RunDirectSql("ALTER TABLE TASK ADD IS_DELETED TEXT");
		}
		
		[DBVersion(3, "Adds Task.LastModifyDateString, Task.DateRemainderString", "2012.09.22 19:17:00")]
		public void Version3()
		{
			GenericDbHelper.RunDirectSql("ALTER TABLE TASK ADD LAST_MODIFY_DATE_STRING TEXT");
			GenericDbHelper.RunDirectSql("ALTER TABLE TASK ADD DATE_REMAINDER_STRING TEXT");
		}
		
		[DBVersion(4, "Copy dates", "2012.09.22 19:28:00")]
		public void Version4()
		{
			GenericDbHelper.RunDirectSql("UPDATE TASK set LAST_MODIFY_DATE_STRING = LAST_MODIFY_DATE, DATE_REMAINDER_STRING = DATE_REMAINDER");
		}
		
		[DBVersion(5, "Add new object Info", "2012.09.30 08:57:00")]
		public void Version5()
		{
			GenericDbHelper.CreateTable(typeof(Info));
		}
		
		[DBVersion(6, "Save new object Info", "2012.09.30 09:06:00")]
		public void Version6()
		{
			Info infoSyncDate = new Info();
			infoSyncDate.UniqueCode = Static.StaticData.InfoUniqueCodes.InfoLastSyncDate;
			infoSyncDate.Value1 = new DateTime(2012, 1, 1).ToString();
			GenericDbHelper.SaveAndFlush(infoSyncDate);
		}
	}
	
}
