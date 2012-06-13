
using System;
using System.Collections.Generic;
using Core;
using Core.DB;
using EasyRemainder.Objects;

namespace WebService.Helpers
{
	/// <summary>
	/// Description of LoginHelper.
	/// </summary>
	public class LoginHelper
	{
		public LoginHelper()
		{
			ConfigLoader.LoadConfiguration(false, @"d:\Projektai\Easy remainder\trunk\WebService\bin");
		}
		
		public int TryLogin(string userName, string password)
		{
			List<Human> allHumans = GenericDbHelper.Get<Human>();
			return allHumans.Count;
		}
	}
}
