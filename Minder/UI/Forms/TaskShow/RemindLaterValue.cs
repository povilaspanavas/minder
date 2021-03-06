﻿/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.08.15
 * Time: 16:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Minder.Engine.Helpers;

namespace Minder.UI.Forms.TaskShow
{
	/// <summary>
	/// Description of RemindLaterValue.
	/// </summary>
	public class RemindLaterValue
	{
		string name;
		decimal val;
		
		public string Name {
			get { return name; }
			set { name = value; }
		}
		
		public decimal Value {
			get { return Round(val); }
			set { val = value; }
		}
		
		public RemindLaterValue(string name, decimal val)
		{
			this.name = name;
			this.val = val;
		}
		
		public static decimal Round(decimal val)
		{
			return RoundHelper.Round(val, 10);
		}

	    public bool Equals(RemindLaterValue obj)
	    {
	        if (obj == null) return false;
	        return this.Value.Equals(obj.Value);
	    }
	}
}
