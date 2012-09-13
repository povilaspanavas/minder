/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.09.11
 * Time: 20:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Core;
using Core.DB;
using Minder.WebServices.Objects;
using NUnit.Framework;

namespace Minder.WebServices
{
	[TestFixture]
	public class DbCreator
	{
		[Test]
		public void DbCreator_1()
		{
			ConfigLoader.Load();
			GenericDbHelper.DropAllTables();
			GenericDbHelper.CreateTable(typeof(TaskSync));
		}
	}
}
