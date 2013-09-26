/*
 * Created by SharpDevelop.
 * User: Ignas
 * Date: 2012.12.22
 * Time: 11:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace Minder.Engine.Helpers
{
	/// <summary>
	/// Description of MousePositionHelper.
	/// </summary>
	public class MousePositionHelper
	{
		#region privates variables
		private static bool m_mouseNotMoving = false;
		private Timer m_timer = null;
		private int m_x = 0;
		private int m_y = 0;
		#endregion
		
		#region properties
		public static bool MouseNotMoving {
			get { return m_mouseNotMoving; }
		}
		#endregion
		
		public MousePositionHelper()
		{
			m_timer = new Timer();
		}
		
		public void SartMouseMoveChecker()
		{
			m_timer.Interval = 1000 * 60 * 2; //2 minutes
			m_timer.Tick += delegate
			{
				if(m_x == Cursor.Position.X &&
				   m_y == Cursor.Position.Y)
					m_mouseNotMoving = true;
				else
				{
					m_mouseNotMoving = false;
					m_x = Cursor.Position.X;
					m_y = Cursor.Position.Y;
				}
			};
			m_timer.Start();
			
		}
		
	}
}
