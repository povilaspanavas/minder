/*
 * Created by SharpDevelop.
 * User: Ignas T60
 * Date: 2013-09-28
 * Time: 20:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using AdvertModel;

namespace AdvertParsingService.Modules
{
	/// <summary>
	/// Description of IModule.
	/// </summary>
	public interface IModule
	{
		List<Advert> Parse(string url);
	}
	
}
