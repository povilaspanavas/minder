/*
 * Created by SharpDevelop.
 * User: Ignas T60
 * Date: 2013-09-28
 * Time: 19:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Threading;

namespace AdvertParsingServiceStarter
{
	class Program
	{
		public static void Main(string[] args)
		{
			new Runer().Run();
			Console.ReadKey(true);
		}
	}
}