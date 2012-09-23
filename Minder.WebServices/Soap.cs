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
using Core.Tools.Log;
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
			if(Minder.WebServices.Helpers.StaticData.ConfigLoaded == false)
			{
				ConfigLoader.Load(@"c:\Dokumentai\Projektai\Minder\Minder.WebServices\bin\CoreConfig.xml");
				FileInfo config = new FileInfo(@"c:\Dokumentai\Projektai\Minder\Minder.WebServices\bin\MinderWebServices.log4net.xml");
				log4net.Config.XmlConfigurator.Configure(config);
			}
			
			log4net.ILog log = log4net.LogManager.GetLogger(typeof(Soap));
			
			try
			{
				if(string.IsNullOrEmpty(json))
					return string.Empty;
				log.Info("Started sync...");
				
				SyncObject syncObject = JsonHelper.OnlyJsonToObject<SyncObject>(json);
				if(syncObject == null)
					return string.Empty;
				
				string userId = syncObject.UserId;
				List<TaskSync> tasks = syncObject.Tasks;
				
				List<TaskSync> result = new TaskSyncController().Sync(tasks, userId);
				
				SyncObject resultObject = new SyncObject();
				resultObject.Tasks = result;
				resultObject.UserId = userId;
				
				string jsonResult = JsonHelper.ConvertToJson<SyncObject>(resultObject);
				log.InfoFormat("Successfully synced for user: {0}", userId);
				return jsonResult;
			}
			catch (Exception e)
			{
				log.Error(e);
				return e.ToString();
			}
		}
	}
}
