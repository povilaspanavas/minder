/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.10
 * Time: 00:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using EasyRemainder.Objects;

namespace EasyRemainder.Engine
{
	/// <summary>
	/// Description of TasksController.
	/// </summary>
	public class TasksController
	{
		private DateTimeParser dateParser = null;
		
		public bool CreateTask(string text)
		{
			dateParser = new DateTimeParser();
			
			if(string.IsNullOrEmpty(text))
				return false;
			DateTime date = dateParser.ParseDateTime(ref text);
			if(DateTime.Compare(date, DateTime.MinValue) == 0)
				return false;
			
			Task task = new Task();
//			task.OriginalDateTime = dateParser.OriginalDateTime;
			task.DateRemainder = date;
			task.Text = dateParser.LeftText;
			
			
			
			return true;
		}
	}
}
