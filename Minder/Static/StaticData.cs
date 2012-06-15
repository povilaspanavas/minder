
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Minder.Static
{
	/// <summary>
	/// Description of StaticData.
	/// </summary>
	public static class StaticData
	{
		private static Dictionary<string, Keys> m_keysDic = new Dictionary<string, Keys>();
		public const string SETTINGS_FILE_PATH = "settings.ini";
		
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
		
		public static class Settings
		{
			public static class NewTaskHotkey
			{
				static bool m_ctrl;
				
				public static bool Ctrl {
					get { return m_ctrl; }
					set { m_ctrl = value; }
				}
				
				static bool m_alt;
				
				public static bool Alt {
					get { return m_alt; }
					set { m_alt = value; }
				}
				
				static bool m_shift;
				
				public static bool Shift {
					get { return m_shift; }
					set { m_shift = value; }
				}
				
				static bool m_win;
				
				public static bool Win {
					get { return m_win; }
					set { m_win = value; }
				}
				
				static string m_key;
				
				public static string Key {
					get { return m_key; }
					set { m_key = value; }
				}
			}
		}
	}
}
