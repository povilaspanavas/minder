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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.label1 = new System.Windows.Forms.Label();
			this.MVersionLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.MLinkLabelSupport = new System.Windows.Forms.LinkLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.MCoreVersionLabel = new System.Windows.Forms.Label();
			this.MLabelLogFile = new System.Windows.Forms.LinkLabel();
			this.label3 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(66, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(260, 68);
			this.label1.TabIndex = 0;
			this.label1.Text = "The idea: Ignas Bagdonas\r\nDevelopers: Ignas Bagdonas, Povilas Panavas\r\n\r\nProject " +
			"start time: 2012.06.04";
			// 
			// MVersionLabel
			// 
			this.MVersionLabel.Location = new System.Drawing.Point(13, 97);
			this.MVersionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MVersionLabel.Name = "MVersionLabel";
			this.MVersionLabel.Size = new System.Drawing.Size(260, 20);
			this.MVersionLabel.TabIndex = 1;
			this.MVersionLabel.Text = "Version: ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 138);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 20);
			this.label2.TabIndex = 2;
			this.label2.Text = "Support:";
			// 
			// MLinkLabelSupport
			// 
			this.MLinkLabelSupport.Location = new System.Drawing.Point(56, 138);
			this.MLinkLabelSupport.Name = "MLinkLabelSupport";
			this.MLinkLabelSupport.Size = new System.Drawing.Size(183, 25);
			this.MLinkLabelSupport.TabIndex = 3;
			this.MLinkLabelSupport.TabStop = true;
			this.MLinkLabelSupport.Text = "http://code.google.com/p/minder/";
			this.MLinkLabelSupport.UseWaitCursor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(13, 13);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(48, 54);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// MCoreVersionLabel
			// 
			this.MCoreVersionLabel.Location = new System.Drawing.Point(13, 117);
			this.MCoreVersionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.MCoreVersionLabel.Name = "MCoreVersionLabel";
			this.MCoreVersionLabel.Size = new System.Drawing.Size(260, 20);
			this.MCoreVersionLabel.TabIndex = 5;
			this.MCoreVersionLabel.Text = "Core version: ";
			// 
			// MLabelLogFile
			// 
			this.MLabelLogFile.Location = new System.Drawing.Point(56, 158);
			this.MLabelLogFile.Name = "MLabelLogFile";
			this.MLabelLogFile.Size = new System.Drawing.Size(183, 25);
			this.MLabelLogFile.TabIndex = 7;
			this.MLabelLogFile.TabStop = true;
			this.MLabelLogFile.Text = "Click To Open Log File";
			this.MLabelLogFile.UseWaitCursor = true;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(13, 158);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 20);
			this.label3.TabIndex = 6;
			this.label3.Text = "Log file:";
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(302, 219);
			this.Controls.Add(this.MLabelLogFile);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.MCoreVersionLabel);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.MLinkLabelSupport);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.MVersionLabel);
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
		public System.Windows.Forms.ToolTip toolTip1;
		public System.Windows.Forms.Label label3;
		public System.Windows.Forms.LinkLabel MLabelLogFile;
		public System.Windows.Forms.Label MCoreVersionLabel;
		private System.Windows.Forms.PictureBox pictureBox1;
		public System.Windows.Forms.LinkLabel MLinkLabelSupport;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label MVersionLabel;
		private System.Windows.Forms.Label label1;
	}
}
