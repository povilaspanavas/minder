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
			this.label3 = new System.Windows.Forms.Label();
			this.MComboBoxRemindMeLater = new System.Windows.Forms.ComboBox();
			this.labelCultureData = new System.Windows.Forms.Label();
			this.MComboBoxCultureData = new System.Windows.Forms.ComboBox();
			this.MPlaySoundCheckBox = new System.Windows.Forms.CheckBox();
			this.MUpdateCheckBox = new System.Windows.Forms.CheckBox();
			this.MStartWithWinCheckBox = new System.Windows.Forms.CheckBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.MKeysComboBox = new System.Windows.Forms.ComboBox();
			this.MAltCheckBox = new System.Windows.Forms.CheckBox();
			this.MShiftCheckBox = new System.Windows.Forms.CheckBox();
			this.MCtrlCheckBox = new System.Windows.Forms.CheckBox();
			this.MWinCheckBox = new System.Windows.Forms.CheckBox();
			this.tabPageSkins = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.MSkinPreviewPictureBox = new System.Windows.Forms.PictureBox();
			this.MSkinListBox = new System.Windows.Forms.ListBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.MLastSyncDate = new System.Windows.Forms.DateTimePicker();
			this.MSyncIntervalNumeric = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.MSyncGenerateIdButton = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.MSyncIdTextBox = new Minder.Controls.MTextBox();
			this.MEnableSyncCheckBox = new System.Windows.Forms.CheckBox();
			this.MDefaultsButton = new Core.UI.Controls.Buttons.CoreBlueCustomButton();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPageSkins.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MSkinPreviewPictureBox)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MSyncIntervalNumeric)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Location = new System.Drawing.Point(9, 10);
			this.panel1.Margin = new System.Windows.Forms.Padding(2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(506, 369);
			this.panel1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPageSkins);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Location = new System.Drawing.Point(2, 2);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(502, 364);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.MDefaultsButton);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.MComboBoxRemindMeLater);
			this.tabPage1.Controls.Add(this.labelCultureData);
			this.tabPage1.Controls.Add(this.MComboBoxCultureData);
			this.tabPage1.Controls.Add(this.MPlaySoundCheckBox);
			this.tabPage1.Controls.Add(this.MUpdateCheckBox);
			this.tabPage1.Controls.Add(this.MStartWithWinCheckBox);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage1.Size = new System.Drawing.Size(494, 338);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(21, 122);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(139, 18);
			this.label3.TabIndex = 10;
			this.label3.Text = "Default remind later value";
			// 
			// MComboBoxRemindMeLater
			// 
			this.MComboBoxRemindMeLater.DisplayMember = "Name";
			this.MComboBoxRemindMeLater.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MComboBoxRemindMeLater.FormattingEnabled = true;
			this.MComboBoxRemindMeLater.Location = new System.Drawing.Point(165, 119);
			this.MComboBoxRemindMeLater.Margin = new System.Windows.Forms.Padding(2);
			this.MComboBoxRemindMeLater.Name = "MComboBoxRemindMeLater";
			this.MComboBoxRemindMeLater.Size = new System.Drawing.Size(132, 21);
			this.MComboBoxRemindMeLater.Sorted = true;
			this.MComboBoxRemindMeLater.TabIndex = 9;
			// 
			// labelCultureData
			// 
			this.labelCultureData.Location = new System.Drawing.Point(21, 92);
			this.labelCultureData.Name = "labelCultureData";
			this.labelCultureData.Size = new System.Drawing.Size(67, 18);
			this.labelCultureData.TabIndex = 8;
			this.labelCultureData.Text = "Date format";
			// 
			// MComboBoxCultureData
			// 
			this.MComboBoxCultureData.DisplayMember = "Name";
			this.MComboBoxCultureData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MComboBoxCultureData.FormattingEnabled = true;
			this.MComboBoxCultureData.Location = new System.Drawing.Point(165, 92);
			this.MComboBoxCultureData.Margin = new System.Windows.Forms.Padding(2);
			this.MComboBoxCultureData.Name = "MComboBoxCultureData";
			this.MComboBoxCultureData.Size = new System.Drawing.Size(132, 21);
			this.MComboBoxCultureData.Sorted = true;
			this.MComboBoxCultureData.TabIndex = 7;
			// 
			// MPlaySoundCheckBox
			// 
			this.MPlaySoundCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.MPlaySoundCheckBox.Location = new System.Drawing.Point(20, 64);
			this.MPlaySoundCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MPlaySoundCheckBox.Name = "MPlaySoundCheckBox";
			this.MPlaySoundCheckBox.Size = new System.Drawing.Size(183, 21);
			this.MPlaySoundCheckBox.TabIndex = 5;
			this.MPlaySoundCheckBox.Text = "Play sound when reminding";
			this.MPlaySoundCheckBox.UseVisualStyleBackColor = true;
			// 
			// MUpdateCheckBox
			// 
			this.MUpdateCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.MUpdateCheckBox.Location = new System.Drawing.Point(20, 40);
			this.MUpdateCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MUpdateCheckBox.Name = "MUpdateCheckBox";
			this.MUpdateCheckBox.Size = new System.Drawing.Size(183, 20);
			this.MUpdateCheckBox.TabIndex = 2;
			this.MUpdateCheckBox.Text = "Check automatically for updates";
			this.MUpdateCheckBox.UseVisualStyleBackColor = true;
			// 
			// MStartWithWinCheckBox
			// 
			this.MStartWithWinCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.MStartWithWinCheckBox.Location = new System.Drawing.Point(20, 15);
			this.MStartWithWinCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MStartWithWinCheckBox.Name = "MStartWithWinCheckBox";
			this.MStartWithWinCheckBox.Size = new System.Drawing.Size(183, 21);
			this.MStartWithWinCheckBox.TabIndex = 1;
			this.MStartWithWinCheckBox.Text = "Start Minder with Windows";
			this.MStartWithWinCheckBox.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
			this.tabPage2.Size = new System.Drawing.Size(494, 338);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Hotkeys";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
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
			this.groupBox1.Size = new System.Drawing.Size(486, 87);
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
			// MKeysComboBox
			// 
			this.MKeysComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MKeysComboBox.FormattingEnabled = true;
			this.MKeysComboBox.Location = new System.Drawing.Point(160, 34);
			this.MKeysComboBox.Margin = new System.Windows.Forms.Padding(2);
			this.MKeysComboBox.Name = "MKeysComboBox";
			this.MKeysComboBox.Size = new System.Drawing.Size(104, 21);
			this.MKeysComboBox.TabIndex = 4;
			// 
			// MAltCheckBox
			// 
			this.MAltCheckBox.Location = new System.Drawing.Point(68, 47);
			this.MAltCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MAltCheckBox.Name = "MAltCheckBox";
			this.MAltCheckBox.Size = new System.Drawing.Size(53, 20);
			this.MAltCheckBox.TabIndex = 2;
			this.MAltCheckBox.Text = "Alt";
			this.MAltCheckBox.UseVisualStyleBackColor = true;
			// 
			// MShiftCheckBox
			// 
			this.MShiftCheckBox.Location = new System.Drawing.Point(16, 24);
			this.MShiftCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MShiftCheckBox.Name = "MShiftCheckBox";
			this.MShiftCheckBox.Size = new System.Drawing.Size(47, 20);
			this.MShiftCheckBox.TabIndex = 3;
			this.MShiftCheckBox.Text = "Shift";
			this.MShiftCheckBox.UseVisualStyleBackColor = true;
			// 
			// MCtrlCheckBox
			// 
			this.MCtrlCheckBox.Location = new System.Drawing.Point(16, 48);
			this.MCtrlCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MCtrlCheckBox.Name = "MCtrlCheckBox";
			this.MCtrlCheckBox.Size = new System.Drawing.Size(43, 20);
			this.MCtrlCheckBox.TabIndex = 0;
			this.MCtrlCheckBox.Text = "Ctrl";
			this.MCtrlCheckBox.UseVisualStyleBackColor = true;
			// 
			// MWinCheckBox
			// 
			this.MWinCheckBox.Location = new System.Drawing.Point(68, 24);
			this.MWinCheckBox.Margin = new System.Windows.Forms.Padding(2);
			this.MWinCheckBox.Name = "MWinCheckBox";
			this.MWinCheckBox.Size = new System.Drawing.Size(53, 20);
			this.MWinCheckBox.TabIndex = 1;
			this.MWinCheckBox.Text = "Win";
			this.MWinCheckBox.UseVisualStyleBackColor = true;
			// 
			// tabPageSkins
			// 
			this.tabPageSkins.Controls.Add(this.groupBox3);
			this.tabPageSkins.Location = new System.Drawing.Point(4, 22);
			this.tabPageSkins.Name = "tabPageSkins";
			this.tabPageSkins.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageSkins.Size = new System.Drawing.Size(494, 338);
			this.tabPageSkins.TabIndex = 2;
			this.tabPageSkins.Text = "Skins";
			this.tabPageSkins.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.MSkinPreviewPictureBox);
			this.groupBox3.Controls.Add(this.MSkinListBox);
			this.groupBox3.Location = new System.Drawing.Point(6, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(482, 326);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Skins";
			// 
			// MSkinPreviewPictureBox
			// 
			this.MSkinPreviewPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.MSkinPreviewPictureBox.Location = new System.Drawing.Point(161, 19);
			this.MSkinPreviewPictureBox.Name = "MSkinPreviewPictureBox";
			this.MSkinPreviewPictureBox.Size = new System.Drawing.Size(315, 117);
			this.MSkinPreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.MSkinPreviewPictureBox.TabIndex = 1;
			this.MSkinPreviewPictureBox.TabStop = false;
			// 
			// MSkinListBox
			// 
			this.MSkinListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.MSkinListBox.FormattingEnabled = true;
			this.MSkinListBox.Location = new System.Drawing.Point(6, 19);
			this.MSkinListBox.Name = "MSkinListBox";
			this.MSkinListBox.Size = new System.Drawing.Size(149, 290);
			this.MSkinListBox.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox2);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(494, 338);
			this.tabPage3.TabIndex = 3;
			this.tabPage3.Text = "Sync";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.MLastSyncDate);
			this.groupBox2.Controls.Add(this.MSyncIntervalNumeric);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.MSyncGenerateIdButton);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.MSyncIdTextBox);
			this.groupBox2.Controls.Add(this.MEnableSyncCheckBox);
			this.groupBox2.Location = new System.Drawing.Point(6, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(482, 326);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Sync";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(28, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Last sync date";
			// 
			// MLastSyncDate
			// 
			this.MLastSyncDate.CustomFormat = "yyyy.MM.dd HH:mm:ss";
			this.MLastSyncDate.Enabled = false;
			this.MLastSyncDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.MLastSyncDate.Location = new System.Drawing.Point(113, 108);
			this.MLastSyncDate.Name = "MLastSyncDate";
			this.MLastSyncDate.ShowUpDown = true;
			this.MLastSyncDate.Size = new System.Drawing.Size(125, 20);
			this.MLastSyncDate.TabIndex = 6;
			// 
			// MSyncIntervalNumeric
			// 
			this.MSyncIntervalNumeric.Location = new System.Drawing.Point(144, 82);
			this.MSyncIntervalNumeric.Maximum = new decimal(new int[] {
									100000,
									0,
									0,
									0});
			this.MSyncIntervalNumeric.Minimum = new decimal(new int[] {
									1,
									0,
									0,
									0});
			this.MSyncIntervalNumeric.Name = "MSyncIntervalNumeric";
			this.MSyncIntervalNumeric.Size = new System.Drawing.Size(94, 20);
			this.MSyncIntervalNumeric.TabIndex = 5;
			this.MSyncIntervalNumeric.Value = new decimal(new int[] {
									1,
									0,
									0,
									0});
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(21, 84);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(119, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "Sync interval (minutes)";
			// 
			// MSyncGenerateIdButton
			// 
			this.MSyncGenerateIdButton.Location = new System.Drawing.Point(253, 56);
			this.MSyncGenerateIdButton.Name = "MSyncGenerateIdButton";
			this.MSyncGenerateIdButton.Size = new System.Drawing.Size(100, 23);
			this.MSyncGenerateIdButton.TabIndex = 3;
			this.MSyncGenerateIdButton.Text = "Generate ID";
			this.MSyncGenerateIdButton.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(21, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Your ID";
			// 
			// MSyncIdTextBox
			// 
			this.MSyncIdTextBox.Location = new System.Drawing.Point(100, 58);
			this.MSyncIdTextBox.Name = "MSyncIdTextBox";
			this.MSyncIdTextBox.Size = new System.Drawing.Size(138, 20);
			this.MSyncIdTextBox.TabIndex = 1;
			// 
			// MEnableSyncCheckBox
			// 
			this.MEnableSyncCheckBox.Location = new System.Drawing.Point(21, 19);
			this.MEnableSyncCheckBox.Name = "MEnableSyncCheckBox";
			this.MEnableSyncCheckBox.Size = new System.Drawing.Size(205, 24);
			this.MEnableSyncCheckBox.TabIndex = 0;
			this.MEnableSyncCheckBox.Text = "Enable synchronization";
			this.MEnableSyncCheckBox.UseVisualStyleBackColor = true;
			// 
			// MDefaultsButton
			// 
			this.MDefaultsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.MDefaultsButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MDefaultsButton.BackgroundImage")));
			this.MDefaultsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.MDefaultsButton.Location = new System.Drawing.Point(176, 293);
			this.MDefaultsButton.Name = "MDefaultsButton";
			this.MDefaultsButton.Size = new System.Drawing.Size(121, 40);
			this.MDefaultsButton.TabIndex = 11;
			this.MDefaultsButton.Text = "Restore defaults";
			this.MDefaultsButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.MDefaultsButton.UseVisualStyleBackColor = true;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(524, 389);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SettingsForm";
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabPageSkins.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MSkinPreviewPictureBox)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MSyncIntervalNumeric)).EndInit();
			this.ResumeLayout(false);
		}
		public Core.UI.Controls.Buttons.CoreBlueCustomButton MDefaultsButton;
		private System.Windows.Forms.Label label5;
		public System.Windows.Forms.DateTimePicker MLastSyncDate;
		public System.Windows.Forms.Button MSyncGenerateIdButton;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.NumericUpDown MSyncIntervalNumeric;
		public Minder.Controls.MTextBox MSyncIdTextBox;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.CheckBox MEnableSyncCheckBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TabPage tabPage3;
		public System.Windows.Forms.ComboBox MComboBoxRemindMeLater;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox3;
		public System.Windows.Forms.ListBox MSkinListBox;
		public System.Windows.Forms.PictureBox MSkinPreviewPictureBox;
		private System.Windows.Forms.TabPage tabPageSkins;
		public System.Windows.Forms.ComboBox MComboBoxCultureData;
		private System.Windows.Forms.Label labelCultureData;
		public System.Windows.Forms.CheckBox MPlaySoundCheckBox;
		public System.Windows.Forms.CheckBox MStartWithWinCheckBox;
		public System.Windows.Forms.CheckBox MUpdateCheckBox;
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
