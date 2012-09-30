/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.11
 * Time: 21:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;

using Core;
using Core.DB;
using Minder.WebServices.Objects;

namespace Minder.WebServices.Services
{
	/// <summary>
	/// Description of TaskSyncController.
	/// </summary>
	public class TaskSyncController
	{
//		Loger m_log = new Loger();
		
		//Main
		public List<TaskSync> Sync(List<TaskSync> tasks, string userId, DateTime lastSyncDate)
		{
//			if(Minder.WebServices.Helpers.StaticData.ConfigLoaded == false)
//			{
//				ConfigLoader.Load(@"c:\Dokumentai\Projektai\Minder\Minder.WebServices\bin\CoreConfig.xml");
//				FileInfo config = new FileInfo(@"c:\Dokumentai\Projektai\Minder\Minder.WebServices\bin\MinderWebServices.log4net.xml");
//				log4net.Config.XmlConfigurator.Configure(config);
//			}
			
			List<TaskSync> tasksFromDb = LoadAllTasksByUserId(userId, lastSyncDate);
			List<TaskSync> result = MergeTasks(tasksFromDb, tasks);
			SaveTasksToDb(tasksFromDb, result, lastSyncDate);
			return result;
		}
		
//		private void SetUTCTime(List<TaskSync> tasks)
//		{
//			foreach(TaskSync task in tasks)
//			{
//				task.LastModifyDate = task.LastModifyDate.ToUniversalTime();
//				task.DateRemainder = task.DateRemainder.ToUniversalTime();
//			}
//		}
		
		private List<TaskSync> LoadAllTasksByUserId(string userId, DateTime lastSyncDate)
		{
			List<TaskSync> result = new List<TaskSync>();
			if(string.IsNullOrEmpty(userId))
				return result;
			result = GenericDbHelper.Get<TaskSync>(string.Format("LAST_MODIFY_DATE >= '{0}' and USER_ID = '{1}'", 
			                                                                      lastSyncDate.ToString("yyyy.MM.dd hh:mm:ss"), userId));
			return result;
		}
		
		private void SaveTasksToDb(List<TaskSync> taskFromDb, List<TaskSync> mergedTasks, DateTime lastSyncDate)
		{
			string userId = string.Empty;
			if(taskFromDb.Count != 0)
				userId = taskFromDb[0].UserId;
			GenericDbHelper.RunDirectSql(string.Format("DELETE FROM TASK WHERE LAST_MODIFY_DATE >= '{0}' and USER_ID = '{1}'", lastSyncDate, userId));
			
			foreach(TaskSync task in mergedTasks)
			{
				GenericDbHelper.Save(task);
			}
			GenericDbHelper.Flush();
		}
		
		private List<TaskSync> MergeTasks(List<TaskSync> tasksFromDb, List<TaskSync> tasksFromUser)
		{
			Dictionary<string, TaskSync> result = new Dictionary<string, TaskSync>();
			
			foreach(TaskSync task in tasksFromDb)
			{
				task.Id = 0;
				result.Remove(task.SourceId);
				result.Add(task.SourceId, task);
			}
			
			foreach(TaskSync task in tasksFromUser)
			{
				task.Id = 0;
				TaskSync tempTask = null;
				result.TryGetValue(task.SourceId, out tempTask);
				if(tempTask != null)
				{
					if(task.IsDeleted)
						result.Remove(task.SourceId);
					else
					{
						DateTime tempTaskDate = Convert.ToDateTime(tempTask.LastModifyDate);
						DateTime taskDate = Convert.ToDateTime(task.LastModifyDate);
						if(DateTime.Compare(tempTaskDate, taskDate) <= 0)
						{
							result.Remove(task.SourceId);
							result.Add(task.SourceId, task);
						}
					}
				}
				else
					result.Add(task.SourceId, task);
			}
			
			return new List<TaskSync>(result.Values);
		}
	}
}
