/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.11
 * Time: 21:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Minder.WebServices.Helpers
{
	/// <summary>
	/// Description of StaicData.
	/// </summary>
	public static class StaticData
	{
		static bool m_configLoaded = false;
		
		public static bool ConfigLoaded {
			get { return m_configLoaded; }
			set { m_configLoaded = value; }
		}
	}
}
