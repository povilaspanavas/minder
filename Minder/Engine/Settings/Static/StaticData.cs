
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

using Minder.Engine.Parse;
using Minder.UI.SkinController.MainForms;

namespace Minder.Static
{
    //[Editor("System.Windows.Forms.Design.ShortcutKeysEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor)), TypeConverter(typeof(KeysConverter)), Flags, ComVisible(true)]
    public enum Keys
    {
        KeyCode = 65535,
        Modifiers = -65536,
        None = 0,
        LButton = 1,
        RButton = 2,
        Cancel = 3,
        MButton = 4,
        XButton1 = 5,
        XButton2 = 6,
        Back = 8,
        Tab = 9,
        LineFeed = 10,
        Clear = 12,
        Return = 13,
        Enter = 13,
        ShiftKey = 16,
        ControlKey = 17,
        Menu = 18,
        Pause = 19,
        Capital = 20,
        CapsLock = 20,
        KanaMode = 21,
        HanguelMode = 21,
        HangulMode = 21,
        JunjaMode = 23,
        FinalMode = 24,
        HanjaMode = 25,
        KanjiMode = 25,
        Escape = 27,
        IMEConvert = 28,
        IMENonconvert = 29,
        IMEAccept = 30,
        IMEAceept = 30,
        IMEModeChange = 31,
        Space = 32,
        Prior = 33,
        PageUp = 33,
        Next = 34,
        PageDown = 34,
        End = 35,
        Home = 36,
        Left = 37,
        Up = 38,
        Right = 39,
        Down = 40,
        Select = 41,
        Print = 42,
        Execute = 43,
        Snapshot = 44,
        PrintScreen = 44,
        Insert = 45,
        Delete = 46,
        Help = 47,
        D0 = 48,
        D1 = 49,
        D2 = 50,
        D3 = 51,
        D4 = 52,
        D5 = 53,
        D6 = 54,
        D7 = 55,
        D8 = 56,
        D9 = 57,
        A = 65,
        B = 66,
        C = 67,
        D = 68,
        E = 69,
        F = 70,
        G = 71,
        H = 72,
        I = 73,
        J = 74,
        K = 75,
        L = 76,
        M = 77,
        N = 78,
        O = 79,
        P = 80,
        Q = 81,
        R = 82,
        S = 83,
        T = 84,
        U = 85,
        V = 86,
        W = 87,
        X = 88,
        Y = 89,
        Z = 90,
        LWin = 91,
        RWin = 92,
        Apps = 93,
        Sleep = 95,
        NumPad0 = 96,
        NumPad1 = 97,
        NumPad2 = 98,
        NumPad3 = 99,
        NumPad4 = 100,
        NumPad5 = 101,
        NumPad6 = 102,
        NumPad7 = 103,
        NumPad8 = 104,
        NumPad9 = 105,
        Multiply = 106,
        Add = 107,
        Separator = 108,
        Subtract = 109,
        Decimal = 110,
        Divide = 111,
        F1 = 112,
        F2 = 113,
        F3 = 114,
        F4 = 115,
        F5 = 116,
        F6 = 117,
        F7 = 118,
        F8 = 119,
        F9 = 120,
        F10 = 121,
        F11 = 122,
        F12 = 123,
        F13 = 124,
        F14 = 125,
        F15 = 126,
        F16 = 127,
        F17 = 128,
        F18 = 129,
        F19 = 130,
        F20 = 131,
        F21 = 132,
        F22 = 133,
        F23 = 134,
        F24 = 135,
        NumLock = 144,
        Scroll = 145,
        LShiftKey = 160,
        RShiftKey = 161,
        LControlKey = 162,
        RControlKey = 163,
        LMenu = 164,
        RMenu = 165,
        BrowserBack = 166,
        BrowserForward = 167,
        BrowserRefresh = 168,
        BrowserStop = 169,
        BrowserSearch = 170,
        BrowserFavorites = 171,
        BrowserHome = 172,
        VolumeMute = 173,
        VolumeDown = 174,
        VolumeUp = 175,
        MediaNextTrack = 176,
        MediaPreviousTrack = 177,
        MediaStop = 178,
        MediaPlayPause = 179,
        LaunchMail = 180,
        SelectMedia = 181,
        LaunchApplication1 = 182,
        LaunchApplication2 = 183,
        OemSemicolon = 186,
        Oem1 = 186,
        Oemplus = 187,
        Oemcomma = 188,
        OemMinus = 189,
        OemPeriod = 190,
        OemQuestion = 191,
        Oem2 = 191,
        Oemtilde = 192,
        Oem3 = 192,
        OemOpenBrackets = 219,
        Oem4 = 219,
        OemPipe = 220,
        Oem5 = 220,
        OemCloseBrackets = 221,
        Oem6 = 221,
        OemQuotes = 222,
        Oem7 = 222,
        Oem8 = 223,
        OemBackslash = 226,
        Oem102 = 226,
        ProcessKey = 229,
        Packet = 231,
        Attn = 246,
        Crsel = 247,
        Exsel = 248,
        EraseEof = 249,
        Play = 250,
        Zoom = 251,
        NoName = 252,
        Pa1 = 253,
        OemClear = 254,
        Shift = 65536,
        Control = 131072,
        Alt = 262144
    }

