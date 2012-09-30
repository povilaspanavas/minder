/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.30
 * Time: 09:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using Core.DB;
using Minder.Objects;

namespace Minder.Engine.Helpers
{
	/// <summary>
	/// Description of InfoFinder.
	/// </summary>
	public static class InfoFinder
	{
		private static Dictionary<string, Info> m_infosCache = new Dictionary<string, Info>();
		
		public static Info FindByUniqueCode(string uniqueCode)
		{
			if(string.IsNullOrEmpty(uniqueCode))
				return null;
			
			Info result = null;
			if(m_infosCache.TryGetValue(uniqueCode, out result))
				return result;
			
			List<Info> allInfos = GenericDbHelper.Get<Info>();
			
			foreach(Info info in allInfos)
			{
				if(info.UniqueCode.Equals(uniqueCode))
				{
					result = info;
					break;
				}
			}
			
			if(result != null)
				m_infosCache.Add(uniqueCode, result);
			
			return result;
		}
		
		public static void ClearCache()
		{
			m_infosCache.Clear();
		}
	}
}
