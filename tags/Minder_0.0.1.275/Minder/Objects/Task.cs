/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.09
 * Time: 22:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
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
	public class Task : ICoreObject
	{
		int m_id = 0;
		string m_text = string.Empty;
		DateTime m_dateRemainder = DateTime.MinValue;
		string m_sourceId = string.Empty;
		bool m_showed = false;
		
		[DBColumnReference("SHOWED")]
		public bool Showed {
			get { return m_showed; }
			set { m_showed = value; }
		}
		
		[DBColumnReference("SOURCE_ID")]
		public string SourceId {
			get { return m_sourceId; }
			set { m_sourceId = value; }
		}
		
		[PrimaryKey("TASK_SEQ"), 
		 DBColumnReference("ID")]
		public int Id {
			get { return m_id; }
			set { m_id = value; }
		}
		
		[DBColumnReference("NAME")]
		public string Text {
			get { return m_text; }
			set { m_text = value; }
		}
		
		[DBColumnReference("DATE_REMAINDER")]
		public DateTime DateRemainder {
			get { return m_dateRemainder; }
			set { m_dateRemainder = value; }
		}
		
		DateTime m_lastModifyDate;
		
		[DBColumnReference("LAST_MODIFY_DATE")]
		public DateTime LastModifyDate {
			get { return m_lastModifyDate; }
			set { m_lastModifyDate = value; }
		}
		
		bool m_isDeleted;
		
		[DBColumnReference("IS_DELETED")]
		public bool IsDeleted {
			get { return m_isDeleted; }
			set { m_isDeleted = value; }
		}
		
		string m_userId = string.Empty;
		
		//Not from/to db, only for sync
		public string UserId {
			get { return m_userId; }
			set { m_userId = value; }
		}
		
		public Task(int id, string taskText, DateTime remainderDate, string sourceId) : this()
		{
			this.m_id = id;
			this.m_text = taskText;
			this.m_dateRemainder = remainderDate;
			this.m_sourceId = sourceId;
		}
		
		public Task(string taskText, DateTime remainderDate, string sourceId) : this(0, taskText, remainderDate, sourceId)
		{
		}
		
		/// <summary>
		/// Really no sourceID? use for tests only
		/// </summary>
		/// <param name="taskText"></param>
		/// <param name="remainderDate"></param>
		public Task(string taskText, DateTime remainderDate) : this(0, taskText, remainderDate, string.Empty)
		{
			
		}
		
		public Task()
		{
			
		}
		public void Save()
		{
			this.LastModifyDate = DateTime.Now;
			GenericDbHelper.SaveAndFlush(this);
		}
		
		public static void DeleteAll()
		{
			GenericDbHelper.RunDirectSql("DELETE FROM TASK");
		}
		
		public void Delete()
		{
			this.IsDeleted = true;
			GenericDbHelper.UpdateAndFlush(this);
		}
		
		public Task ParseString(string dataEntered)
		{
			if (string.IsNullOrEmpty(dataEntered))
				return null;
			if (TextParser.Parse(dataEntered, out m_dateRemainder, out m_text) == false)
				return null;
			
			this.SourceId = string.Format("{0}{1}{2}", DateTime.Now, m_dateRemainder, m_text);
			
			return this;
		}
		
		public void Update()
		{
			this.LastModifyDate = DateTime.Now;
			GenericDbHelper.UpdateAndFlush(this);
		}
		
		public string Table {
			get {
				return "TASK";
			}
		}
	}
}
