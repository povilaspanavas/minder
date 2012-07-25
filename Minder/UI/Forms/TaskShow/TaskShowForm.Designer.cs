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
			this.SuspendLayout();
			// 
			// RemainderMeLaterButton
			// 
			this.RemainderMeLaterButton.Location = new System.Drawing.Point(168, 83);
			this.RemainderMeLaterButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.RemainderMeLaterButton.Name = "RemainderMeLaterButton";
			this.RemainderMeLaterButton.Size = new System.Drawing.Size(143, 37);
			this.RemainderMeLaterButton.TabIndex = 0;
			this.RemainderMeLaterButton.Text = "Remind me later";
			this.RemainderMeLaterButton.UseVisualStyleBackColor = true;
			// 
			// OkButton
			// 
			this.OkButton.Location = new System.Drawing.Point(16, 83);
			this.OkButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(143, 37);
			this.OkButton.TabIndex = 2;
			this.OkButton.Text = "Ok";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// TextBox
			// 
			this.TextBox.Location = new System.Drawing.Point(16, 10);
			this.TextBox.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.TextBox.Name = "TextBox";
			this.TextBox.Size = new System.Drawing.Size(295, 82);
			this.TextBox.TabIndex = 3;
			this.TextBox.Text = "Task: task description\r\n\r\nTime: task time";
			// 
			// TaskShowForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(327, 127);
			this.ControlBox = false;
			this.Controls.Add(this.RemainderMeLaterButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.TextBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TaskShowForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TaskShowForm";
			this.TopMost = true;
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Button OkButton;
		public System.Windows.Forms.Label TextBox;
		public System.Windows.Forms.Button RemainderMeLaterButton;
	}
}
