/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.14
 * Time: 22:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Minder.Forms.About
{
	partial class AboutForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.label1 = new System.Windows.Forms.Label();
			this.m_versionLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 10);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(347, 77);
			this.label1.TabIndex = 0;
			this.label1.Text = "The idea: Ignas Bagdonas\r\nDevelopers Ignas Bagdonas, Povilas Panavas\r\n\r\nProject s" +
			"tart time: 2012.06.04";
			// 
			// m_versionLabel
			// 
			this.m_versionLabel.Location = new System.Drawing.Point(16, 77);
			this.m_versionLabel.Name = "m_versionLabel";
			this.m_versionLabel.Size = new System.Drawing.Size(347, 23);
			this.m_versionLabel.TabIndex = 1;
			this.m_versionLabel.Text = "Version: ";
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(402, 250);
			this.Controls.Add(this.m_versionLabel);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AboutForm";
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Label m_versionLabel;
		private System.Windows.Forms.Label label1;
	}
}
