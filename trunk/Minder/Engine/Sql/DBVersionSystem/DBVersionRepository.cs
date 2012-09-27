

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using Minder.Engine;

namespace Minder.Sql.DBVersionSystem
{

	public class DBVersionRepository
	{
		private static log4net.ILog m_log = log4net.LogManager.GetLogger(typeof(DBVersionRepository));
		
		private SortedDictionary<int, IDBVersionInformation> m_versionsTable = null;
		
		public SortedDictionary<int, IDBVersionInformation> VersionsTable {
			get { return m_versionsTable; }
		}
		
		public DBVersionRepository()
		{
			m_log.Debug("DBVersionSystem created");
			this.m_versionsTable = new SortedDictionary<int, IDBVersionInformation>();
		}
		
//		public DBVersionRepository ForVersionType(Type type)
//		{
//			DBVersionRepository repo = new DBVersionRepository();
//			
//			foreach(IDBVersionInformation versionInfo in VersionsTable.Values)
//			{
//				if (versionInfo.VersionAttribute.GetType().Equals(type))
//					repo.AddVersions(versionInfo);
//			}
//			return repo;
//		}
		
		public DBVersionRepository FromVersion(int currentVersion)
		{
			DBVersionRepository repo = new DBVersionRepository();
			
			foreach(IDBVersionInformation versionInfo in VersionsTable.Values)
			{
				int ver = versionInfo.VersionAttribute.Version;
				if (ver > currentVersion)
				{
					repo.AddVersions(versionInfo);
				}
			}
			return repo;
		}
		
		/// <summary>
		/// Returns the top-version registered in DBVersionSystem
		/// by date
		/// </summary>
		/// <returns></returns>
		public int GetMaxVersion()
		{
			int max = 0;
			foreach(IDBVersionInformation entry in m_versionsTable.Values)
			{
				if (entry.VersionAttribute.Version > max)
					max = entry.VersionAttribute.Version;
			}
//			if (max.Equals(DateTime.MinValue))
//				return 0;
			IDBVersionInformation info = m_versionsTable[max];
			if (info == null)
				throw new ArgumentNullException("Could not get max version. Error in code");
			return info.VersionAttribute.Version;
		}
		
		private void CheckVersionNumbers()
		{
			IDBVersionInformation lastVersion = null;
			foreach (IDBVersionInformation entry in m_versionsTable.Values)
			{
				if (entry.VersionAttribute.Version < 1)
					throw new DBUpdateException(string.Format("DBVersionAttribute number is less than 1 for method {0}", entry.VersionAttribute.ToString()));
				if (lastVersion != null)
					if (entry.VersionAttribute.Version <= lastVersion.VersionAttribute.Version)
					throw new DBUpdateException(string.Format(
						"DBVersion {0} has a Version atrribute where version number " +
						"is less or equalthan the previous db version (that is {1})",
						entry.VersionAttribute.ToString(),
						lastVersion.VersionAttribute.ToString()));
				
				lastVersion = entry;
			}
		}
		
		/// <summary>
		/// Checkes if all versions are in a row and not lower than 1.
		/// For example 1, 2, 3, ... is corect, but
		/// 2, 3, 6 is wrong, because 1, 4 and 5 is missing.
		/// Also checks if there is at least one version
		/// </summary>
		/// <exception cref="DLCException">if there is no method with specific version number</exception>
		/// <returns>true if all conditions are corect</returns>
		public void CheckVersions()
		{
			m_log.Debug("Cheking versions");
			if (m_versionsTable.Count == 0)
				throw new ArgumentOutOfRangeException("There must be at least one method with atrribute DBVersionAttribute");
			
			CheckVersionNumbers();
			
			SortedDictionary<int, IDBVersionInformation> sorted = new SortedDictionary<int, IDBVersionInformation>();
			IDBVersionInformation lastVersion = null;
			foreach (IDBVersionInformation entry in m_versionsTable.Values)
			{
				try
				{
					sorted.Add(entry.VersionAttribute.Version, entry);
				}
				catch (ArgumentException e)
				{
					lastVersion = m_versionsTable[entry.VersionAttribute.Version];
					throw new DBUpdateException(string.Format(
						"DBVersion {0} has a Version atrribute where date is the same as " +
						" other db version (that is {1})",
						entry.VersionAttribute.ToString(),
						lastVersion.VersionAttribute.ToString()), e);
				}
			}
		}
		
