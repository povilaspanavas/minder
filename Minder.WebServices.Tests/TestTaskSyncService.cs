/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.11
 * Time: 21:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using Minder.Engine.Sync;
using Minder.Objects;
using Minder.WebServices.Constants;
using Minder.WebServices.Objects;
using NUnit.Framework;
using PUV.WebServices.Helpers;
using System.Collections.Generic;

namespace Minder.WebServices.Tests
{
	[TestFixture]
	public class TestTaskSyncService
	{
		private string m_userId = "TEST_SERVICE";
		private DateTime m_dateOneHourAgo = DateTime.Now.AddHours(-1);
		private DateTime m_dateNow = DateTime.Now;
		[SetUp]
		public void Init()
		{
			AdminObject deleteObject = new AdminObject();
			deleteObject.UserId = m_userId;
			deleteObject.Password = ServicesConstants.DELETE_PASSWORD;
			
			string json = JsonHelper.ConvertToJson<AdminObject>(deleteObject);
			
			string requestString = "{\"json\" : \" ";
			requestString += Regex.Replace(json, "\"", "\\\"");
			requestString += "\"}";
			
			HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(string.Format("http://{0}/Minder.WebServices/Default.asmx/DeleteUserTasks", SyncController.SERVER_IP));
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
			
			Assert.IsTrue(resultJson.IndexOf("OK") != -1);
				
		}
		
		private List<Task> GetAllTaskFromServer()
		{
			AdminObject deleteObject = new AdminObject();
			deleteObject.UserId = m_userId;
			deleteObject.Password = ServicesConstants.DELETE_PASSWORD;
			
			string json = JsonHelper.ConvertToJson<AdminObject>(deleteObject);
			
			string requestString = "{\"json\" : \" ";
			requestString += Regex.Replace(json, "\"", "\\\"");
			requestString += "\"}";
			
			HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create(string.Format("http://{0}/Minder.WebServices/Default.asmx/GetUserTasks", SyncController.SERVER_IP));
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
			
			 Minder.Objects.SyncObject result = JsonHelper.JsonToObject<Minder.Objects.SyncObject>(resultJson);
			 return result.Tasks;
		}
		
		private List<Task> CreateTaskOnServerReturnSyncResult(DateTime lastSyncDate, params Task[] task)
		{
			List<Task> tasks = new List<Task>(task);
			
			Minder.Objects.SyncObject syncObject = new Minder.Objects.SyncObject();
			syncObject.LastSyncDate = lastSyncDate;
			syncObject.UserId = m_userId;
			syncObject.Tasks = tasks;
			
			return new SyncController().GetSyncedTasksFromServer(syncObject);
		}
		
		[Test]
		/// <summary>
		/// Simple case, send one task
		/// </summary>
		public void Test_01_TaskSyncService_SimpleCase()
		{
			
			string userId = "TEST_SERVICE";
			
			Task task1 = new Task(m_userId);
			task1.UserId = userId;
			task1.Text = "Test";
			task1.SourceId = "SourceIdTest";
			task1.DateRemainder = DateTime.Now.AddDays(1);
			
			List<Task> tasks = new List<Task>();
			tasks.Add(task1);
			Minder.Objects.SyncObject syncObject = new Minder.Objects.SyncObject();
			syncObject.LastSyncDate = DateTime.Now.AddHours(-1);
			syncObject.UserId = userId;
			syncObject.Tasks = tasks;
			
			List<Task> result = new SyncController().GetSyncedTasksFromServer(syncObject);
			Assert.AreEqual(1, result.Count);
			
			// We load directly, bypassing sync function and double check it
			result = GetAllTaskFromServer();
			Assert.AreEqual(1, result.Count);
		}
		
		
		[Test]
		/// <summary>
		/// Simple case, send one task, check dates
		/// </summary>
		public void Test_02_TaskSyncService_CheckFields()
		{
			Task task = new Task(m_userId);
			task.DateRemainder = m_dateNow;
			task.SourceId = "pirmasTasks";
			List<Task> result = CreateTaskOnServerReturnSyncResult(m_dateOneHourAgo, task);
			Assert.AreEqual(1, result.Count);
			
			SyncController.SetLocalDate(result.ToArray());
			Assert.AreEqual(task.SourceId, result[0].SourceId);
			Assert.AreEqual(task.DateRemainder.Date, result[0].DateRemainder.Date);
			Assert.AreEqual(task.DateRemainder.ToShortTimeString(), 
			                result[0].DateRemainder.ToShortTimeString());
			
			// We load directly, bypassing sync function and double check it
			result = GetAllTaskFromServer();
			Assert.AreEqual(1, result.Count);
			SyncController.SetLocalDate(result.ToArray());
			Assert.AreEqual(task.SourceId, result[0].SourceId);
			Assert.AreEqual(task.DateRemainder.Date, result[0].DateRemainder.Date);
			Assert.AreEqual(task.DateRemainder.ToShortTimeString(), 
			                result[0].DateRemainder.ToShortTimeString());
			
		}
		
