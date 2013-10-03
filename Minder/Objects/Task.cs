/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.09
 * Time: 22:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Core.Attributes;
using Core.DB;
using Core.Objects;
using Minder.Engine;
using Minder.Engine.Parse;
using Minder.Sql;
using System.ComponentModel;

namespace Minder.Objects
{
	/// <summary>
	/// Description of Task.
	/// </summary>
	[DbTable("TASK")]
    public class Task : ICoreObject, INotifyPropertyChanged
	{
		int m_id = 0;
		string m_text = string.Empty;
		DateTime m_dateRemainder = DateTime.Now;
		string m_sourceId = string.Empty;
		bool m_showed = false;
		DateTime m_lastModifyDate;
		bool m_isDeleted;
		string m_userId = string.Empty;
		string m_lastModifyDateString = string.Empty;
		string m_dateRemainderString = string.Empty;
		
		
		[PrimaryKey("TASK_SEQ"),
		 DBColumnReference("ID"),
		 PropertyCaption("ID", 1, false)]
		public int Id {
			get { return m_id; }
			set { m_id = value; }
		}
		
		[DBColumnReference("SHOWED"),
		 PropertyCaption("Showed", 5)]
		public bool Showed {
			get { return m_showed; }
			set { m_showed = value; 
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("Showed"));
            }
		}
		
		[DBColumnReference("SOURCE_ID"),
		 PropertyCaption("SOURCE_ID", 2, false)]
		public string SourceId {
			get { return m_sourceId; }
			set { m_sourceId = value; }
		}
		
		[DBColumnReference("NAME"),
		 PropertyCaption("Task", 3)]
		public string Text {
			get { return m_text; }
			set { m_text = value; 
             if (PropertyChanged != null)
                 PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
		}
		
		[DBColumnReference("DATE_REMAINDER"),
		 PropertyCaption("Date", 4)]
		public DateTime DateRemainder {
			get { return m_dateRemainder; }
			set { m_dateRemainder = value; 
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("DateRemainder"));
            }
		}
		
		[DBColumnReference("LAST_MODIFY_DATE")]
		public DateTime LastModifyDate {
			get { return m_lastModifyDate; }
			set { m_lastModifyDate = value; }
		}
		
		
		[DBColumnReference("IS_DELETED")]
		public bool IsDeleted {
			get { return m_isDeleted; }
			set { m_isDeleted = value; }
		}
		
		//For sync
		[DBColumnReference("LAST_MODIFY_DATE_STRING")]
		[Obsolete]
		public string LastModifyDateString {
			get { return m_lastModifyDateString; }
			set { m_lastModifyDateString = value; }
		}
		
		//For sync
		[DBColumnReference("DATE_REMAINDER_STRING")]
		[Obsolete]
		public string DateRemainderString {
			get { return m_dateRemainderString; }
			set { m_dateRemainderString = value; }
		}
		
		
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
		
		public Task(string userId) : this()
		{
			m_userId = userId;
		}
		
		public Task()
		{
			m_lastModifyDate = DateTime.Now;
		}
		public void Save()
		{
			this.LastModifyDate = DateTime.Now;
//			this.LastModifyDateString = this.LastModifyDate.ToString();
//			this.DateRemainderString = this.DateRemainder.ToString();
			GenericDbHelper.SaveAndFlush(this);
		}
		
		public static void DeleteAll()
		{
			GenericDbHelper.RunDirectSql("DELETE FROM TASK");
		}
		
		public void Delete()
		{
			this.LastModifyDate = DateTime.Now;
			this.IsDeleted = true;
			GenericDbHelper.UpdateAndFlush(this);
		}
		
		public Task ParseString(string dataEntered)
		{
			if (string.IsNullOrEmpty(dataEntered))
				return null;
			if (TextParser.Parse(dataEntered, out m_dateRemainder, out m_text) == false)
				return null;
			
			this.SourceId = string.Format("{0}{1}{2}", DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss"), m_dateRemainder.ToString("yyyy.MM.dd HH:mm:ss"), m_text);
			
			return this;
		}
		
		public void Update()
		{
			this.LastModifyDate = DateTime.Now;
//			this.LastModifyDateString = this.LastModifyDate.ToString();
//			this.DateRemainderString = this.DateRemainder.ToString();
			GenericDbHelper.UpdateAndFlush(this);
		}
		
		public override int GetHashCode()
		{
			int hashCode = 0;
			
			if (m_text != null)
				hashCode += 1000000009 * m_text.GetHashCode();
			hashCode += 1000000021 * m_dateRemainder.GetHashCode();
			if (m_sourceId != null)
				hashCode += 1000000033 * m_sourceId.GetHashCode();
			hashCode += 1000000087 * m_showed.GetHashCode();
			hashCode += 1000000093 * m_lastModifyDate.GetHashCode();
			hashCode += 1000000097 * m_isDeleted.GetHashCode();
			
			return hashCode;
		}
		
		public override bool Equals(object obj)
		{
			Task other = obj as Task;
			if (other == null)
				return false;
			return this.m_text == other.m_text && this.m_dateRemainder == other.m_dateRemainder && this.m_sourceId == other.m_sourceId && this.m_showed == other.m_showed && this.m_lastModifyDate == other.m_lastModifyDate && this.m_isDeleted == other.m_isDeleted;
		}
		
		public override string ToString()
		{
			return string.Format("[Task Id={0}, Text={1}, DateRemainder={2}]", 
			                     m_id, m_text, DBTypesConverter.ToFullDateStringByCultureInfo(m_dateRemainder));
		}



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
