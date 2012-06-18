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
			// m_remainderMeLaterButton
			// 
			this.RemainderMeLaterButton.Location = new System.Drawing.Point(126, 73);
			this.RemainderMeLaterButton.Name = "m_remainderMeLaterButton";
			this.RemainderMeLaterButton.Size = new System.Drawing.Size(107, 32);
			this.RemainderMeLaterButton.TabIndex = 0;
			this.RemainderMeLaterButton.Text = "Remind me later";
			this.RemainderMeLaterButton.UseVisualStyleBackColor = true;
			// 
			// m_okButton
			// 
			this.OkButton.Location = new System.Drawing.Point(12, 73);
			this.OkButton.Name = "m_okButton";
			this.OkButton.Size = new System.Drawing.Size(107, 32);
			this.OkButton.TabIndex = 2;
			this.OkButton.Text = "Ok";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// m_textBox
			// 
			this.TextBox.Location = new System.Drawing.Point(12, 9);
			this.TextBox.Name = "m_textBox";
			this.TextBox.Size = new System.Drawing.Size(221, 72);
			this.TextBox.TabIndex = 3;
			this.TextBox.Text = "Task: task description\r\n\r\nTime: task time";
			// 
			// TaskShowForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(245, 111);
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
		public System.Windows.Forms.Button OkButton;
		public System.Windows.Forms.Label TextBox;
		public System.Windows.Forms.Button RemainderMeLaterButton;
	}
}
