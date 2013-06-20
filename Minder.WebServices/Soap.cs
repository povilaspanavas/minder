/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.08.30
 * Time: 06:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using Core;
using Core.DB;
using Core.Tools.Log;
using Minder.WebServices.Constants;
using Minder.WebServices.Objects;
using Minder.WebServices.Services;
using PUV.WebServices.Helpers;

namespace Minder.WebServices
{
	[WebService(Namespace="Minder")]
	[ScriptService]
	public class Soap : System.Web.Services.WebService
	{
		
		[WebMethod(EnableSession=true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public string Sync(string json)
		{
			log4net.ILog log = log4net.LogManager.GetLogger(typeof(Soap));
			if(Minder.WebServices.Helpers.StaticData.ConfigLoaded == false)
			{
				ConfigLoader.Load(@"d:\Projektai\Minder_trunk\Minder.WebServices\bin\CoreConfig.xml");
				FileInfo config = new FileInfo(@"d:\Projektai\Minder_trunk\Minder.WebServices\bin\MinderWebServices.log4net.xml");
				log4net.Config.XmlConfigurator.Configure(config);
				Minder.WebServices.Helpers.StaticData.ConfigLoaded = true;
				log.Info("Service started...");
			}
			
			
			
			try
			{
				if(string.IsNullOrEmpty(json))
					return string.Empty;
				DateTime startTime = DateTime.Now;
				log.Info("Started sync...");
				
				SyncObject syncObject = JsonHelper.OnlyJsonToObject<SyncObject>(json);
				if(syncObject == null)
					return string.Empty;
				
				string userId = syncObject.UserId;
				List<TaskSync> tasks = syncObject.Tasks;
				DateTime lastSyncDate = syncObject.LastSyncDate;
				
				List<TaskSync> result = new TaskSyncController().Sync(tasks, userId, lastSyncDate);
				foreach (TaskSync taskSyn in result) {
					taskSyn.DateRemainder = taskSyn.DateRemainder.ToLocalTime();
					taskSyn.LastModifyDate = taskSyn.LastModifyDate.ToLocalTime();
				}
				
				SyncObject resultObject = new SyncObject();
				resultObject.Tasks = result;
				resultObject.UserId = userId;
				resultObject.LastSyncDate = lastSyncDate;
				
				string jsonResult = JsonHelper.ConvertToJson<SyncObject>(resultObject);
				TimeSpan span = DateTime.Now - startTime;
				log.InfoFormat("Successfully synced for user: {0} {1} seconds", userId, span.TotalSeconds);
				return jsonResult;
			}
			catch (Exception e)
			{
				log.Error(e);
				return e.ToString();
			}
		}
		
		[WebMethod(EnableSession=true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public string DeleteUserTasks(string json)
		{
			log4net.ILog log = log4net.LogManager.GetLogger(typeof(Soap));
			if(Minder.WebServices.Helpers.StaticData.ConfigLoaded == false)
			{
				ConfigLoader.Load(@"d:\Projektai\Minder_trunk\Minder.WebServices\bin\CoreConfig.xml");
				FileInfo config = new FileInfo(@"d:\Projektai\Minder_trunk\Minder.WebServices\bin\MinderWebServices.log4net.xml");
				log4net.Config.XmlConfigurator.Configure(config);
				Minder.WebServices.Helpers.StaticData.ConfigLoaded = true;
				log.Info("Service started...");
			}

			try
			{
				if(string.IsNullOrEmpty(json))
					return string.Empty;
	
				DeleteObject deleteObject = JsonHelper.OnlyJsonToObject<DeleteObject>(json);
				if(deleteObject == null)
					return string.Empty;
				
				string userId = deleteObject.UserId;
				string password = deleteObject.Password;
				if(ServicesConstants.DELETE_PASSWORD.Equals(password) == false || 
				   string.IsNullOrEmpty(userId))
					return string.Empty;
				
				GenericDbHelper.RunDirectSql(string.Format("DELETE FROM TASK WHERE USER_ID = '{0}'", userId));
				return "OK";
			}
			catch (Exception e)
			{
				log.Error(e);
				return e.ToString();
			}
		}
	}
}
