/*
 * Created by SharpDevelop.
 * User: Povilas
 * Date: 2012.09.15
 * Time: 00:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Minder.Objects;
using Minder.Sql.DBVersionSystem;
using NUnit.Framework;

namespace Minder.Tests.DB
{
	[TestFixture]
	public class TestDBVersionSystem
	{
		[Test]
		public void Test1()
		{
			DBVersionRepository repo = new DBVersionRepository()
				.AddVersions(typeof(Task).Assembly)
				;
			Assert.GreaterOrEqual(2, repo.VersionsTable.Count);
			
			DBVersionSystem system = new DBVersionSystem(repo);
		}
	}
}
