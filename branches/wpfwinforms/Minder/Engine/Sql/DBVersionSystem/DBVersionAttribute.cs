
using System;

namespace Minder.Sql.DBVersionSystem
{
	public class DBVersionAttribute : Attribute
	{
		#region Fields
		int m_version = 0;
		string m_comment = string.Empty;
		DateTime m_date;
		#endregion
		
		#region Properties
		public int Version {
			get { return m_version; }
			set { m_version = value; }
		}
		
		public string Comment {
			get { return m_comment; }
			set { m_comment = value; }
		}
		
		public DateTime Date {
			get { return m_date; }
		}
		
		#endregion
		
		#region methods
		public DBVersionAttribute(int version, string comment, string date)
		{
			m_version = version;
			m_comment = comment;
			m_date = DateTime.Parse(date);
		}
		#endregion
		
		public override string ToString()
		{
			return string.Format("[BaseDBVersionAttribute Version={0} Comment={1} Date={2}]", this.m_version, this.m_comment, this.m_date);
		}
		
	}
}
