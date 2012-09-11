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
		public List<Task> Sync(List<Task> tasks, string userId)
		{
			if(Minder.WebServices.Helpers.StaticData.ConfigLoaded == false)
				ConfigLoader.Load(@"c:\Dokumentai\Projektai\Minder1\Minder.WebServices\bin\CoreConfig.xml");
			List<Task> tasksFromDb = LoadAllTasksByUserId(userId);
			List<Task> result = MergeTasks(tasksFromDb, tasks);
			SaveTasksToDb(tasksFromDb, result);
			return result;
		}
		
		private List<Task> LoadAllTasksByUserId(string userId)
		{
			List<Task> result = new List<Task>();
			if(string.IsNullOrEmpty(userId))
				return result;
			List<Task> allTasks = GenericDbHelper.Get<Task>();
			
			foreach(Task task in allTasks)
			{
				if(task.UserId.Equals(userId))
					result.Add(task);
			}
			
			return result;
		}
		
		private void SaveTasksToDb(List<Task> taskFromDb, List<Task> mergedTasks)
		{
			foreach(Task task in taskFromDb)
			{
				GenericDbHelper.DeleteAndFlush(task);
			}
			
			foreach(Task task in mergedTasks)
			{
				GenericDbHelper.SaveAndFlush(task);
			}
		}
		
		private List<Task> MergeTasks(List<Task> tasksFromDb, List<Task> tasksFromUser)
		{
			Dictionary<string, Task> result = new Dictionary<string, Task>();
			
			foreach(Task task in tasksFromDb)
			{
				result.Add(task.SourceId, task);
			}
			
			foreach(Task task in tasksFromUser)
			{
				Task tempTask = null;
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
			
			return new List<Task>(result.Values);
		}
	}
}
