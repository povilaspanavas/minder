

using System;

namespace Minder.Sql.DBVersionSystem
{
	public class DBVersionInformation : IDBVersionInformation
	{
		DBVersionAttribute m_attribute = null;
		IDBVersionBody m_versionBody = null;
		DBHistoryAttribute m_historyAtrribute = null;
		
		public DBVersionInformation(DBVersionAttribute attribute, IDBVersionBody versionBody, DBHistoryAttribute historyAtrriute)
		{
			if (attribute == null)
				throw new ArgumentNullException();
			this.m_attribute = attribute;
			this.m_versionBody = versionBody;
			this.m_historyAtrribute = historyAtrriute;
		}
		
		public DBHistoryAttribute HistoryAttribute {
			get { return m_historyAtrribute; }
			set { m_historyAtrribute = value; }
		}
		
		public DBVersionAttribute VersionAttribute {
			get { return m_attribute; }
			set { m_attribute = value; }
		}
		
		public IDBVersionBody VersionBody {
			get { return m_versionBody; }
			set { m_versionBody = value; }
		}
		
		public override string ToString()
		{
			return string.Format("[DBVersionInformation Attribute={0}]", this.m_attribute);
		}
		
	}
}
