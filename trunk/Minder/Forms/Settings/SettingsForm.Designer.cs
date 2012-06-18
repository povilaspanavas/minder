/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.13
 * Time: 23:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Minder.Forms.Settings
{
	partial class SettingsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.m_taskLimitNumeric = new System.Windows.Forms.NumericUpDown();
			this.m_updateCheckBox = new System.Windows.Forms.CheckBox();
			this.m_startWithWinCheckBox = new System.Windows.Forms.CheckBox();
			this.m_defaultsButton = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_keysComboBox = new System.Windows.Forms.ComboBox();
			this.m_altCheckBox = new System.Windows.Forms.CheckBox();
			this.m_shiftCheckBox = new System.Windows.Forms.CheckBox();
			this.m_ctrlCheckBox = new System.Windows.Forms.CheckBox();
			this.m_winCheckBox = new System.Windows.Forms.CheckBox();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_taskLimitNumeric)).BeginInit();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Location = new System.Drawing.Point(9, 10);
			this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(470, 472);
			this.panel1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(2, 2);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(466, 467);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.m_taskLimitNumeric);
			this.tabPage1.Controls.Add(this.m_updateCheckBox);
			this.tabPage1.Controls.Add(this.m_startWithWinCheckBox);
			this.tabPage1.Controls.Add(this.m_defaultsButton);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPage1.Size = new System.Drawing.Size(458, 441);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(82, 66);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(75, 19);
			this.label2.TabIndex = 4;
			this.label2.Text = "Tasks limit";
			// 
			// m_taskLimitNumeric
			// 
			this.m_taskLimitNumeric.Location = new System.Drawing.Point(20, 64);
			this.m_taskLimitNumeric.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_taskLimitNumeric.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.m_taskLimitNumeric.Name = "m_taskLimitNumeric";
			this.m_taskLimitNumeric.Size = new System.Drawing.Size(57, 20);
			this.m_taskLimitNumeric.TabIndex = 3;
			// 
			// m_updateCheckBox
			// 
			this.m_updateCheckBox.Location = new System.Drawing.Point(20, 40);
			this.m_updateCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_updateCheckBox.Name = "m_updateCheckBox";
			this.m_updateCheckBox.Size = new System.Drawing.Size(163, 20);
			this.m_updateCheckBox.TabIndex = 2;
			this.m_updateCheckBox.Text = "Check automatic updates";
			this.m_updateCheckBox.UseVisualStyleBackColor = true;
			// 
			// m_startWithWinCheckBox
			// 
			this.m_startWithWinCheckBox.Location = new System.Drawing.Point(20, 15);
			this.m_startWithWinCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_startWithWinCheckBox.Name = "m_startWithWinCheckBox";
			this.m_startWithWinCheckBox.Size = new System.Drawing.Size(163, 20);
			this.m_startWithWinCheckBox.TabIndex = 1;
			this.m_startWithWinCheckBox.Text = "Start Minder with Windows";
			this.m_startWithWinCheckBox.UseVisualStyleBackColor = true;
			// 
			// m_defaultsButton
			// 
			this.m_defaultsButton.Location = new System.Drawing.Point(172, 386);
			this.m_defaultsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_defaultsButton.Name = "m_defaultsButton";
			this.m_defaultsButton.Size = new System.Drawing.Size(111, 32);
			this.m_defaultsButton.TabIndex = 0;
			this.m_defaultsButton.Text = "Restore defaults";
			this.m_defaultsButton.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.tabPage2.Size = new System.Drawing.Size(458, 441);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Hotkeys";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.m_keysComboBox);
			this.groupBox1.Controls.Add(this.m_altCheckBox);
			this.groupBox1.Controls.Add(this.m_shiftCheckBox);
			this.groupBox1.Controls.Add(this.m_ctrlCheckBox);
			this.groupBox1.Controls.Add(this.m_winCheckBox);
			this.groupBox1.Location = new System.Drawing.Point(4, 5);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.groupBox1.Size = new System.Drawing.Size(450, 87);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "New task";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(126, 37);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 19);
			this.label1.TabIndex = 5;
			this.label1.Text = "+";
			// 
			// m_keysComboBox
			// 
			this.m_keysComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_keysComboBox.FormattingEnabled = true;
			this.m_keysComboBox.Location = new System.Drawing.Point(160, 34);
			this.m_keysComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_keysComboBox.Name = "m_keysComboBox";
			this.m_keysComboBox.Size = new System.Drawing.Size(104, 21);
			this.m_keysComboBox.TabIndex = 4;
			// 
			// m_altCheckBox
			// 
			this.m_altCheckBox.Location = new System.Drawing.Point(68, 47);
			this.m_altCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_altCheckBox.Name = "m_altCheckBox";
			this.m_altCheckBox.Size = new System.Drawing.Size(53, 20);
			this.m_altCheckBox.TabIndex = 2;
			this.m_altCheckBox.Text = "Alt";
			this.m_altCheckBox.UseVisualStyleBackColor = true;
			// 
			// m_shiftCheckBox
			// 
			this.m_shiftCheckBox.Location = new System.Drawing.Point(16, 24);
			this.m_shiftCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_shiftCheckBox.Name = "m_shiftCheckBox";
			this.m_shiftCheckBox.Size = new System.Drawing.Size(47, 20);
			this.m_shiftCheckBox.TabIndex = 3;
			this.m_shiftCheckBox.Text = "Shift";
			this.m_shiftCheckBox.UseVisualStyleBackColor = true;
			// 
			// m_ctrlCheckBox
			// 
			this.m_ctrlCheckBox.Location = new System.Drawing.Point(16, 48);
			this.m_ctrlCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_ctrlCheckBox.Name = "m_ctrlCheckBox";
			this.m_ctrlCheckBox.Size = new System.Drawing.Size(43, 20);
			this.m_ctrlCheckBox.TabIndex = 0;
			this.m_ctrlCheckBox.Text = "Ctrl";
			this.m_ctrlCheckBox.UseVisualStyleBackColor = true;
			// 
			// m_winCheckBox
			// 
			this.m_winCheckBox.Location = new System.Drawing.Point(68, 24);
			this.m_winCheckBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.m_winCheckBox.Name = "m_winCheckBox";
			this.m_winCheckBox.Size = new System.Drawing.Size(53, 20);
			this.m_winCheckBox.TabIndex = 1;
			this.m_winCheckBox.Text = "Win";
			this.m_winCheckBox.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(488, 492);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SettingsForm";
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_taskLimitNumeric)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.CheckBox m_startWithWinCheckBox;
		public System.Windows.Forms.CheckBox m_updateCheckBox;
		public System.Windows.Forms.NumericUpDown m_taskLimitNumeric;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.Button m_defaultsButton;
		public System.Windows.Forms.ComboBox m_keysComboBox;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.CheckBox m_winCheckBox;
		public System.Windows.Forms.CheckBox m_ctrlCheckBox;
		public System.Windows.Forms.CheckBox m_shiftCheckBox;
		public System.Windows.Forms.CheckBox m_altCheckBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Panel panel1;
	}
}
