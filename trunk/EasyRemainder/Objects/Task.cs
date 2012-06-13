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
		int id;
		string name;
		DateTime m_dateRemainder;
		string sourceId;
		
		public string SourceId {
			get { return sourceId; }
			set { sourceId = value; }
		}
		
		public int Id {
			get { return id; }
			set { id = value; }
		}
		
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		
		public DateTime DateRemainder {
			get { return m_dateRemainder; }
			set { m_dateRemainder = value; }
		}
		
		string originalDateTime;
		
		public string OriginalDateTime {
			get { return originalDateTime; }
			set { originalDateTime = value; }
		}
		public Task(int id, string taskText, DateTime remainderDate) : this()
		{
			this.id = id;
			this.name = taskText;
			this.m_dateRemainder = remainderDate;
		}
		public Task()
		{
			
		}
	}
}