		public DBVersionRepository AddVersions(DBVersionRepository repo)
		{
			foreach (DBVersionInformation info in repo.VersionsTable.Values)
			{
				this.AddVersions(info);
			}
			return this;
		}
		
		/// <param name="filename">full path to assembly</param>
		public DBVersionRepository AddVersions(string filename)
		{
			m_log.Debug(string.Format("Loading methods from file {0}", Path.GetFullPath(filename)));
			Assembly ass = null;
			try
			{
				ass = Assembly.LoadFile(Path.GetFullPath(filename));
			}
			catch (System.IO.FileNotFoundException)
			{
				m_log.Error(string.Format("File not found, passed path {0}, fullpath {1}", filename, Path.GetFullPath(filename)));
				throw;
			}
			AddVersions(ass);
			return this;
		}
		
		/// <summary>
		/// IMPORTANT: if both classes with DBHistory attribute is in the same file then they have the same
		/// assembly. It means, you need to call this function only once, otherwise you'll get an exception,
		/// that you're trying to add method with the same DBVerstionAttribute.Version, which already exists
		/// </summary>
		/// <param name="type"></param>
		
		public DBVersionRepository AddVersions(Type type)
		{
			m_log.Debug(string.Format("Importing methods from type {0}", type.FullName));
			DBHistoryAttribute dbHistoryAtr = AttributeParser.GetAttribute<DBHistoryAttribute>(type);
			if (dbHistoryAtr == null)
			{
				m_log.Debug(string.Format("Type {0} doesn't have DBHistoryAttribute", type.FullName));
				return this;
			}
			foreach (MethodInfo method in type.GetMethods())
			{
				DBVersionAttribute dbVersionAtr = AttributeParser.GetAttribute<DBVersionAttribute>(method);
				if (dbVersionAtr == null)
					continue;
				m_log.Debug(string.Format("Adding method {0} with {2} {1}", method.Name, dbVersionAtr.Version, dbHistoryAtr.GetType().Name));
				AddVersions(new DBVersionInformation(dbVersionAtr, new DBVersionBodyMethodInfo(method), dbHistoryAtr));
			}
			return this;
		}
		
		public DBVersionRepository AddVersions(DBVersionAttribute attribute,
		                                       MethodInfo method)
		{
			if (method == null)
				AddVersions(new DBVersionInformation(attribute,
				                                     new DBVersionBodyDelegate(),
				                                     new DBHistoryAttribute())); 
			else
				AddVersions(new DBVersionInformation(attribute,
				                                     new DBVersionBodyMethodInfo(method),
				                                     new DBHistoryAttribute()));
			return this;
		}
		
		public DBVersionRepository AddVersions(IDBVersionInformation info)
		{
			try
			{
				m_versionsTable.Add(info.VersionAttribute.Version, info);
			}
			catch (ArgumentException ex)
			{
				IDBVersionInformation last = m_versionsTable[info.VersionAttribute.Version];
				throw new DBUpdateException(string.Format(
					"Could not add DBVersion {0} to list," +
					" because there is already a version with that date (that is {1}). " +
					"HOW TO FIX: check dates of these DBVersions, you'll find two with the same dates.",
					info, last), ex);
			}
			return this;
		}
		
		public DBVersionRepository AddVersions(_Assembly ass)
		{
			m_log.Debug(string.Format("Importing methods from assembly {0}", ass.FullName));
			foreach (Type type in ass.GetExportedTypes())
			{
				if (AttributeParser.GetAttribute<DBHistoryAttribute>(type) == null)
					continue;
				AddVersions(type);
			}
			return this;
		}
	}
}
