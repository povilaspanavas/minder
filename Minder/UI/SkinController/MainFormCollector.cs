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
			string skinUniqueCode = StaticData.Settings.SkinsUniqueCodes.SelectedSkin.ToUpper();
			switch(skinUniqueCode)
			{
				case DefaultSkinForm.SKIN_UNIQUE_CODE:
					return new DefaultSkinForm();
				case WhiteSkin.SKIN_UNIQUE_CODE:
					return new WhiteSkin();
				case BlackSkin.SKIN_UNIQUE_CODE:
					return new BlackSkin();
				case BlueOrangeSkin.SKIN_UNIQUE_CODE:
					return new BlueOrangeSkin();
				default:
					return new BlackSkin();
			}
		}
	}
}
