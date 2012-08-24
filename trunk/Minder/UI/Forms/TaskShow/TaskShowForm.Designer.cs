/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.17
 * Time: 18:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Minder.Forms.TaskShow
{
	partial class TaskShowForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskShowForm));
			this.RemainderMeLaterButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.TextBox = new System.Windows.Forms.Label();
			this.MComboBoxRemindLater = new System.Windows.Forms.ComboBox();
			this.ButtonEditTask = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// RemainderMeLaterButton
			// 
			this.RemainderMeLaterButton.Location = new System.Drawing.Point(126, 109);
			this.RemainderMeLaterButton.Name = "RemainderMeLaterButton";
			this.RemainderMeLaterButton.Size = new System.Drawing.Size(107, 32);
			this.RemainderMeLaterButton.TabIndex = 1;
			this.RemainderMeLaterButton.Text = "Remind Me Later";
			this.RemainderMeLaterButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(12, 73);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(107, 32);
			this.OkButton.TabIndex = 0;
			this.OkButton.Text = "Close Task";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// TextBox
			// 
			this.TextBox.Location = new System.Drawing.Point(12, 9);
			this.TextBox.Name = "TextBox";
			this.TextBox.Size = new System.Drawing.Size(221, 72);
			this.TextBox.TabIndex = 4;
			this.TextBox.Text = "Task: task description\r\n\r\nTime: task time";
			// 
			// MComboBoxRemindLater
			// 
			this.MComboBoxRemindLater.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MComboBoxRemindLater.FormattingEnabled = true;
			this.MComboBoxRemindLater.Location = new System.Drawing.Point(12, 115);
			this.MComboBoxRemindLater.Name = "MComboBoxRemindLater";
			this.MComboBoxRemindLater.Size = new System.Drawing.Size(107, 22);
			this.MComboBoxRemindLater.TabIndex = 3;
			// 
			// ButtonEditTask
			// 
			this.ButtonEditTask.Location = new System.Drawing.Point(126, 73);
			this.ButtonEditTask.Name = "ButtonEditTask";
			this.ButtonEditTask.Size = new System.Drawing.Size(107, 32);
			this.ButtonEditTask.TabIndex = 2;
			this.ButtonEditTask.Text = "Edit Task";
			this.ButtonEditTask.UseVisualStyleBackColor = true;
			// 
			// TaskShowForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(248, 153);
			this.ControlBox = false;
			this.Controls.Add(this.ButtonEditTask);
			this.Controls.Add(this.MComboBoxRemindLater);
			this.Controls.Add(this.RemainderMeLaterButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.TextBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TaskShowForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TaskShowForm";
			this.TopMost = true;
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Button ButtonEditTask;
		public System.Windows.Forms.ComboBox MComboBoxRemindLater;
		public System.Windows.Forms.Button OkButton;
		public System.Windows.Forms.Label TextBox;
		public System.Windows.Forms.Button RemainderMeLaterButton;
	}
}
