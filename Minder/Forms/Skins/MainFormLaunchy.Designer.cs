using System.Drawing;
using Minder.Controls;

namespace Minder.Forms.Skins
{
	partial class MainFormLaunchy
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormLaunchy));
			this.m_trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.label1 = new MLabel((System.Drawing.Image)(resources.GetObject("LaunchyCloneLabel")));
			this.m_textBox = new Minder.Controls.MTextBox();
			this.labelRemaindDate = new MLabel((System.Drawing.Image)(resources.GetObject("LaunchyCloneRemindTimeLabel")));
			this.SuspendLayout();
			// 
			// m_trayIcon
			// 
			this.m_trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.m_trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TryIcon")));
			this.m_trayIcon.Text = "Minder";
			this.m_trayIcon.Visible = true;
			// 
			// label1
			// 
			this.label1.ForeColor = System.Drawing.SystemColors.Window;
			this.label1.Location = new System.Drawing.Point(11, 5);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 14);
			this.label1.TabIndex = 2;
			this.label1.Text = "New task";
			// 
			// m_TextBox
			// 
			this.m_textBox.Location = new System.Drawing.Point(3, 22);
			this.m_textBox.Multiline = true;
			this.m_textBox.Name = "m_TextBox";
			this.m_textBox.Size = new System.Drawing.Size(255, 51);
			this.m_textBox.TabIndex = 3;
			// 
			// labelRemaindDate
			// 
			this.labelRemaindDate.ForeColor = System.Drawing.SystemColors.Window;
			this.labelRemaindDate.Location = new System.Drawing.Point(72, 5);
			this.labelRemaindDate.Name = "labelRemaindDate";
			this.labelRemaindDate.Size = new System.Drawing.Size(177, 14);
			this.labelRemaindDate.TabIndex = 4;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(261, 74);
			this.ControlBox = false;
			this.Controls.Add(this.labelRemaindDate);
			this.Controls.Add(this.m_textBox);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "MainForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Main_Form";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private MLabel labelRemaindDate;
		
		private Minder.Controls.MTextBox m_textBox;
		private MLabel label1;
		
		public System.Windows.Forms.TextBox MTextBox {
			get { return m_textBox; }
		}
		
		public System.Windows.Forms.Label MLabelRemaindDate {
			get { return labelRemaindDate; }
		}
		
		public System.Windows.Forms.NotifyIcon m_trayIcon;
	}
}