		[Test]
		/// <summary>
		/// Sends one task, later modifies it and send again
		/// </summary>
		public void Test_03_TaskSyncService_SendOneTask_ModifyIt_SendAgain()
		{
			Task task = new Task(m_userId);
			task.DateRemainder = m_dateNow;
			task.SourceId = "pirmasTasks";
			List<Task> result = CreateTaskOnServerReturnSyncResult(m_dateOneHourAgo, task);
			Assert.AreEqual(1, result.Count);
			
			SyncController.SetLocalDate(result.ToArray());
			Assert.AreEqual(task.SourceId, result[0].SourceId);
			Assert.AreEqual(task.DateRemainder.Date, result[0].DateRemainder.Date);
			Assert.AreEqual(task.DateRemainder.ToShortTimeString(), 
			                result[0].DateRemainder.ToShortTimeString());
			
			
			task.Text = "uuuu";
			task.LastModifyDate = DateTime.Now;
			
			result = CreateTaskOnServerReturnSyncResult(m_dateOneHourAgo, task);
			Assert.AreEqual(1, result.Count);
			
			SyncController.SetLocalDate(result.ToArray());
			Assert.AreEqual(task.SourceId, result[0].SourceId);
			Assert.AreEqual(task.DateRemainder.Date, result[0].DateRemainder.Date);
			Assert.AreEqual(task.DateRemainder.ToShortTimeString(), 
			                result[0].DateRemainder.ToShortTimeString());
			Assert.AreEqual(task.Text, result[0].Text);
			
			// We load directly, bypassing sync function and double check it
			result = GetAllTaskFromServer();
			Assert.AreEqual(1, result.Count);
			SyncController.SetLocalDate(result.ToArray());
			Assert.AreEqual(task.Text, result[0].Text);
			Assert.AreEqual(task.SourceId, result[0].SourceId);
			Assert.AreEqual(task.DateRemainder.Date, result[0].DateRemainder.Date);
			Assert.AreEqual(task.DateRemainder.ToShortTimeString(), 
			                result[0].DateRemainder.ToShortTimeString());
		}
		
		[Test]
		/// <summary>
		/// Sends one task, later deletes it and sends again
		/// </summary>
		public void Test_04_TaskSyncService_Delete()
		{
			Task task = new Task(m_userId);
			task.DateRemainder = m_dateNow;
			task.SourceId = "pirmasTasks";
			List<Task> result = CreateTaskOnServerReturnSyncResult(m_dateOneHourAgo, task);
			Assert.AreEqual(1, result.Count);
			
			SyncController.SetLocalDate(result.ToArray());
			Assert.AreEqual(task.SourceId, result[0].SourceId);
			Assert.AreEqual(task.DateRemainder.Date, result[0].DateRemainder.Date);
			Assert.AreEqual(task.DateRemainder.ToShortTimeString(), 
			                result[0].DateRemainder.ToShortTimeString());
			
			
			task.IsDeleted = true;
			task.LastModifyDate = DateTime.Now;
			
			result = CreateTaskOnServerReturnSyncResult(m_dateOneHourAgo, task);
			Assert.AreEqual(0, result.Count);
			
			// We load directly, bypassing sync function and double check it
			result = GetAllTaskFromServer();
			Assert.AreEqual(0, result.Count);
		}
		
		[Test]
		/// <summary>
		/// We check that new computer will get tasks. It means, we don't send any tasks,
		/// because new computer doesn't have them. But we expect to get all the tasks
		/// from server
		/// </summary>
		public void Test_05_TaskSyncService_NewComputerSync()
		{
			Task task = new Task(m_userId);
			task.UserId = m_userId;
			task.DateRemainder = m_dateNow;
			task.SourceId = "pirmasTasks";
			List<Task> result = CreateTaskOnServerReturnSyncResult(m_dateOneHourAgo, task);
			Assert.AreEqual(1, result.Count);
			
			result = CreateTaskOnServerReturnSyncResult(m_dateOneHourAgo);
			Assert.AreEqual(1, result.Count);
		}
		
		[Test]
		/// <summary>
		/// We check that new computer will get tasks
		/// </summary>
		public void TestTaskSyncService_Delete3()
		{
			Task task = new Task(m_userId);
			task.DateRemainder = m_dateNow;
			task.SourceId = "pirmasTasks";
			task.UserId = m_userId;
			List<Task> result = CreateTaskOnServerReturnSyncResult(m_dateOneHourAgo, task);
			Assert.AreEqual(1, result.Count);
			
			SyncController.SetLocalDate(result.ToArray());
			Assert.AreEqual(task.SourceId, result[0].SourceId);
			Assert.AreEqual(task.DateRemainder.Date, result[0].DateRemainder.Date);
			Assert.AreEqual(task.DateRemainder.ToShortTimeString(), 
			                result[0].DateRemainder.ToShortTimeString());
			
			result = GetAllTaskFromServer();
			
			Assert.AreEqual(1, result.Count);
			SyncController.SetLocalDate(result.ToArray());
//			SyncController.SetLocalDate(result.ToArray());
			Assert.AreEqual(task.SourceId, result[0].SourceId);
			Assert.AreEqual(task.DateRemainder.Date, result[0].DateRemainder.Date);
			Assert.AreEqual(task.DateRemainder.ToShortTimeString(), 
			                result[0].DateRemainder.ToShortTimeString());
		}

	}
}
