/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.20
 * Time: 21:07
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Minder.Forms.Tasks
{
	partial class TaskNewEditForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskNewEditForm));
			this.label1 = new System.Windows.Forms.Label();
			this.MTextBox = new Minder.Controls.MTextBox();
			this.MDatePicker = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.MShowedCheckBox = new System.Windows.Forms.CheckBox();
			this.MSaveButton = new Core.UI.Controlls.Buttons.CoreSaveButton();
			this.MCancelButton = new Core.UI.Controlls.Buttons.CoreCancelButton();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(10, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Text";
			// 
			// MTextBox
			// 
			this.MTextBox.Location = new System.Drawing.Point(46, 11);
			this.MTextBox.Multiline = true;
			this.MTextBox.Name = "MTextBox";
			this.MTextBox.Size = new System.Drawing.Size(267, 53);
			this.MTextBox.TabIndex = 1;
			// 
			// MDatePicker
			// 
			this.MDatePicker.CustomFormat = "yyyy.MM.dd HH:mm";
			this.MDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.MDatePicker.Location = new System.Drawing.Point(46, 71);
			this.MDatePicker.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
			this.MDatePicker.Name = "MDatePicker";
			this.MDatePicker.ShowUpDown = true;
			this.MDatePicker.Size = new System.Drawing.Size(267, 20);
			this.MDatePicker.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Date";
			// 
			// MShowedCheckBox
			// 
			this.MShowedCheckBox.Location = new System.Drawing.Point(46, 97);
			this.MShowedCheckBox.Name = "MShowedCheckBox";
			this.MShowedCheckBox.Size = new System.Drawing.Size(104, 24);
			this.MShowedCheckBox.TabIndex = 4;
			this.MShowedCheckBox.Text = "Showed";
			this.MShowedCheckBox.UseVisualStyleBackColor = true;
			// 
			// MSaveButton
			// 
			this.MSaveButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MSaveButton.BackgroundImage")));
			this.MSaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.MSaveButton.Location = new System.Drawing.Point(110, 123);
			this.MSaveButton.Name = "MSaveButton";
			this.MSaveButton.Size = new System.Drawing.Size(40, 40);
			this.MSaveButton.TabIndex = 7;
			this.MSaveButton.UseVisualStyleBackColor = true;
			// 
			// MCancelButton
			// 
			this.MCancelButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MCancelButton.BackgroundImage")));
			this.MCancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.MCancelButton.Location = new System.Drawing.Point(156, 123);
			this.MCancelButton.Name = "MCancelButton";
			this.MCancelButton.Size = new System.Drawing.Size(40, 40);
			this.MCancelButton.TabIndex = 9;
			this.MCancelButton.UseVisualStyleBackColor = true;
			// 
			// TaskNewEditForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(321, 175);
			this.Controls.Add(this.MCancelButton);
			this.Controls.Add(this.MSaveButton);
			this.Controls.Add(this.MShowedCheckBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.MDatePicker);
			this.Controls.Add(this.MTextBox);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "TaskNewEditForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TaskNewEditForm";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		public Core.UI.Controlls.Buttons.CoreCancelButton MCancelButton;
		public Core.UI.Controlls.Buttons.CoreSaveButton MSaveButton;
		public System.Windows.Forms.CheckBox MShowedCheckBox;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.DateTimePicker MDatePicker;
		public Minder.Controls.MTextBox MTextBox;
		private System.Windows.Forms.Label label1;
	}
}
