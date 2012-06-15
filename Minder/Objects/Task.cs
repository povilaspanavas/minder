/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.09
 * Time: 22:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Minder.Sql;

namespace EasyRemainder.Objects
{
	/// <summary>
	/// Description of Task.
	/// </summary>
	public class Task
	{
		int m_id;
		string m_text;
		DateTime m_dateRemainder;
		string m_sourceId;
		
		public string SourceId {
			get { return m_sourceId; }
			set { m_sourceId = value; }
		}
		
		public int Id {
			get { return m_id; }
			set { m_id = value; }
		}
		
		public string Text {
			get { return m_text; }
			set { m_text = value; }
		}
		
		
		public DateTime DateRemainder {
			get { return m_dateRemainder; }
			set { m_dateRemainder = value; }
		}
		
		public Task(int id, string taskText, DateTime remainderDate) : this()
		{
			this.m_id = id;
			this.m_text = taskText;
			this.m_dateRemainder = remainderDate;
		}
		
		public Task(string taskText, DateTime remainderDate, string sourceId) : this(0, taskText, remainderDate)
		{
			this.m_sourceId = sourceId;
		}
		public Task()
		{
			
		}
		public void Save()
		{
			using (DBConnection con = new DBConnection())
			{
				con.ExecuteNonQuery(string.Format("INSERT INTO TASK (NAME, DATE_REMAINDER, SOURCE_ID) " +
				                                  "VALUES('{0}', {1}, '{2}')",
				                                  this.Text, DBTypesConverter.ToFullDateStringWithQuotes(this.DateRemainder),
				                                  this.SourceId));
			}
		}
	}
}
