/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.06.21
 * Time: 18:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Minder.Objects;

namespace Minder.Engine
{
	public class TimeEngine
	{
		public static event TaskChanged TaskChangedEvent;
		public delegate void TaskChanged(Task task);
		
		public static void FireTaskChangedEvent(Task task)
		{
			if (TaskChangedEvent != null)
				TaskChangedEvent(task);
		}
	}
	
}
