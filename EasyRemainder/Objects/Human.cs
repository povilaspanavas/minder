
using System;
using Core.Attributes;
using Core.Objects;

namespace EasyRemainder.Objects
{
	/// <summary>
	/// Description of Human.
	/// </summary>
	public class Human : BaseCoreObject, ICoreObject
	{
		public string Table {
			get {
				return "HUMAN";
			}
		}
		
		public string[] Columns {
			get {
				return null;
			}
		}
		
		private int m_id;
		
		[PrimaryKey("HUMAN_SEQ"), DBColumnReference("ID")]
		public int Id {
			get {
				return m_id;
			}
			set {
				m_id = value;
			}
		}
		
//		string m_name;
//		
//		[DBColumnReference("NAME")]
//		public string Name {
//			get { return m_name; }
//			set { m_name = value; }
//		}
		
		string m_userName;
		
		[DBColumnReference("USER_NAME")]
		public string UserName {
			get { return m_userName; }
			set { m_userName = value; }
		}
		
		string m_password;
		
		[DBColumnReference("PASS")]
		public string Password {
			get { return m_password; }
			set { m_password = value; }
		}
		
		
		public bool Equal(object obj)
		{
			throw new NotImplementedException();
		}
	}
}
