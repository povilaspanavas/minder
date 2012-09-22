///*
// * Created by SharpDevelop.
// * User: Ignas
// * Date: 2012.09.11
// * Time: 21:54
// * 
// * To change this template use Tools | Options | Coding | Edit Standard Headers.
// */
//using System;
//using System.IO;
//using System.Net;
//using System.Text.RegularExpressions;
//using Minder.WebServices.Objects;
//using NUnit.Framework;
//using PUV.WebServices.Helpers;
//
//namespace Minder.WebServices.Tests
//{
//	[TestFixture]
//	public class TestTaskSyncService
//	{
//		
//		[Test]
//		public void TestTaskSyncService_1()
//		{
//			//Create data
//			string userId = "Ignas123";
//			
//			TaskSync task1 = new TaskSync();
//			task1.DateRemainderString = DateTime.Now;
//			task1.IsDeleted = false;
//			task1.Showed = false;
//			task1.UserId = userId;
//			task1.Text = "task1";
//			task1.LastModifyDateString = DateTime.Now.AddMinutes(-5);
//			task1.SourceId = string.Format("{0}{1}{2}", DateTime.Now, task1.DateRemainderString, task1.Text);
//			
//			TaskSync task2 = new TaskSync();
//			task2.DateRemainderString = DateTime.Now;
//			task2.IsDeleted = false;
//			task2.Showed = false;
//			task2.UserId = userId;
//			task2.Text = "task2";
//			task2.LastModifyDateString = DateTime.Now.AddMinutes(-5);
//			task2.SourceId = string.Format("{0}{1}{2}", DateTime.Now, task2.DateRemainderString, task2.Text);
//			
//			SyncObject syncObject = new SyncObject();
//			syncObject.Tasks = new System.Collections.Generic.List<TaskSync>();
//			syncObject.Tasks.Add(task1);
//			syncObject.Tasks.Add(task2);
//			syncObject.UserId = userId;
//			
//			string json = JsonHelper.ConvertToJson<SyncObject>(syncObject);
//			
//			string requestString = "{\"json\" : \" ";
//			requestString += Regex.Replace(json, "\"", "\\\"");
////			requestString += "Ignas";
//			requestString += "\"}";
//			
//			HttpWebRequest request = (HttpWebRequest) HttpWebRequest.Create("http://localhost/Minder.WebServices/default.asmx/Sync");
//			request.ContentType = "application/json; charset=utf-8";
//			request.Accept = "application/json, text/javascript, */*";
//			request.Method = "POST";
//			request.Timeout = 10000000;
//			using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
//			{
//				writer.Write(requestString);
//			}
//
//			WebResponse response = request.GetResponse();
//			Stream stream = response.GetResponseStream();
//			string resultJson = "";
//
//			using (StreamReader reader = new StreamReader(stream))
//			{
//				while (!reader.EndOfStream)
//				{
//					resultJson += reader.ReadLine();
//				}
//			}
//			
//			SyncObject result = JsonHelper.JsonToObject<SyncObject>(resultJson);
//
//		}
//	}
//}
