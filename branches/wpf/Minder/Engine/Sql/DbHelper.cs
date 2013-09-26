/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.12
 * Time: 21:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;

using Core.DB;
using Core.DB.Connections;
using Minder.Objects;
using Minder.Tools;

namespace Minder.Sql
{
	public class DbHelper
	{
		
		public List<Task> LoadTasksForShowing()
		{
			using(IConnection con = new ConnectionCollector().GetConnection())
			{
				string query = string.Format("SELECT ID, NAME, DATE_REMAINDER, SOURCE_ID, SHOWED from task where DATE_REMAINDER <= {0}" +
				                             "and (SHOWED = 0 or SHOWED is null or SHOWED = '') and (IS_DELETED = 0 or IS_DELETED is null " +
				                            "or IS_DELETED = '')",
				                             DBTypesConverter.ToFullDateStringByCultureInfoWithQuotes(DateTime.Now));
				
				IDataReader reader = con.ExecuteReader(query);
				List<Task> tasks = new List<Task>();
				while(reader.Read())
				{
					int id = reader.GetInt32(0);
					string name = reader.GetString(1);
					DateTime date =  Convert.ToDateTime(reader.GetString(2), Static.StaticData.Settings.CultureData.CultureInfo);
					string sourceId = reader.GetString(3);
					tasks.Add(new Task(id, name, date, sourceId));
				}
				return tasks;
			}
		}
		
		public List<Task> LoadAllTasks()
		{
			using(IConnection con = new ConnectionCollector().GetConnection())
			{
				string query = string.Format("SELECT ID, NAME, DATE_REMAINDER, SOURCE_ID, SHOWED from task where " +
"				                             (IS_DELETED = 0 or IS_DELETED is null or IS_DELETED = '')");
				
				IDataReader reader = con.ExecuteReader(query);
				List<Task> tasks = new List<Task>();
				while(reader.Read())
				{
					int id = reader.GetInt32(0);
					string name = reader.GetString(1);
					DateTime date = DateTime.Parse(reader.GetString(2));
					string sourceId = reader.GetString(3);
					Task task = new Task(id, name, date, sourceId);
					task.Showed = GetBoolValue(reader[4]);
					tasks.Add(task);
				}
				return tasks;
			}
		}
		
		public static bool GetBoolValue(object readerValue)
		{
			if (readerValue != null && string.IsNullOrEmpty(readerValue.ToString()) == false)
				return Convert.ToBoolean(readerValue);
			return false;
		}
		
		public Task NextTaskToShow()
		{
			using(IConnection connection = new ConnectionCollector().GetConnection())
			{
				string query = string.Format("select id, name, date_remainder, source_id from task where (showed is null " +
				                             "or showed = 0 or SHOWED = '') and  (IS_DELETED = 0 or IS_DELETED is null)" +
				                             " order by date_remainder, id",
				                             DBTypesConverter.ToFullDateStringByCultureInfoWithQuotes(DateTime.Now.AddSeconds(-15)));
				
				IDataReader reader = connection.ExecuteReader(query);
				while(reader.Read())
				{
					int id = reader.GetInt32(0);
					string name = reader.GetString(1);
					DateTime date = Convert.ToDateTime(reader.GetString(2), Static.StaticData.Settings.CultureData.CultureInfo);
					string sourceId = reader.GetString(3);
					return new Task(id, name, date, sourceId);
				}
				return null;
			}
		}
		
		public DateTime? NextDateToShow()
		{
			Task task = NextTaskToShow();
			if (task == null)
				return null;
			else
				return task.DateRemainder;
		}
		
		public int SelectNextInterval()
		{
			DateTime? nextDate = NextDateToShow();
			if (nextDate == null)
				return -1;
			if (nextDate.Value < DateTime.Now)
				return 1; // sutiksėk tuoj pat
			TimeSpan timeSpan = nextDate.Value.Subtract(DateTime.Now);
			if (timeSpan.TotalDays >= 1)
				return -1;
			return (int)timeSpan.TotalMilliseconds;
		}
		
		public void Delete(int id)
		{
			Task task = GenericDbHelper.GetById<Task>(id);
			if(task != null)
			{
				task.IsDeleted = true;
				GenericDbHelper.UpdateAndFlush(task);
			}
		}
		
		public void CreateTable()
		{
			GenericDbHelper.CreateTable(typeof(Task));
		}
	}
}
