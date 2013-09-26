/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.09.15
 * Time: 01:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Minder.Engine.Helpers
{
	/// <summary>
	/// Description of RoundHelper.
	/// </summary>
	public class RoundHelper
	{
		public static decimal Round(decimal val, int precision)
		{
			return Math.Round(val, precision, MidpointRounding.AwayFromZero);
		}
	}
}
