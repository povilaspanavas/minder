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
using Minder.Engine;
using Minder.Sql;

namespace Minder.Objects
{
	/// <summary>
	/// Description of Task.
	/// </summary>
	public class Task
	{
		int m_id = 0;
		string m_text = string.Empty;
		DateTime m_dateRemainder = DateTime.MinValue;
		string m_sourceId = string.Empty;
		bool m_showed = false;
		
		public bool Showed {
			get { return m_showed; }
			set { m_showed = value; }
		}
		
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
			using (DBConnection con = new DBConnection())
			{
				con.ExecuteNonQuery(string.Format("INSERT INTO TASK (NAME, DATE_REMAINDER, SOURCE_ID, SHOWED) " +
				                                  "VALUES('{0}', {1}, '{2}', {3})",
				                                  this.Text, DBTypesConverter.ToFullDateStringWithQuotes(this.DateRemainder),
				                                  this.SourceId, this.Showed ? 1 : 0));
			}
		}
		
		public static void DeleteAll()
		{
			using (DBConnection con = new DBConnection())
			{
				con.ExecuteNonQuery("DELETE FROM TASK");
			}
		}
		
		public void Delete()
		{
			if (m_id == 0)
				return;
			using (DBConnection con = new DBConnection())
			{
				con.ExecuteNonQuery("DELETE FROM TASK WHERE ID = " + m_id);
			}
		}
		
		public Task ParseString(string dataEntered)
		{
			if (string.IsNullOrEmpty(dataEntered))
				return null;
			this.SourceId = dataEntered;

			if (TextParser.Parse(dataEntered, out m_dateRemainder, out m_text) == false)
				return null;
			return this;
		}
		
		public void Update()
		{
			if (m_id == 0)
				return;
			using (DBConnection con = new DBConnection())
			{
				con.ExecuteNonQuery(string.Format("UPDATE TASK SET NAME = '{0}', DATE_REMAINDER = {1}, SOURCE_ID = '{2}', " +
				                                  "SHOWED = {3} WHERE ID = {4}",
				                                  this.Text, DBTypesConverter.ToFullDateStringWithQuotes(this.DateRemainder),
				                                  this.SourceId, (this.Showed ? 1 : 0), m_id));
			}
		}
	}
}
