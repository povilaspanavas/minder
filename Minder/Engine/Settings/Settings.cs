using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
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
using WPF.Themes;

namespace Minder.Engine.Settings
{
    public class Settings : NotifyPropertyChanged
    {
        bool _startWithWindows;
        bool _checkUpdates;
        bool _playSound;
        string _themeUniqueCode;
        public string LogFilePath { get; set; }
        public List<ICultureData> CultureDataValues { get; set; }
        public List<RemindLaterValue> ListRemindLaterValues { get; set; }

        public NewTaskHotkey NewTaskHotkey { get; set; }
        public Sync Sync { get; set; }
        public SkinsUniqueCodes SkinsUniqueCodes { get; set; }

        decimal _remindMeLaterDecimalValue = 10.0m / 60.0m;
        ICultureData _cultureData = new CultureDataLT();
        private RemindLaterValue _remindMeLaterValue;

        public static readonly Settings Instance = new Settings();

        private Settings()
        {
            NewTaskHotkey = new NewTaskHotkey();
            NewTaskHotkey.PropertyChanged += (sender, args) => OnPropertyChanged("NewTaskHotkey");
            
            Sync = new Sync();
            Sync.PropertyChanged += (sender, args) => OnPropertyChanged("Sync");
            
            SkinsUniqueCodes = new SkinsUniqueCodes();
            SkinsUniqueCodes.PropertyChanged += (sender, args) => OnPropertyChanged("SkinsUniqueCodes");

            CultureDataValues = new List<ICultureData> { new CultureDataLT(), new CultureDataUK(), new CultureDataUS() };
            ListRemindLaterValues = TaskShowController.BuildRemindLaterList();

        }

        public string ThemeUniqueCode
        {
            get { return _themeUniqueCode; }
            set
            {
                _themeUniqueCode = ThemeManager.GetThemes.First(theme => theme.ToUpper().Equals(value));
                OnPropertyChanged("ThemeUniqueCode");
            }
        }

        public RemindLaterValue RemindMyLaterDefaultValue
        {
            get
            {
                if (_remindMeLaterValue != null) return _remindMeLaterValue;
                return ListRemindLaterValues.First(x => x.Value.Equals(_remindMeLaterDecimalValue));
            }
            set
            {
                RemindMeLaterDecimalValue = value.Value;
                _remindMeLaterValue = value;
                OnPropertyChanged("RemindMyLaterDefaultValue");
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
                OnPropertyChanged("CultureData");
            }
        }
        public bool StartWithWindows
        {
            get { return _startWithWindows; }
            set
            {
                _startWithWindows = value; 
                OnPropertyChanged("StartWithWindows");
            }
        }

        public bool CheckUpdates
        {
            get { return _checkUpdates; }
            set
            {
                _checkUpdates = value;
                OnPropertyChanged("CheckUpdates");
            }
        }

        public bool PlaySound
        {
            get { return _playSound; }
            set
            {
                _playSound = value;
                OnPropertyChanged("PlaySound");
            }
        }
    }

    public class SkinsUniqueCodes : NotifyPropertyChanged
    {
        readonly Dictionary<string, string> _skinsUniqueCodesAndNames = new Dictionary<string, string>();
        private string _selectedSkin;

        public SkinsUniqueCodes()
        {
            //					_skinsUniqueCodesAndNames.Add("Default skin", DEFAULT_SKIN_UNIQUE_CODE);
            _skinsUniqueCodesAndNames.Add("Default skin", DefaultSkinForm.SKIN_UNIQUE_CODE);
            _skinsUniqueCodesAndNames.Add("White skin", WhiteSkin.SKIN_UNIQUE_CODE);
            _skinsUniqueCodesAndNames.Add("Black skin", BlackSkin.SKIN_UNIQUE_CODE);
            _skinsUniqueCodesAndNames.Add("Blue orange skin", BlueOrangeSkin.SKIN_UNIQUE_CODE);
        }
        /// <summary>
        /// Skin name -> skin uniqueCode
        /// </summary>
        public Dictionary<string, string> SkinsUniqueCodesAndNames
        {
            get
            {
                return _skinsUniqueCodesAndNames;
            }
        }

        public string SelectedSkin
        {
            get { return _selectedSkin; }
            set
            {
                _selectedSkin = value;
                OnPropertyChanged("SelectedSkin");
            }
        }
    }

