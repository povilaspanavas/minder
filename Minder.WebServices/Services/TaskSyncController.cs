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
using System.Threading;
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
			foreach (TaskSync taskSyn in tasks) {
				taskSyn.DateRemainder = taskSyn.DateRemainder.ToLocalTime();
				taskSyn.LastModifyDate = taskSyn.LastModifyDate.ToLocalTime();
			}
			List<TaskSync> tasksFromDb = LoadAllTasksByUserId(userId, lastSyncDate);
			List<TaskSync> result = MergeTasks(tasksFromDb, tasks);
			SaveTasksToDb(tasksFromDb, result, lastSyncDate);
			return result;
		}
		
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
			if(mergedTasks.Count != 0)
				userId = mergedTasks[0].UserId;
//			GenericDbHelper.RunDirectSql(string.Format("DELETE FROM TASK WHERE LAST_MODIFY_DATE >= '{0}' and USER_ID = '{1}'", lastSyncDate, userId));
			
			foreach(TaskSync task in mergedTasks)
			{
				string deleteQuery = string.Format("DELETE FROM TASK WHERE SOURCE_ID = '{0}' AND USER_ID = '{1}'", task.SourceId, userId);
				GenericDbHelper.RunDirectSql(deleteQuery);
			}
			
			foreach(TaskSync task in mergedTasks)
			{
//				string deleteQuery = string.Format("DELETE FROM TASK WHERE SOURCE_ID = '{0}' AND USER_ID = '{1}'", task.SourceId, userId);
//				GenericDbHelper.RunDirectSql(deleteQuery);
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
						DateTime tempTaskDate = tempTask.LastModifyDate;
						DateTime taskDate = task.LastModifyDate;
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
