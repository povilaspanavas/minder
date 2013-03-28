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
using NUnit.Framework;
using PUV.WebServices.Helpers;
using System.Collections.Generic;

namespace Minder.WebServices.Tests
{
	[TestFixture]
	public class TestTaskSyncService
	{
		[Test]
		public void TestTaskSyncService_1()
		{
			string userId = "TEST_SERVICE";
			
			Task task1 = new Task();
			task1.UserId = userId;
			task1.LastModifyDate = DateTime.Now;
			task1.Text = "Test";
			task1.SourceId = "SourceIdTest";
			task1.DateRemainder = DateTime.Now.AddDays(1);
			
			List<Task> tasks = new List<Task>();
			tasks.Add(task1);
			SyncObject syncObject = new SyncObject();
			syncObject.LastSyncDate = DateTime.Now.AddHours(-1);
			syncObject.UserId = userId;
			syncObject.Tasks = tasks;
			
			List<Task> result = new SyncController().GetSyncedTasksFromServer(syncObject);
			Assert.AreEqual(1, result.Count);
		}
		
//		[Test]
//		public void TestTaskSyncService_2()
//		{
//			string userId = "TEST_SERVICE";
//			
////			Task task1 = new Task();
////			task1.UserId = userId;
////			task1.LastModifyDate = DateTime.Now;
////			task1.Text = "Test";
////			task1.SourceId = "SourceIdTest";
////			task1.DateRemainder = DateTime.Now.AddDays(1);
//			
////			List<Task> tasks = new List<Task>();
////			tasks.Add(task1);
//			SyncObject syncObject = new SyncObject();
//			syncObject.LastSyncDate = DateTime.Now.AddHours(-1);
//			syncObject.UserId = userId;
////			syncObject.Tasks = tasks;
//			
//			List<Task> result = new SyncController().GetSyncedTasksFromServer(syncObject);
//			Assert.AreEqual(1, result.Count);
//		}
	}
}
