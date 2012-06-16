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
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.m_keysComboBox = new System.Windows.Forms.ComboBox();
			this.m_altCheckBox = new System.Windows.Forms.CheckBox();
			this.m_shiftCheckBox = new System.Windows.Forms.CheckBox();
			this.m_ctrlCheckBox = new System.Windows.Forms.CheckBox();
			this.m_winCheckBox = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(627, 581);
			this.panel1.TabIndex = 0;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(3, 3);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(621, 575);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.numericUpDown1);
			this.tabPage1.Controls.Add(this.checkBox2);
			this.tabPage1.Controls.Add(this.checkBox1);
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(613, 546);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "General";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(230, 475);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(148, 40);
			this.button1.TabIndex = 0;
			this.button1.Text = "Restore defaults";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(613, 546);
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
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(601, 107);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "New task";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(168, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(18, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "+";
			// 
			// m_keysComboBox
			// 
			this.m_keysComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_keysComboBox.FormattingEnabled = true;
			this.m_keysComboBox.Location = new System.Drawing.Point(213, 42);
			this.m_keysComboBox.Name = "m_keysComboBox";
			this.m_keysComboBox.Size = new System.Drawing.Size(137, 24);
			this.m_keysComboBox.TabIndex = 4;
			// 
			// m_altCheckBox
			// 
			this.m_altCheckBox.Location = new System.Drawing.Point(91, 58);
			this.m_altCheckBox.Name = "m_altCheckBox";
			this.m_altCheckBox.Size = new System.Drawing.Size(71, 24);
			this.m_altCheckBox.TabIndex = 2;
			this.m_altCheckBox.Text = "Alt";
			this.m_altCheckBox.UseVisualStyleBackColor = true;
			// 
			// m_shiftCheckBox
			// 
			this.m_shiftCheckBox.Location = new System.Drawing.Point(22, 29);
			this.m_shiftCheckBox.Name = "m_shiftCheckBox";
			this.m_shiftCheckBox.Size = new System.Drawing.Size(63, 24);
			this.m_shiftCheckBox.TabIndex = 3;
			this.m_shiftCheckBox.Text = "Shift";
			this.m_shiftCheckBox.UseVisualStyleBackColor = true;
			// 
			// m_ctrlCheckBox
			// 
			this.m_ctrlCheckBox.Location = new System.Drawing.Point(22, 59);
			this.m_ctrlCheckBox.Name = "m_ctrlCheckBox";
			this.m_ctrlCheckBox.Size = new System.Drawing.Size(57, 24);
			this.m_ctrlCheckBox.TabIndex = 0;
			this.m_ctrlCheckBox.Text = "Ctrl";
			this.m_ctrlCheckBox.UseVisualStyleBackColor = true;
			// 
			// m_winCheckBox
			// 
			this.m_winCheckBox.Location = new System.Drawing.Point(91, 29);
			this.m_winCheckBox.Name = "m_winCheckBox";
			this.m_winCheckBox.Size = new System.Drawing.Size(71, 24);
			this.m_winCheckBox.TabIndex = 1;
			this.m_winCheckBox.Text = "Win";
			this.m_winCheckBox.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(27, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(217, 24);
			this.checkBox1.TabIndex = 1;
			this.checkBox1.Text = "Start Minder with Windows";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(27, 49);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(217, 24);
			this.checkBox2.TabIndex = 2;
			this.checkBox2.Text = "Check automatic updates";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(27, 79);
			this.numericUpDown1.Maximum = new decimal(new int[] {
									10000,
									0,
									0,
									0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(76, 22);
			this.numericUpDown1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(109, 81);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Tasks limit";
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(651, 605);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "SettingsForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SettingsForm";
			this.panel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
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
