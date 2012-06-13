
using System;
using System.Data;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using WebService.Helpers;

namespace WebService
{
	[WebService]
	public class Soap : System.Web.Services.WebService
	{
		/// <summary>
		/// Logs into the web service
		/// </summary>
		/// <param name="userName">The User Name to login in as</param>
		/// <param name="password">User's password</param>
		/// <returns>True on successful login.</returns>
		[WebMethod(EnableSession=true)]
		public string Login(string userName, string password)
		{
			LoginHelper helper = new LoginHelper();
			int userId = helper.TryLogin(userName, password);
			return "OK";
		}
		
		/// <summary>
		/// Logs out of the Session.
		/// </summary>
		[WebMethod(EnableSession=true)]
		public void Logout()
		{
			
		}
		
	}
}
