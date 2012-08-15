/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 08/15/2012
 * Time: 13:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Minder.Static;
using Minder.UI.SkinController.MainForms.DefaultSkin;

namespace Minder.UI.SkinController
{
	/// <summary>
	/// Description of MainFormCollector.
	/// </summary>
	public class MainFormCollector
	{
		public IMainForm GetForm()
		{
			if(StaticData.Settings.SkinUniqueCode.ToLower()
			   .Equals(StaticData.Settings.SkinsUniqueCodes.DEFAULT_SKIN_UNIQUECODE.ToLower()))
			return new DefaultSkinForm();
			
			else
				return null;
		}
	}
}
