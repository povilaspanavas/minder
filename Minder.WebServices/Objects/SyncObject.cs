/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.11
 * Time: 21:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace Minder.WebServices.Objects
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
		
		List<TaskSync> m_tasks;
		
		public List<TaskSync> Tasks {
			get { return m_tasks; }
			set { m_tasks = value; }
		}
	}
}
