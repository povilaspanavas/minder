/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.08.30
 * Time: 06:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

namespace Minder.WebServices
{
	[WebService(Namespace="Minder")]
	[ScriptService]
	public class Soap : System.Web.Services.WebService
	{
		
		[WebMethod(EnableSession=true)]
		[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
		public bool Login(string userName, string password)
		{
			return false;
		}
		
	}
}
