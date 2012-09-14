
using System;
using System.Collections.Generic;
using System.Reflection;
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
		
		public void UpdateToVersion()
		{
			m_repository.CheckVersions();
			
			int dbVersion = DBVersionService.GetCurrentClientDBVersion();
			
			
//			m_log.Info("Injecting DBStructure versions into database");
			new DBVersionSystemRunner()
				.ExecuteUpdateToDB(new DBVersionRepository()
				                   .AddVersions(m_repository
				                                .FromVersion(dbVersion)))
				                                ;
//			m_log.Info("DB update finished successfully");
		}
	}
}
