/*
 * Created by SharpDevelop.
 * User: Ignas.Bagdonas
 * Date: 2013-06-20
 * Time: 18:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Minder.WebServices.Objects
{
	/// <summary>
	/// Description of DeleteObject.
	/// </summary>
	public class DeleteObject
	{
		private string m_userId = string.Empty;
		private string m_password = string.Empty;
		
		public string UserId {
			get { return m_userId; }
			set { m_userId = value; }
		}

		public string Password {
			get { return m_password; }
			set { m_password = value; }
		}
	}
}
