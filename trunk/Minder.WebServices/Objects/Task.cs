/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.11
 * Time: 20:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core.Attributes;
using Core.Objects;

namespace Minder.WebServices.Objects
{
	/// <summary>
	/// Description of Task.
	/// </summary>
	[DbTable("TASK")]
	public class TaskSync : ICoreObject
	{
		private int m_id;
		
		[DBColumnReference("ID"), PrimaryKey("TASK_SEQ")]
		public int Id {
			get {
				return m_id;
			}
			set {
				m_id = value;
			}
		}
		
		string m_userId = string.Empty;
		
		[DBColumnReference("USER_ID")]
		public string UserId {
			get { return m_userId; }
			set { m_userId = value; }
		}
		
		string m_dateRemainder = string.Empty;
		
		[DBColumnReference("DATE_REMAINDER")]
		public string DateRemainderString {
			get { return m_dateRemainder; }
			set { m_dateRemainder = value; }
		}
		
		bool m_showed;
		
		[DBColumnReference("SHOWED")]
		public bool Showed {
			get { return m_showed; }
			set { m_showed = value; }
		}
		
		string m_sourceId = string.Empty;
		
		[DBColumnReference("SOURCE_ID")]
		public string SourceId {
			get { return m_sourceId; }
			set { m_sourceId = value; }
		}
		
		string m_text = string.Empty;
		
		[DBColumnReference("REMAINDER_TEXT")]
		public string Text {
			get { return m_text; }
			set { m_text = value; }
		}
		
		string m_lastModifyDate = string.Empty;
		
		[DBColumnReference("LAST_MODIFY_DATE")]
		public string LastModifyDateString {
			get { return m_lastModifyDate; }
			set { m_lastModifyDate = value; }
		}
		
		bool m_isDeleted;
		
		[DBColumnReference("IS_DELETED")]
		public bool IsDeleted {
			get { return m_isDeleted; }
			set { m_isDeleted = value; }
		}
	}
}
