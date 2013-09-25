/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.13
 * Time: 22:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Minder.Objects
{
	/// <summary>
	/// Description of SyncObject.
	/// </summary>
	public class SyncObject
	{
		string m_userId;
		
		public string UserId {
			get { return m_userId; }
			set { m_userId = value; }
		}
		
		List<Task> m_tasks;
		
		public List<Task> Tasks {
			get { return m_tasks; }
			set { m_tasks = value; }
		}
		
		DateTime m_lastSyncDate;
		
		public DateTime LastSyncDate {
			get { return m_lastSyncDate; }
			set { m_lastSyncDate = value; }
		}
	}
}
