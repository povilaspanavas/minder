/*
 * Created by SharpDevelop.
 * User: Ignas.Bagdonas
 * Date: 2013-06-20
 * Time: 19:26
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using Core;

namespace Minder.WebServices.Helpers
{
	/// <summary>
	/// Description of ConfigHelper.
	/// </summary>
	public class ConfigHelper
	{
		public void Load()
		{
			if(Minder.WebServices.Helpers.StaticData.ConfigLoaded == false)
			{
				ConfigLoader.Load(@"d:\Projektai\Minder_trunk\Minder.WebServices\bin\CoreConfig.xml");
				FileInfo config = new FileInfo(@"d:\Projektai\Minder_trunk\Minder.WebServices\bin\MinderWebServices.log4net.xml");
				log4net.Config.XmlConfigurator.Configure(config);
				Minder.WebServices.Helpers.StaticData.ConfigLoaded = true;
			}
		}
	}
}
