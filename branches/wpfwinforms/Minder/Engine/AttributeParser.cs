/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.09.14
 * Time: 14:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;

namespace Minder.Engine
{
	/// <summary>
	/// Description of Minder.Engine.AttributeParser.
	/// </summary>
	public class AttributeParser
	{
		public static T GetAttribute<T>(Type type) where T : class
		{
			object[] attributes = type.GetCustomAttributes(typeof(T), true);
			if (attributes.Length == 0)
				return null;
			return attributes[0] as T;
		}
		
		public static T GetAttribute<T>(MethodInfo mi) where T: class
		{
			object[] attributes = mi.GetCustomAttributes(typeof(T), true);
			if (attributes.Length == 0)
				return null;
			return attributes[0] as T;
		}
	}
}
