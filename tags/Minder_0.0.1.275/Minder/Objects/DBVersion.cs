using System;
using System.Text.RegularExpressions;
using Core.Attributes;
using Core.DB;
using Core.Objects;
using Minder.Engine;
using Minder.Engine.Parse;
using Minder.Sql;

namespace Minder.Objects
{
	/// <summary>
	/// Description of Task.
	/// </summary>
	[DbTable("DB_VERSION")]
	public class DBVersion : ICoreObject
	{
		int m_id = 0;
		int m_versionNr = 0;
		string m_comment = string.Empty;
		DateTime m_date = DateTime.MinValue;
		
		[PrimaryKey("DBVERSION_SEQ"), 
		 DBColumnReference("ID")]
		public int Id {
			get { return m_id; }
			set { m_id = value; }
		}
		
		[DBColumnReference("COMMENT")]
		public string Comment {
			get { return m_comment; }
			set { m_comment = value; }
		}
		
		[DBColumnReference("DATE_VERSION")]
		public DateTime Date {
			get { return m_date; }
			set { m_date = value; }
		}
		
		[DBColumnReference("VERSION_NR")]
		public int VersionNr {
			get { return m_versionNr; }
			set { m_versionNr = value; }
		}
		
		public DBVersion(int id, int versionNr, string description, DateTime date) : this()
		{
			this.m_id = id;
			this.m_versionNr = versionNr;
			this.m_comment = description;
			this.m_date = date;
		}
		
		public DBVersion(int versionNr, string taskText, DateTime date) : this(0, versionNr, taskText, date)
		{
		}
		
		public DBVersion()
		{
			
		}
		
		public void Save()
		{
			GenericDbHelper.SaveAndFlush(this);
		}
		
		public static void DeleteAll()
		{
			GenericDbHelper.RunDirectSql("DELETE FROM DB_VERSION");
		}
		
		public void Delete()
		{
			GenericDbHelper.DeleteAndFlush(this);
		}
		
		public void Update()
		{
			GenericDbHelper.UpdateAndFlush(this);
		}
	}
}
