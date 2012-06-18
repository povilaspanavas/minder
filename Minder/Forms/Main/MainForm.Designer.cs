
namespace Minder.Forms.Main
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.m_trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.m_textBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_trayIcon
			// 
			this.m_trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.m_trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("m_trayIcon.Icon")));
			this.m_trayIcon.Text = "Minder";
			this.m_trayIcon.Visible = true;
			// 
			// m_textBox
			// 
			this.m_textBox.BackColor = System.Drawing.Color.White;
			this.m_textBox.Location = new System.Drawing.Point(3, 20);
			this.m_textBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.m_textBox.Multiline = true;
			this.m_textBox.Name = "m_textBox";
			this.m_textBox.Size = new System.Drawing.Size(257, 56);
			this.m_textBox.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(102, 5);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "New task";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(263, 83);
			this.ControlBox = false;
			this.Controls.Add(this.label1);
			this.Controls.Add(this.m_textBox);
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
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox m_textBox;
		
		public System.Windows.Forms.TextBox TextBox {
			get { return m_textBox; }
		}
		public System.Windows.Forms.NotifyIcon m_trayIcon;
	}
}
