using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using Minder.Annotations;
using Minder.Engine.Parse;
using Minder.Forms.TaskShow;
using Minder.UI.Forms.TaskShow;
using Minder.UI.SkinController.MainForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Minder.Engine.Settings
{
    public class Settings : INotifyPropertyChanged
    {
        bool _startWithWindows;
        bool _checkUpdates;
        bool _playSound;
        string _skinUniqueCode;
        string _themeUniqueCode;
        private List<ICultureData> _cultureDataValues;
        private List<RemindLaterValue> _listRemindLaterValues;

        public NewTaskHotkey NewTaskHotkey { get; set; }
        public Sync Sync { get; set; }
        public SkinsUniqueCodes SkinsUniqueCodes { get; set; }

        string _logFilePath;
        decimal _remindMeLaterDecimalValue = 10.0m / 60.0m;
        ICultureData _cultureData = new CultureDataLT();
        private RemindLaterValue _remindMeLaterValue;

        public Settings()
        {
            NewTaskHotkey = new NewTaskHotkey();
            Sync = new Sync();
            SkinsUniqueCodes = new SkinsUniqueCodes();

            _cultureDataValues = new List<ICultureData> {new CultureDataLT(), new CultureDataUK(), new CultureDataUS()};
            ListRemindLaterValues = TaskShowController.BuildRemindLaterList();

        }
        // **** Default Remind Me Later value ****
            //_form.MComboBoxRemindMeLater.DisplayMemberPath = "Name";
            //foreach (RemindLaterValue val in listRemindLaterValues) 
            //{
            //    _form.MComboBoxRemindMeLater.Items.Add(val);
            //}

            // Set index
            //for (int i = 0; i < _form.MComboBoxRemindMeLater.Items.Count; i++)
            //{
            //    if (StaticData.Settings.RemindMeLaterDecimalDecimalValue.Equals((_form.MComboBoxRemindMeLater.Items[i] as RemindLaterValue).Value))
            //    {
            //        _form.MComboBoxRemindMeLater.SelectedIndex = i;
            //        break;
            //    }
            //}

        public string ThemeUniqueCode
        {
            get { return _themeUniqueCode; }
            set { _themeUniqueCode = value; }
        }

        public RemindLaterValue RemindMyLaterDefaultValue
        {
            get
            {
                if (_remindMeLaterValue != null) return _remindMeLaterValue;
                return _listRemindLaterValues.First(x => x.Value.Equals(_remindMeLaterDecimalValue));
            }
            set
            {
                RemindMeLaterDecimalValue = value.Value;
                _remindMeLaterValue = value; 
            }
        }

        public decimal RemindMeLaterDecimalValue
        {
            get
            {
                if (RemindMyLaterDefaultValue == null)
                    return _remindMeLaterDecimalValue;
                return RemindMyLaterDefaultValue.Value;
            }
            set { _remindMeLaterDecimalValue = value; }
        }

        public ICultureData CultureData
        {
            get { return _cultureData; }
            set
            {
                if (value == null)
                {
                    _cultureData = null;
                    return;
                }
                var cultureData = CultureDataValues
                    .Where(x => x.Name != null)
                    .First(x => x.Name.Equals(value.Name));
                _cultureData = cultureData;
                TextParser.CultureData = _cultureData;
                Thread.CurrentThread.CurrentCulture = _cultureData.CultureInfo;
                Thread.CurrentThread.CurrentUICulture = _cultureData.CultureInfo;
            }
        }
        public bool StartWithWindows
        {
            get { return _startWithWindows; }
            set { _startWithWindows = value; }
        }

        public bool CheckUpdates
        {
            get { return _checkUpdates; }
            set { _checkUpdates = value; }
        }

        public bool PlaySound
        {
            get { return _playSound; }
            set { _playSound = value; }
        }

        public string SkinUniqueCode
        {
            get { return _skinUniqueCode; }
            set { _skinUniqueCode = value; }
        }

        public string LogFilePath
        {
            get { return _logFilePath; }
            set { _logFilePath = value; }
        }

        public List<ICultureData> CultureDataValues
        {
            get
            {
                return _cultureDataValues;
            }
            set { _cultureDataValues = value; }
        }

        public List<RemindLaterValue> ListRemindLaterValues
        {
            get { return _listRemindLaterValues; }
            set { _listRemindLaterValues = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class SkinsUniqueCodes
    {
        Dictionary<string, string> _skinsUniqueCodesAndNames = new Dictionary<string, string>();

        /// <summary>
        /// Skin name -> skin uniqueCode
        /// </summary>
        public Dictionary<string, string> SkinsUniqueCodesAndNames
        {
            get
            {
                AddSkinsToDic();
                return _skinsUniqueCodesAndNames;
            }
        }

        private void AddSkinsToDic()
        {
            if (_skinsUniqueCodesAndNames.Count != 0)
                return;

            //					_skinsUniqueCodesAndNames.Add("Default skin", DEFAULT_SKIN_UNIQUE_CODE);
            _skinsUniqueCodesAndNames.Add("Default skin", DefaultSkinForm.SKIN_UNIQUE_CODE);
            _skinsUniqueCodesAndNames.Add("White skin", WhiteSkin.SKIN_UNIQUE_CODE);
            _skinsUniqueCodesAndNames.Add("Black skin", BlackSkin.SKIN_UNIQUE_CODE);
            _skinsUniqueCodesAndNames.Add("Blue orange skin", BlueOrangeSkin.SKIN_UNIQUE_CODE);
        }
    }

    public class Sync
    {
        string _id = string.Empty;
        DateTime _lastSyncDate = new DateTime(2000, 1, 1);

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        bool _enable = false;

        public bool Enable
        {
            get { return _enable; }
            set { _enable = value; }
        }

        int _interval = 1;

        public int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }

        //Not in settings.ini it's in Info obj in DB
        public DateTime LastSyncDate
        {
            get { return _lastSyncDate; }
            set { _lastSyncDate = value; }
        }
    }

    public class NewTaskHotkey
    {
        bool _ctrl;
        bool _alt;
        bool _shift;
        bool _win;
        string _key;

        public bool Ctrl
        {
            get { return _ctrl; }
            set { _ctrl = value; }
        }

        public bool Alt
        {
            get { return _alt; }
            set { _alt = value; }
        }

        public bool Shift
        {
            get { return _shift; }
            set { _shift = value; }
        }

        public bool Win
        {
            get { return _win; }
            set { _win = value; }
        }

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
    }
}
