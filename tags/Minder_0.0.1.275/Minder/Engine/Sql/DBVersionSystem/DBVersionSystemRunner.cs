
using System;
using System.Collections.Generic;
using System.Reflection;
using Minder.Objects;
using Minder.Sql.DBVersionSystem;

namespace Minder.Sql.DBVersionSystem
{

	public class DBVersionSystemRunner
	{
//		private static log4net.ILog m_log = log4net.LogManager.GetLogger(typeof(DBVersionSystemRunner));
		
		
		/// <summary>
		/// Creates all instances of DBVersion or DBCoreVersion from
		/// provided DBVersionSystem
		/// </summary>
		public void CreateAllVersionsInDB(DBVersionRepository system)
		{
			DBVersionSystemRunner runner = new DBVersionSystemRunner();
			foreach(IDBVersionInformation info in system.VersionsTable.Values)
			{
				runner.CreateVersionInDB(info);
			}
		}
		
		private SortedDictionary<int, IDBVersionInformation> Sort(DBVersionRepository repo)
		{
			SortedDictionary<int, IDBVersionInformation> list = new SortedDictionary<int, IDBVersionInformation>();
			foreach (IDBVersionInformation info in repo.VersionsTable.Values)
			{
				list.Add(info.VersionAttribute.Version, info);
			}
			return list;
		}
		
		public DBVersionSystemRunner ExecuteUpdateToDB(DBVersionRepository repo)
		{
//			m_log.Info(string.Format("Preparing to inject {0} new versions into database",
//			                         repo.VersionsTable.Count));
//
//			foreach (IDBVersionInformation info in Sort(repo).Values)
//			{
//				string versionInfo = string.Format(
//					"[{0} - {1}]",
//					info.VersionAttribute.Version,
//					info.VersionAttribute.Date);
//				using (NHibernateSession sessionScope = new NHibernateSession())
//				{
//					ISession session = NHibernateSession.GetISession(typeof(Role));
//					using (ITransaction tx = session.BeginTransaction())
//					{
//						try
//						{
//
//							m_log.InfoFormat("Injecting version {0} into database", versionInfo);
//							info.VersionBody.Execute();
//							CreateVersionInDB(info);
//							tx.Commit();
//						}
//						catch (Exception e)
//						{
			////							m_log.Error(string.Format("Could not commit version {0}", versionInfo), e);
			////							m_log.Error(string.Format("Rolling back"));
//							tx.Rollback();
//							sessionScope.Dispose();
			////							m_log.Error(string.Format("Stopping db update"));
//							throw new DBUpdateException(string.Format("Error injecting DB version {2}, date '{1}'.",
//							                                          info.VersionAttribute.Date,
//							                                          info.VersionAttribute.Version)
//							                            , e);
//						}
//
//					}
//				}
//			}
//
//			m_log.Info(string.Format("Success - Injected {0} new versions into database",
//			                         repo.VersionsTable.Count));
			return this;
		}
		
		
		/// <summary>
		/// Creates instance of DBVersion or DBCoreVersion in database according to DBHistory atrribute
		/// </summary>
		public void CreateVersionInDB(IDBVersionInformation info)
		{
			DBVersion dbVersion = new DBVersion();
			dbVersion.Comment = info.VersionAttribute.Comment;
			dbVersion.Date = info.VersionAttribute.Date;
			dbVersion.VersionNr = info.VersionAttribute.Version;
			dbVersion.Save();
		}
	}
}
