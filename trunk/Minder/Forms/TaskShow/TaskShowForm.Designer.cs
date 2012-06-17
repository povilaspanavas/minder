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
			this.m_remainderMeLaterButton = new System.Windows.Forms.Button();
			this.m_okButton = new System.Windows.Forms.Button();
			this.m_textBox = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_remainderMeLaterButton
			// 
			this.m_remainderMeLaterButton.Location = new System.Drawing.Point(178, 89);
			this.m_remainderMeLaterButton.Name = "m_remainderMeLaterButton";
			this.m_remainderMeLaterButton.Size = new System.Drawing.Size(107, 30);
			this.m_remainderMeLaterButton.TabIndex = 0;
			this.m_remainderMeLaterButton.Text = "Remind me later";
			this.m_remainderMeLaterButton.UseVisualStyleBackColor = true;
			// 
			// m_okButton
			// 
			this.m_okButton.Location = new System.Drawing.Point(52, 89);
			this.m_okButton.Name = "m_okButton";
			this.m_okButton.Size = new System.Drawing.Size(107, 30);
			this.m_okButton.TabIndex = 2;
			this.m_okButton.Text = "Ok";
			this.m_okButton.UseVisualStyleBackColor = true;
			// 
			// m_textBox
			// 
			this.m_textBox.Location = new System.Drawing.Point(12, 20);
			this.m_textBox.Name = "m_textBox";
			this.m_textBox.Size = new System.Drawing.Size(315, 66);
			this.m_textBox.TabIndex = 3;
			this.m_textBox.Text = "Task: task description\r\n\r\nTime: task time";
			// 
			// TaskShowForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(339, 140);
			this.Controls.Add(this.m_textBox);
			this.Controls.Add(this.m_okButton);
			this.Controls.Add(this.m_remainderMeLaterButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TaskShowForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TaskShowForm";
			this.TopMost = true;
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Button m_okButton;
		public System.Windows.Forms.Label m_textBox;
		public System.Windows.Forms.Button m_remainderMeLaterButton;
	}
}
