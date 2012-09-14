using System;
using System.Data;
using Core.DB;
using Core.DB.Connections;

namespace Minder.Sql.DBVersionSystem
{
	public static class DBVersionService
	{
//		private static log4net.ILog m_log = log4net.LogManager.GetLogger(typeof(DBVersionService));
		
		
		public static int GetCurrentClientDBVersion()
		{
			string query = "SELECT max(DB_VERSION) FROM DB_VERSION";
			int version = GetCurrentVersionByQuery(query);
//			m_log.Info(string.Format("Client DB version is {0}", version));
			return version;
		}
		
//		public static int GetCurrentCoreDBVersion()
//		{
//			string query = "SELECT max(DB_CORE_VERSION) FROM CORE_DB_CORE_VERSION";
//			int version = GetCurrentVersionByQuery(query);
//			m_log.Info(string.Format("Core DB version is {0}", version));
//			return version;
//		}
		
		private static int GetCurrentVersionByQuery(string query)
		{
			using(IConnection con = new ConnectionCollector().GetConnection())
			{
				int? max = null;
				IDataReader dataReader = con.ExecuteReader("SELECT max(VERSION_NR) FROM DB_VERSION");
				while(dataReader.Read())
				if (max == null)
					return 0;
				return max.Value;
			}
		}
		
		
	}
}
