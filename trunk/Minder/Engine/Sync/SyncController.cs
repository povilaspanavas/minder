/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.13
 * Time: 22:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using Core;
using Core.DB;
using Core.DB.Connections;
using Core.Tools.Log;
using Minder.Objects;
using PUV.WebServices.Helpers;

namespace Minder.Engine.Sync
{
	/// <summary>
	/// Description of SyncController.
	/// </summary>
	public class SyncController
	{
		log4net.ILog m_log = log4net.LogManager.GetLogger(typeof(SyncController));
		
		private System.Windows.Forms.Timer m_timer = null;
		private int m_newTasks;
		private string m_ip = "192.168.0.102";
		
		public delegate void SyncEventHandler();
		public event SyncEventHandler Synced;

		public int NewTasks {
			get { return m_newTasks; }
			set { m_newTasks = value; }
		}
		
		public SyncController()
		{
		}
		
		public void Sync()
		{
			
			if(string.IsNullOrEmpty(Static.StaticData.Settings.Sync.Id))
				return;
			
			try
			{
				DateTime startSync = DateTime.Now;
				DateTime lastSyncDate = Minder.Static.StaticData.Settings.Sync.LastSyncDate;
				List<Task> allTasks = GenericDbHelper.Get<Task>(string.Format("LAST_MODIFY_DATE >= '{0}'", lastSyncDate.ToString("yyyy.MM.dd hh:mm:ss")));
				SyncObject syncObject = new SyncObject();
				syncObject.UserId = Static.StaticData.Settings.Sync.Id;
				syncObject.Tasks = new List<Task>();
				syncObject.LastSyncDate = lastSyncDate.ToUniversalTime();
				
				foreach(Task task in allTasks)
				{
					task.UserId = Static.StaticData.Settings.Sync.Id;
					syncObject.Tasks.Add(task);
//					task.LastModifyDate = task.LastModifyDate.ToUniversalTime();
//					task.DateRemainder = task.DateRemainder.ToUniversalTime();
				}
				
				//Paruošti taskai siuntimui
				List<Task> tasksFromServer = GetSyncedTasksFromServer(syncObject);
				
				foreach(Task task in allTasks)
				{
					task.DateRemainder = task.DateRemainder.ToLocalTime();
					task.LastModifyDate = task.LastModifyDate.ToLocalTime();
				}
				
				m_newTasks = tasksFromServer.Count;
//				using(IConnection con = new ConnectionCollector().GetConnection())
//				{
				foreach(Task task in tasksFromServer)
				{
					task.LastModifyDate = task.LastModifyDate.ToLocalTime();
					task.DateRemainder = task.DateRemainder.ToLocalTime();
					
					foreach(Task localTask in allTasks)
					{
						if(localTask.Equals(task))
							m_newTasks--;
					}
					
					if(ExistTask(task))
					{
						//Negalime updatinti pagal ID, nes serveryje kitoks id.
						GenericDbHelper.RunDirectSql(string.Format("DELETE FROM TASK WHERE SOURCE_ID = '{0}'", task.SourceId));
						GenericDbHelper.Save(task);
					}
					else
						GenericDbHelper.Save(task);
				}
				GenericDbHelper.Flush();
//				}
				
				if(m_newTasks > 0)
					Synced();
				
				Minder.Static.StaticData.Settings.Sync.LastSyncDate = DateTime.Now;
				TimeSpan span = DateTime.Now - startSync;
				m_log.InfoFormat("Synced in {0} seconds", span.TotalSeconds);
			}
			catch (Exception e)
			{
				m_log.Error(e);
			}
			
		}
		
		private bool ExistTask(Task task)
		{
			if(string.IsNullOrEmpty(task.SourceId))
				throw new Exception("Task without sourceId");
			using(IConnection con = new ConnectionCollector().GetConnection())
			{
				IDataReader reader = con.ExecuteReader(string.Format("SELECT COUNT(ID) FROM TASK WHERE SOURCE_ID = '{0}'", task.SourceId));
				int count = 0;
				while(reader.Read())
				{
					count = reader.GetInt32(0);
				}
				if(count > 0)
					return true;
				else
					return false;
			}
		}
		
		public void StartThreadForSync()
		{
			bool firstSync = true;
			m_timer = new System.Windows.Forms.Timer();
			m_timer.Interval = Minder.Static.StaticData.Settings.Sync.Interval * 1000 * 60;
			m_timer.Tick += delegate {
				if(firstSync == false)
					Sync();
				firstSync = false;
			};
//			Thread.Sleep(m_timer.Interval);
			m_timer.Start();
		}
		
		private List<Task> GetSyncedTasksFromServer(SyncObject syncObject)
		{
			string json = JsonHelper.ConvertToJson<SyncObject>(syncObject);
			
			string requestString = "{\"json\" : \" ";
			requestString += Regex.Replace(json, "\"", "\\\"");
			requestString += "\"}";
			
			HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(string.Format("http://{0}/Minder.WebServices/default.asmx/Sync", m_ip));
			request.ContentType = "application/json; charset=utf-8";
			request.Accept = "application/json, text/javascript, */*";
			request.Method = "POST";
			request.Timeout = 1000 * 10; //10 Seconds
			using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
			{
				writer.Write(requestString);
			}

			WebResponse response = request.GetResponse();
			Stream stream = response.GetResponseStream();
			string resultJson = "";

			using (StreamReader reader = new StreamReader(stream))
			{
				while (!reader.EndOfStream)
				{
					resultJson += reader.ReadLine();
				}
			}
			
			SyncObject result = JsonHelper.JsonToObject<SyncObject>(resultJson);
			return result.Tasks;
		}
	}
}
