using Minder.Engine.Parse;
using Minder.UI.SkinController.MainForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Minder.Engine.Settings
{
    public class Settings
    {
        bool m_startWithWindows;
        bool m_checkUpdates;
        bool m_playSound;
        string m_skinUniqueCode;
        string m_themeUniqueCode;

        public NewTaskHotkey NewTaskHotkey { get; set;}
        public Sync Sync { get; set;}
        public SkinsUniqueCodes SkinsUniqueCodes { get; set;}

         string m_logFilePath;
         decimal m_remindMeLaterValue = 10.0m / 60.0m;
         ICultureData m_cultureData = new CultureDataLT();

         public Settings()
         {
             NewTaskHotkey = new NewTaskHotkey();
             Sync = new Sync();
             SkinsUniqueCodes = new SkinsUniqueCodes();
         }

        public string ThemeUniqueCode
        {
            get { return m_themeUniqueCode; }
            set { m_themeUniqueCode = value; }
        }

        public decimal RemindMeLaterDefaultValue
        {
            get { return m_remindMeLaterValue; }
            set { m_remindMeLaterValue = value; }
        }

        public ICultureData CultureData
        {
            get { return m_cultureData; }
            set
            {
                m_cultureData = value;
                TextParser.CultureData = m_cultureData;
                Thread.CurrentThread.CurrentCulture = m_cultureData.CultureInfo;
                Thread.CurrentThread.CurrentUICulture = m_cultureData.CultureInfo;
            }
        }
        public bool StartWithWindows
        {
            get { return m_startWithWindows; }
            set { m_startWithWindows = value; }
        }

        public bool CheckUpdates
        {
            get { return m_checkUpdates; }
            set { m_checkUpdates = value; }
        }

        public bool PlaySound
        {
            get { return m_playSound; }
            set { m_playSound = value; }
        }

        public string SkinUniqueCode
        {
            get { return m_skinUniqueCode; }
            set { m_skinUniqueCode = value; }
        }

        public string LogFilePath
        {
            get { return m_logFilePath; }
            set { m_logFilePath = value; }
        }

        

        

        
    }

    public class SkinsUniqueCodes
    {
        Dictionary<string, string> m_skinsUniqueCodesAndNames = new Dictionary<string, string>();

        /// <summary>
        /// Skin name -> skin uniqueCode
        /// </summary>
        public Dictionary<string, string> SkinsUniqueCodesAndNames
        {
            get
            {
                AddSkinsToDic();
                return m_skinsUniqueCodesAndNames;
            }
        }

        private void AddSkinsToDic()
        {
            if (m_skinsUniqueCodesAndNames.Count != 0)
                return;

            //					m_skinsUniqueCodesAndNames.Add("Default skin", DEFAULT_SKIN_UNIQUE_CODE);
            m_skinsUniqueCodesAndNames.Add("Default skin", DefaultSkinForm.SKIN_UNIQUE_CODE);
            m_skinsUniqueCodesAndNames.Add("White skin", WhiteSkin.SKIN_UNIQUE_CODE);
            m_skinsUniqueCodesAndNames.Add("Black skin", BlackSkin.SKIN_UNIQUE_CODE);
            m_skinsUniqueCodesAndNames.Add("Blue orange skin", BlueOrangeSkin.SKIN_UNIQUE_CODE);
        }
    }

    public class Sync
    {
        string m_id = string.Empty;
        DateTime m_lastSyncDate = new DateTime(2000, 1, 1);

        public string Id
        {
            get { return m_id; }
            set { m_id = value; }
        }

        bool m_enable = false;

        public bool Enable
        {
            get { return m_enable; }
            set { m_enable = value; }
        }

        int m_interval = 1;

        public int Interval
        {
            get { return m_interval; }
            set { m_interval = value; }
        }

        //Not in settings.ini it's in Info obj in DB
        public DateTime LastSyncDate
        {
            get { return m_lastSyncDate; }
            set { m_lastSyncDate = value; }
        }
    }

    public class NewTaskHotkey
    {
        bool m_ctrl;
        bool m_alt;
        bool m_shift;
        bool m_win;
        string m_key;

        public bool Ctrl
        {
            get { return m_ctrl; }
            set { m_ctrl = value; }
        }

        public bool Alt
        {
            get { return m_alt; }
            set { m_alt = value; }
        }

        public bool Shift
        {
            get { return m_shift; }
            set { m_shift = value; }
        }

        public bool Win
        {
            get { return m_win; }
            set { m_win = value; }
        }

        public string Key
        {
            get { return m_key; }
            set { m_key = value; }
        }
    }
}
