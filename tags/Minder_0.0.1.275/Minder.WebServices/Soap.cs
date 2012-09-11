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
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
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
			try
			{
				if(string.IsNullOrEmpty(json))
					return string.Empty;
				
				SyncObject syncObject = JsonHelper.OnlyJsonToObject<SyncObject>(json);
				if(syncObject == null)
					return string.Empty;
				
				string userId = syncObject.UserId;
				List<Task> tasks = syncObject.Tasks;
				
				List<Task> result = new TaskSyncController().Sync(tasks, userId);
				
				SyncObject resultObject = new SyncObject();
				resultObject.Tasks = result;
				resultObject.UserId = userId;
				
				return JsonHelper.ConvertToJson<SyncObject>(resultObject);
			}
			catch (Exception e)
			{
				return e.ToString();
			}
		}
	}
}