	/// <summary>
	/// Description of StaticData.
	/// </summary>
	public static class StaticData
	{
		private static Dictionary<string, Keys> m_keysDic = new Dictionary<string, Keys>();
		public const string SETTINGS_FILE_PATH = "settings.ini";
		public const string SOUND_FILE_PATH = @"Sounds\sound.wav";
		
		public static Dictionary<string, Keys> KeysDic
		{
			get
			{
				AddKeysToDic();
				return m_keysDic;
			}
		}
		
		private static void AddKeysToDic()
		{
			if(m_keysDic.Count != 0)
				return;
			
			m_keysDic.Add("F1", Keys.F1);
			m_keysDic.Add("F2", Keys.F2);
			m_keysDic.Add("F3", Keys.F3);
			m_keysDic.Add("F4", Keys.F4);
			m_keysDic.Add("F5", Keys.F5);
			m_keysDic.Add("F6", Keys.F6);
			m_keysDic.Add("F7", Keys.F7);
			m_keysDic.Add("F8", Keys.F8);
			m_keysDic.Add("F9", Keys.F9);
			m_keysDic.Add("F10", Keys.F10);
			m_keysDic.Add("F11", Keys.F11);
			m_keysDic.Add("F12", Keys.F12);
			
			m_keysDic.Add("A", Keys.A);
			m_keysDic.Add("B", Keys.B);
			m_keysDic.Add("C", Keys.C);
			m_keysDic.Add("D", Keys.D);
			m_keysDic.Add("E", Keys.E);
			m_keysDic.Add("F", Keys.F);
			m_keysDic.Add("G", Keys.G);
			m_keysDic.Add("H", Keys.H);
			m_keysDic.Add("I", Keys.I);
			m_keysDic.Add("Y", Keys.Y);
			m_keysDic.Add("J", Keys.J);
			m_keysDic.Add("K", Keys.K);
			m_keysDic.Add("L", Keys.L);
			m_keysDic.Add("M", Keys.M);
			m_keysDic.Add("N", Keys.N);
			m_keysDic.Add("P", Keys.P);
			m_keysDic.Add("R", Keys.R);
			m_keysDic.Add("S", Keys.S);
			m_keysDic.Add("Q", Keys.Q);
			m_keysDic.Add("T", Keys.T);
			m_keysDic.Add("U", Keys.U);
			m_keysDic.Add("V", Keys.V);
			m_keysDic.Add("W", Keys.W);
			m_keysDic.Add("X", Keys.X);
			m_keysDic.Add("Z", Keys.Z);
			
			m_keysDic.Add("0", Keys.NumPad0);
			m_keysDic.Add("1", Keys.NumPad1);
			m_keysDic.Add("2", Keys.NumPad2);
			m_keysDic.Add("3", Keys.NumPad3);
			m_keysDic.Add("4", Keys.NumPad4);
			m_keysDic.Add("5", Keys.NumPad5);
			m_keysDic.Add("6", Keys.NumPad6);
			m_keysDic.Add("7", Keys.NumPad7);
			m_keysDic.Add("8", Keys.NumPad8);
			m_keysDic.Add("9", Keys.NumPad9);
			
		}
		
