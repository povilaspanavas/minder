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
		public List<TaskSync> Sync(List<TaskSync> tasks, string userId)
		{
			if(Minder.WebServices.Helpers.StaticData.ConfigLoaded == false)
				ConfigLoader.Load(@"c:\Dokumentai\Projektai\Minder1\Minder.WebServices\bin\CoreConfig.xml");
			List<TaskSync> tasksFromDb = LoadAllTasksByUserId(userId);
			List<TaskSync> result = MergeTasks(tasksFromDb, tasks);
			SaveTasksToDb(tasksFromDb, result);
			return result;
		}
		
		private List<TaskSync> LoadAllTasksByUserId(string userId)
		{
			List<TaskSync> result = new List<TaskSync>();
			if(string.IsNullOrEmpty(userId))
				return result;
			List<TaskSync> allTasks = GenericDbHelper.Get<TaskSync>();
			
			foreach(TaskSync task in allTasks)
			{
				if(task.UserId.Equals(userId))
					result.Add(task);
			}
			
			return result;
		}
		
		private void SaveTasksToDb(List<TaskSync> taskFromDb, List<TaskSync> mergedTasks)
		{
			foreach(TaskSync task in taskFromDb)
			{
				GenericDbHelper.DeleteAndFlush(task);
			}
			
			foreach(TaskSync task in mergedTasks)
			{
				GenericDbHelper.SaveAndFlush(task);
			}
		}
		
		private List<TaskSync> MergeTasks(List<TaskSync> tasksFromDb, List<TaskSync> tasksFromUser)
		{
			Dictionary<string, TaskSync> result = new Dictionary<string, TaskSync>();
			
			foreach(TaskSync task in tasksFromDb)
			{
				result.Add(task.SourceId, task);
			}
			
			foreach(TaskSync task in tasksFromUser)
			{
				TaskSync tempTask = null;
				result.TryGetValue(task.SourceId, out tempTask);
				if(tempTask != null)
				{
					if(task.IsDeleted)
						result.Remove(task.SourceId);
					else
					{
						if(DateTime.Compare(tempTask.LastModifyDate, task.LastModifyDate) <= 0)
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
