
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Core.DB;
using Core.DB.Connections;
using Minder.Sql.DBVersionSystem;

namespace Minder.Sql.DBVersionSystem
{
	public class DBVersionSystem
	{
//		private static log4net.ILog m_log = log4net.LogManager.GetLogger(typeof(DBVersionSystem));
		private DBVersionRepository m_repository = null;
//		private DBVersionRepository m_repoCore = null;
		
		public DBVersionSystem(DBVersionRepository repoClient)
		{
			this.m_repository = repoClient;
		}
		
		public void UpdateToNewest()
		{
			m_repository.CheckVersions();
			
			int dbVersion = GetCurrentVersion();
			
			
//			m_log.Info("Injecting DBStructure versions into database");
			new DBVersionSystemRunner()
				.ExecuteUpdateToDB(new DBVersionRepository()
				                   .AddVersions(m_repository
				                                .FromVersion(dbVersion)))
				;
//			m_log.Info("DB update finished successfully");
		}
		
		public static int GetCurrentVersion()
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
