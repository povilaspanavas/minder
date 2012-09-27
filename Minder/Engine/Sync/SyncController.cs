﻿/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.13
 * Time: 22:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using Core;
using Core.DB;
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
			try
			{
				if(string.IsNullOrEmpty(Static.StaticData.Settings.Sync.Id))
					return;
				
				List<Task> allTasks = GenericDbHelper.Get<Task>();
				SyncObject syncObject = new SyncObject();
				syncObject.UserId = Static.StaticData.Settings.Sync.Id;
				syncObject.Tasks = new List<Task>();
				
				foreach(Task task in allTasks)
				{
					task.UserId = Static.StaticData.Settings.Sync.Id;
					syncObject.Tasks.Add(task);
				}
				
				List<Task> syncedTasks = GetSyncedTasksFromServer(syncObject);
				GenericDbHelper.RunDirectSql("DELETE FROM TASK");
				int newTasks = 0;
				foreach(Task task in syncedTasks)
				{
					task.LastModifyDate = Convert.ToDateTime(task.LastModifyDateString);
					task.DateRemainder = Convert.ToDateTime(task.DateRemainderString);
					
					bool exist = false;
					
					foreach(Task taskFromDb in allTasks)
					{
						if(taskFromDb.Equals(task))
							exist = true;
					}
					
					if(exist == false)
						newTasks++;
					
					GenericDbHelper.Save(task);
				}
				
				bool saved = false;
				int i = 0;
				while(saved == false)
				{
					try
					{
						GenericDbHelper.Flush();
						saved = true;
					}
					catch (Exception)
					{
						i++;
						Thread.Sleep(2000); //2 secconds
					}
					
					if(i > 10)
					{
						throw new Exception("Can't save tasks to DB");
//							break;
					}
				}
				
				
				if(newTasks != 0)
				{
					m_newTasks = newTasks;
					Synced();
				}
				
				m_log.Info("Synced ok!");
				
			}
			catch (Exception e)
			{
				m_log.Error(e.ToString());
			}
		}
		
		public void StartThreadForSync()
		{
			m_timer = new System.Windows.Forms.Timer();
			m_timer.Interval = Minder.Static.StaticData.Settings.Sync.Interval * 1000 * 60;
			m_timer.Tick += delegate {
				Sync();
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
			
			HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create("http://88.223.51.135/Minder.WebServices/default.asmx/Sync");
			request.ContentType = "application/json; charset=utf-8";
			request.Accept = "application/json, text/javascript, */*";
			request.Method = "POST";
			request.Timeout = 1000 * 60; //60 Seconds
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
