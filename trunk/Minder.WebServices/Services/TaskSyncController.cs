﻿/*
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
			SetCorrectTime(tasks);
			if(Minder.WebServices.Helpers.StaticData.ConfigLoaded == false)
				ConfigLoader.Load(@"c:\Dokumentai\Projektai\Minder\Minder.WebServices\bin\CoreConfig.xml");
			List<TaskSync> tasksFromDb = LoadAllTasksByUserId(userId);
			List<TaskSync> result = MergeTasks(tasksFromDb, tasks);
			SaveTasksToDb(tasksFromDb, result);
			return result;
		}
		
		private void SetCorrectTime(List<TaskSync> tasks)
		{
			foreach(TaskSync task in tasks)
			{
				task.LastModifyDate = task.LastModifyDate.AddHours(3);
				task.DateRemainder = task.DateRemainder.AddHours(3);
			}
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
			string userId = string.Empty;
			if(taskFromDb.Count != 0)
				userId = taskFromDb[0].UserId;
			GenericDbHelper.RunDirectSql(string.Format("DELETE FROM TASK WHERE USER_ID = '{0}'", userId));
			
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
