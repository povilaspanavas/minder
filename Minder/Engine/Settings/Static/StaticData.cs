
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Minder.Engine.Parse;
using Minder.UI.SkinController.MainForms;
using Minder.Engine.Settings;

namespace Minder.Static
{
   
	/// <summary>
	/// Description of StaticData.
	/// </summary>
	public static class StaticData
	{
        private static Settings _settings = Settings.Instance;
        public const string SETTINGS_FILE_PATH = "settings.ini";
		public const string SOUND_FILE_PATH = @"Sounds\sound.wav";
	
		

        public static Settings Settings { get { return _settings; } }

		public static class InfoUniqueCodes
		{
			public const string InfoLastSyncDate = "UniqueCode_InfoLastSyncDate";
		}
		
		
	}
}
