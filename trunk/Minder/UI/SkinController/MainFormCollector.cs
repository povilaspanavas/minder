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
using Minder.UI.SkinController.MainForms;

namespace Minder.UI.SkinController
{
	/// <summary>
	/// Description of MainFormCollector.
	/// </summary>
	public class MainFormCollector
	{
		public AbstractMainForm GetForm()
		{
			string skinUniqueCode = StaticData.Settings.SkinUniqueCode.ToUpper();
			switch(skinUniqueCode)
			{
				case DefaultSkinForm.SKIN_UNIQUE_CODE:
					return new DefaultSkinForm();
				case WhiteSkin.SKIN_UNIQUE_CODE:
					return new WhiteSkin();
				case BlackSkin.SKIN_UNIQUE_CODE:
					return new BlackSkin();
				default:
					return new BlackSkin();
			}
		}
	}
}
