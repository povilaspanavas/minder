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
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.MWinCheckBox = new System.Windows.Forms.CheckBox();
			this.MCtrlCheckBox = new System.Windows.Forms.CheckBox();
			this.MShiftCheckBox = new System.Windows.Forms.CheckBox();
			this.MAltCheckBox = new System.Windows.Forms.CheckBox();
			this.MKeysComboBox = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.m_defaultsButton = new System.Windows.Forms.Button();
			this.MStartWithWinCheckBox = new System.Windows.Forms.CheckBox();
			this.MUpdateCheckBox = new System.Windows.Forms.CheckBox();
			this.m_taskLimitNumeric = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.MPlaySoundCheckBox = new System.Windows.Forms.CheckBox();
			this.MComboBoxCultureData = new System.Windows.Forms.ComboBox();
			this.labelCultureData = new System.Windows.Forms.Label();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.panel1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_taskLimitNumeric)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Location = new System.Drawing.Point(9, 11);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(432, 397);
			this.panel1.TabIndex = 0;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 23);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage2.Size = new System.Drawing.Size(420, 365);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Hotkeys";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.MKeysComboBox);
			this.groupBox1.Controls.Add(this.MAltCheckBox);
			this.groupBox1.Controls.Add(this.MShiftCheckBox);
			this.groupBox1.Controls.Add(this.MCtrlCheckBox);
			this.groupBox1.Controls.Add(this.MWinCheckBox);
			this.groupBox1.Location = new System.Drawing.Point(4, 5);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(412, 94);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "New task";
			// 
			// MWinCheckBox
			// 
			this.MWinCheckBox.Location = new System.Drawing.Point(68, 26);
			this.MWinCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MWinCheckBox.Name = "MWinCheckBox";
			this.MWinCheckBox.Size = new System.Drawing.Size(53, 22);
			this.MWinCheckBox.TabIndex = 1;
			this.MWinCheckBox.Text = "Win";
			this.MWinCheckBox.UseVisualStyleBackColor = true;
			// 
			// MCtrlCheckBox
			// 
			this.MCtrlCheckBox.Location = new System.Drawing.Point(16, 52);
			this.MCtrlCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MCtrlCheckBox.Name = "MCtrlCheckBox";
			this.MCtrlCheckBox.Size = new System.Drawing.Size(43, 22);
			this.MCtrlCheckBox.TabIndex = 0;
			this.MCtrlCheckBox.Text = "Ctrl";
			this.MCtrlCheckBox.UseVisualStyleBackColor = true;
			// 
			// MShiftCheckBox
			// 
			this.MShiftCheckBox.Location = new System.Drawing.Point(16, 26);
			this.MShiftCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MShiftCheckBox.Name = "MShiftCheckBox";
			this.MShiftCheckBox.Size = new System.Drawing.Size(47, 22);
			this.MShiftCheckBox.TabIndex = 3;
			this.MShiftCheckBox.Text = "Shift";
			this.MShiftCheckBox.UseVisualStyleBackColor = true;
			// 
			// MAltCheckBox
			// 
			this.MAltCheckBox.Location = new System.Drawing.Point(68, 51);
			this.MAltCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MAltCheckBox.Name = "MAltCheckBox";
			this.MAltCheckBox.Size = new System.Drawing.Size(53, 22);
			this.MAltCheckBox.TabIndex = 2;
			this.MAltCheckBox.Text = "Alt";
			this.MAltCheckBox.UseVisualStyleBackColor = true;
			// 
			// MKeysComboBox
			// 
			this.MKeysComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MKeysComboBox.FormattingEnabled = true;
			this.MKeysComboBox.Location = new System.Drawing.Point(160, 37);
			this.MKeysComboBox.Margin = new System.Windows.Forms.Padding(2);
			this.MKeysComboBox.Name = "MKeysComboBox";
			this.MKeysComboBox.Size = new System.Drawing.Size(104, 22);
			this.MKeysComboBox.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(126, 40);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(14, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "+";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Controls.Add(this.checkBox1);
			this.groupBox2.Controls.Add(this.checkBox2);
			this.groupBox2.Controls.Add(this.checkBox3);
			this.groupBox2.Controls.Add(this.checkBox4);
			this.groupBox2.Location = new System.Drawing.Point(4, 103);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.Size = new System.Drawing.Size(412, 92);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tasks";
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(68, 26);
			this.checkBox4.Margin = new System.Windows.Forms.Padding(2);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(53, 22);
			this.checkBox4.TabIndex = 1;
			this.checkBox4.Text = "Win";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(16, 52);
			this.checkBox3.Margin = new System.Windows.Forms.Padding(2);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(43, 22);
			this.checkBox3.TabIndex = 0;
			this.checkBox3.Text = "Ctrl";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(16, 26);
			this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(47, 22);
			this.checkBox2.TabIndex = 3;
			this.checkBox2.Text = "Shift";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(68, 51);
			this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(53, 22);
			this.checkBox1.TabIndex = 2;
			this.checkBox1.Text = "Alt";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(160, 37);
			this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(104, 22);
			this.comboBox1.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(126, 40);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(14, 20);
			this.label3.TabIndex = 5;
			this.label3.Text = "+";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.labelCultureData);
			this.tabPage1.Controls.Add(this.MComboBoxCultureData);
			this.tabPage1.Controls.Add(this.MPlaySoundCheckBox);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.m_taskLimitNumeric);
			this.tabPage1.Controls.Add(this.MUpdateCheckBox);
			this.tabPage1.Controls.Add(this.MStartWithWinCheckBox);
			this.tabPage1.Controls.Add(this.m_defaultsButton);
			this.tabPage1.Location = new System.Drawing.Point(4, 23);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage1.Size = new System.Drawing.Size(420, 365);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// m_defaultsButton
			// 
			this.m_defaultsButton.Location = new System.Drawing.Point(152, 278);
			this.m_defaultsButton.Margin = new System.Windows.Forms.Padding(2);
			this.m_defaultsButton.Name = "m_defaultsButton";
			this.m_defaultsButton.Size = new System.Drawing.Size(111, 34);
			this.m_defaultsButton.TabIndex = 0;
			this.m_defaultsButton.Text = "Restore defaults";
			this.m_defaultsButton.UseVisualStyleBackColor = true;
			// 
			// MStartWithWinCheckBox
			// 
			this.MStartWithWinCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.MStartWithWinCheckBox.Location = new System.Drawing.Point(20, 16);
			this.MStartWithWinCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MStartWithWinCheckBox.Name = "MStartWithWinCheckBox";
			this.MStartWithWinCheckBox.Size = new System.Drawing.Size(183, 23);
			this.MStartWithWinCheckBox.TabIndex = 1;
			this.MStartWithWinCheckBox.Text = "Start Minder with Windows";
			this.MStartWithWinCheckBox.UseVisualStyleBackColor = true;
			// 
			// MUpdateCheckBox
			// 
			this.MUpdateCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.MUpdateCheckBox.Location = new System.Drawing.Point(20, 43);
			this.MUpdateCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MUpdateCheckBox.Name = "MUpdateCheckBox";
			this.MUpdateCheckBox.Size = new System.Drawing.Size(183, 22);
			this.MUpdateCheckBox.TabIndex = 2;
			this.MUpdateCheckBox.Text = "Check automatically for updates";
			this.MUpdateCheckBox.UseVisualStyleBackColor = true;
			// 
			// m_taskLimitNumeric
			// 
			this.m_taskLimitNumeric.Location = new System.Drawing.Point(92, 117);
			this.m_taskLimitNumeric.Margin = new System.Windows.Forms.Padding(2);
			this.m_taskLimitNumeric.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.m_taskLimitNumeric.Name = "m_taskLimitNumeric";
			this.m_taskLimitNumeric.Size = new System.Drawing.Size(57, 20);
			this.m_taskLimitNumeric.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(20, 119);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 18);
			this.label2.TabIndex = 4;
			this.label2.Text = "Tasks limit";
			// 
			// MPlaySoundCheckBox
			// 
			this.MPlaySoundCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.MPlaySoundCheckBox.Location = new System.Drawing.Point(20, 69);
			this.MPlaySoundCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MPlaySoundCheckBox.Name = "MPlaySoundCheckBox";
			this.MPlaySoundCheckBox.Size = new System.Drawing.Size(183, 23);
			this.MPlaySoundCheckBox.TabIndex = 5;
			this.MPlaySoundCheckBox.Text = "Play sound when reminding";
			this.MPlaySoundCheckBox.UseVisualStyleBackColor = true;
			// 
			// MComboBoxCultureData
			// 
			this.MComboBoxCultureData.DisplayMember = "Name";
			this.MComboBoxCultureData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MComboBoxCultureData.FormattingEnabled = true;
			this.MComboBoxCultureData.Location = new System.Drawing.Point(92, 91);
			this.MComboBoxCultureData.Margin = new System.Windows.Forms.Padding(2);
			this.MComboBoxCultureData.Name = "MComboBoxCultureData";
			this.MComboBoxCultureData.Size = new System.Drawing.Size(132, 22);
			this.MComboBoxCultureData.Sorted = true;
			this.MComboBoxCultureData.TabIndex = 7;
			// 
			// labelCultureData
			// 
			this.labelCultureData.Location = new System.Drawing.Point(20, 94);
			this.labelCultureData.Name = "labelCultureData";
			this.labelCultureData.Size = new System.Drawing.Size(67, 19);
			this.labelCultureData.TabIndex = 8;
			this.labelCultureData.Text = "Date format";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(2, 2);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(428, 392);
			this.tabControl1.TabIndex = 0;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(450, 419);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SettingsForm";
			this.panel1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_taskLimitNumeric)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.ComboBox MComboBoxCultureData;
		private System.Windows.Forms.Label labelCultureData;
		public System.Windows.Forms.CheckBox MPlaySoundCheckBox;
		public System.Windows.Forms.CheckBox checkBox4;
		public System.Windows.Forms.CheckBox checkBox3;
		public System.Windows.Forms.CheckBox checkBox2;
		public System.Windows.Forms.CheckBox checkBox1;
		public System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox2;
		public System.Windows.Forms.CheckBox MStartWithWinCheckBox;
		public System.Windows.Forms.CheckBox MUpdateCheckBox;
		public System.Windows.Forms.NumericUpDown m_taskLimitNumeric;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.Button m_defaultsButton;
		public System.Windows.Forms.ComboBox MKeysComboBox;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.CheckBox MWinCheckBox;
		public System.Windows.Forms.CheckBox MCtrlCheckBox;
		public System.Windows.Forms.CheckBox MShiftCheckBox;
		public System.Windows.Forms.CheckBox MAltCheckBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Panel panel1;
	}
}