    public class Sync : NotifyPropertyChanged
    {
        bool _enable = false;
        int _interval = 30;
        string _id = string.Empty;
        DateTime _lastSyncDate = new DateTime(2000, 1, 1);

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value; 
                OnPropertyChanged("Id");
            }
        }

        public bool Enable
        {
            get { return _enable; }
            set
            {
                _enable = value;
                OnPropertyChanged("Enable");
            }
        }

        public int Interval
        {
            get { return _interval; }
            set
            {
                _interval = value;
                OnPropertyChanged("Interval");
                
            }
        }

        //Not in settings.ini it's in Info obj in DB
        public DateTime LastSyncDate
        {
            get { return _lastSyncDate; }
            set { _lastSyncDate = value; }
        }
    }

    public class NewTaskHotkey : NotifyPropertyChanged
    {
        private string _key;
        private bool _ctrl;
        private bool _alt;
        private bool _shift;
        private bool _win;


        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged("Key");
            }
        }
        public bool Ctrl
        {
            get { return _ctrl; }
            set
            {
                _ctrl = value;
                OnPropertyChanged("Ctrl");
            }
        }

        public bool Alt
        {
            get { return _alt; }
            set
            {
                _alt = value;
                OnPropertyChanged("Alt");
            }
        }

        public bool Shift
        {
            get { return _shift; }
            set
            {
                _shift = value;
                OnPropertyChanged("Shift");
            }
        }

        public bool Win
        {
            get { return _win; }
            set
            {
                _win = value;
                OnPropertyChanged("Win");
            }
        }
        private readonly Dictionary<string, Keys> _keysDic = new Dictionary<string, Keys>();

        public NewTaskHotkey()
        {
            AddKeysToDic();
            //_keysDic.Keys[;
        }


        public Dictionary<string, Keys> KeysDic
        {
            get
            {
                AddKeysToDic();
                return _keysDic;
            }
        }



        private void AddKeysToDic()
        {
            if (_keysDic.Count != 0)
                return;

            _keysDic.Add("F1", Keys.F1);
            _keysDic.Add("F2", Keys.F2);
            _keysDic.Add("F3", Keys.F3);
            _keysDic.Add("F4", Keys.F4);
            _keysDic.Add("F5", Keys.F5);
            _keysDic.Add("F6", Keys.F6);
            _keysDic.Add("F7", Keys.F7);
            _keysDic.Add("F8", Keys.F8);
            _keysDic.Add("F9", Keys.F9);
            _keysDic.Add("F10", Keys.F10);
            _keysDic.Add("F11", Keys.F11);
            _keysDic.Add("F12", Keys.F12);

            _keysDic.Add("A", Keys.A);
            _keysDic.Add("B", Keys.B);
            _keysDic.Add("C", Keys.C);
            _keysDic.Add("D", Keys.D);
            _keysDic.Add("E", Keys.E);
            _keysDic.Add("F", Keys.F);
            _keysDic.Add("G", Keys.G);
            _keysDic.Add("H", Keys.H);
            _keysDic.Add("I", Keys.I);
            _keysDic.Add("Y", Keys.Y);
            _keysDic.Add("J", Keys.J);
            _keysDic.Add("K", Keys.K);
            _keysDic.Add("L", Keys.L);
            _keysDic.Add("M", Keys.M);
            _keysDic.Add("N", Keys.N);
            _keysDic.Add("P", Keys.P);
            _keysDic.Add("R", Keys.R);
            _keysDic.Add("S", Keys.S);
            _keysDic.Add("Q", Keys.Q);
            _keysDic.Add("T", Keys.T);
            _keysDic.Add("U", Keys.U);
            _keysDic.Add("V", Keys.V);
            _keysDic.Add("W", Keys.W);
            _keysDic.Add("X", Keys.X);
            _keysDic.Add("Z", Keys.Z);

            _keysDic.Add("0", Keys.NumPad0);
            _keysDic.Add("1", Keys.NumPad1);
            _keysDic.Add("2", Keys.NumPad2);
            _keysDic.Add("3", Keys.NumPad3);
            _keysDic.Add("4", Keys.NumPad4);
            _keysDic.Add("5", Keys.NumPad5);
            _keysDic.Add("6", Keys.NumPad6);
            _keysDic.Add("7", Keys.NumPad7);
            _keysDic.Add("8", Keys.NumPad8);
            _keysDic.Add("9", Keys.NumPad9);
        }

       
    }
}