		public static class InfoUniqueCodes
		{
			public const string InfoLastSyncDate = "UniqueCode_InfoLastSyncDate";
		}
		
		public static class Settings
		{
			static bool m_startWithWindows;
			static bool m_checkUpdates;
			static bool m_playSound;
			static string m_skinUniqueCode;
			static string m_logFilePath;
			static decimal m_remindMeLaterValue = 10.0m/60.0m;
			static ICultureData m_cultureData = new CultureDataLT();

			public static decimal RemindMeLaterDefaultValue {
				get { return m_remindMeLaterValue; }
				set { m_remindMeLaterValue = value; }
			}
			
			public static ICultureData CultureData {
				get { return m_cultureData; }
				set {
					m_cultureData = value;
					TextParser.CultureData = m_cultureData;
					Thread.CurrentThread.CurrentCulture = m_cultureData.CultureInfo;
					Thread.CurrentThread.CurrentUICulture = m_cultureData.CultureInfo;
				}
			}
			public static bool StartWithWindows {
				get { return m_startWithWindows; }
				set { m_startWithWindows = value; }
			}
			
			public static bool CheckUpdates {
				get { return m_checkUpdates; }
				set { m_checkUpdates = value; }
			}

			public static bool PlaySound {
				get { return m_playSound; }
				set { m_playSound = value; }
			}
			
			public static string SkinUniqueCode {
				get { return m_skinUniqueCode; }
				set { m_skinUniqueCode = value; }
			}
			
			public static string LogFilePath {
				get { return m_logFilePath; }
				set { m_logFilePath = value; }
			}
			
			public static class SkinsUniqueCodes
			{
				static Dictionary<string, string> m_skinsUniqueCodesAndNames = new Dictionary<string, string>();
				
				/// <summary>
				/// Skin name -> skin uniqueCode
				/// </summary>
				public static Dictionary<string, string> SkinsUniqueCodesAndNames {
					get { AddSkinsToDic();
						return m_skinsUniqueCodesAndNames; }
				}
				
				private static void AddSkinsToDic()
				{
					if(m_skinsUniqueCodesAndNames.Count != 0)
						return;
					
//					m_skinsUniqueCodesAndNames.Add("Default skin", DEFAULT_SKIN_UNIQUE_CODE);
					m_skinsUniqueCodesAndNames.Add("Default skin", DefaultSkinForm.SKIN_UNIQUE_CODE);
					m_skinsUniqueCodesAndNames.Add("White skin", WhiteSkin.SKIN_UNIQUE_CODE);
					m_skinsUniqueCodesAndNames.Add("Black skin", BlackSkin.SKIN_UNIQUE_CODE);
					m_skinsUniqueCodesAndNames.Add("Blue orange skin", BlueOrangeSkin.SKIN_UNIQUE_CODE);
				}
			}
			
			public static class Sync
			{
				static string m_id = string.Empty;
				static DateTime m_lastSyncDate = new DateTime(2000,1,1);
				
				public static string Id {
					get { return m_id; }
					set { m_id = value; }
				}
				
				static bool m_enable = false;
				
				public static bool Enable {
					get { return m_enable; }
					set { m_enable = value; }
				}
				
				static int m_interval = 1;
				
				public static int Interval {
					get { return m_interval; }
					set { m_interval = value; }
				}
				
				//Not in settings.ini it's in Info obj in DB
				public static DateTime LastSyncDate {
					get { return m_lastSyncDate; }
					set { m_lastSyncDate = value; }
				}
			}
			
			public static class NewTaskHotkey
			{
				static bool m_ctrl;
				static bool m_alt;
				static bool m_shift;
				static bool m_win;
				static string m_key;
				
				public static bool Ctrl {
					get { return m_ctrl; }
					set { m_ctrl = value; }
				}
				
				public static bool Alt {
					get { return m_alt; }
					set { m_alt = value; }
				}
				
				public static bool Shift {
					get { return m_shift; }
					set { m_shift = value; }
				}
				
				public static bool Win {
					get { return m_win; }
					set { m_win = value; }
				}
				
				public static string Key {
					get { return m_key; }
					set { m_key = value; }
				}
			}
		}
	}
}
