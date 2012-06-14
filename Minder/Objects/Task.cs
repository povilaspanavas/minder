/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.09
 * Time: 22:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

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
		
//		string m_originalDateTime;
//		
//		public string OriginalDateTime {
//			get { return m_originalDateTime; }
//			set { m_originalDateTime = value; }
//		}
		
		public Task(int id, string taskText, DateTime remainderDate) : this()
		{
			this.m_id = id;
			this.m_text = taskText;
			this.m_dateRemainder = remainderDate;
		}
		
		public Task()
		{
			
		}
	}
}
