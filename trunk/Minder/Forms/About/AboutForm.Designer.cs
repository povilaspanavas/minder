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
			this.label2 = new System.Windows.Forms.Label();
			this.m_linkLabelSupport = new System.Windows.Forms.LinkLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(66, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 63);
			this.label1.TabIndex = 0;
			this.label1.Text = "The idea: Ignas Bagdonas\r\nDevelopers: Ignas Bagdonas, Povilas Panavas\r\n\r\nProject " +
			"start time: 2012.06.04";
			// 
			// m_versionLabel
			// 
			this.m_versionLabel.Location = new System.Drawing.Point(13, 90);
			this.m_versionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_versionLabel.Name = "m_versionLabel";
			this.m_versionLabel.Size = new System.Drawing.Size(260, 19);
			this.m_versionLabel.TabIndex = 1;
			this.m_versionLabel.Text = "Version: ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 109);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "Support:";
			// 
			// m_linkLabelSupport
			// 
			this.m_linkLabelSupport.Location = new System.Drawing.Point(56, 109);
			this.m_linkLabelSupport.Name = "m_linkLabelSupport";
			this.m_linkLabelSupport.Size = new System.Drawing.Size(183, 23);
			this.m_linkLabelSupport.TabIndex = 3;
			this.m_linkLabelSupport.TabStop = true;
			this.m_linkLabelSupport.Text = "http://code.google.com/p/minder/";
			this.m_linkLabelSupport.UseWaitCursor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(13, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(48, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(302, 203);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.m_linkLabelSupport);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_versionLabel);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AboutForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.PictureBox pictureBox1;
		public System.Windows.Forms.LinkLabel m_linkLabelSupport;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label m_versionLabel;
		private System.Windows.Forms.Label label1;
	}
}
