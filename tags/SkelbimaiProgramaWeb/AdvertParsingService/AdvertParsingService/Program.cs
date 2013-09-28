/*
 * Created by SharpDevelop.
 * User: Ignas T60
 * Date: 2013-09-27
 * Time: 21:38
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using AdvertModel;
using AdvertParsingService.Service;
using Core.DB;

namespace AdvertParsingService
{
	class Program
	{
		public static void Main(string[] args)
		{
			AdvertService service = new AdvertService();
			service.Start();
		}
	}
}