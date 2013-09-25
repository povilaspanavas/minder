/*
 * Created by SharpDevelop.
 * User: IGNAS
 * Date: 2012.06.20
 * Time: 00:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Minder.Forms.Tasks
{
	partial class TasksForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TasksForm));
			this.MTaskGrid = new System.Windows.Forms.DataGridView();
			this.MNewButton = new Core.UI.Controls.Buttons.CoreNewButton();
			this.MEditButton = new Core.UI.Controls.Buttons.CoreEditButton();
			this.MDeleteButton = new Core.UI.Controls.Buttons.CoreDeleteButton();
			((System.ComponentModel.ISupportInitialize)(this.MTaskGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// MTaskGrid
			// 
			this.MTaskGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.MTaskGrid.Location = new System.Drawing.Point(3, 54);
			this.MTaskGrid.Name = "MTaskGrid";
			this.MTaskGrid.Size = new System.Drawing.Size(530, 390);
			this.MTaskGrid.TabIndex = 2;
			// 
			// MNewButton
			// 
			this.MNewButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MNewButton.BackgroundImage")));
			this.MNewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.MNewButton.Location = new System.Drawing.Point(3, 8);
			this.MNewButton.Name = "MNewButton";
			this.MNewButton.Size = new System.Drawing.Size(40, 40);
			this.MNewButton.TabIndex = 4;
			this.MNewButton.UseVisualStyleBackColor = true;
			// 
			// MEditButton
			// 
			this.MEditButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MEditButton.BackgroundImage")));
			this.MEditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.MEditButton.Location = new System.Drawing.Point(49, 8);
			this.MEditButton.Name = "MEditButton";
			this.MEditButton.Size = new System.Drawing.Size(40, 40);
			this.MEditButton.TabIndex = 5;
			this.MEditButton.UseVisualStyleBackColor = true;
			// 
			// MDeleteButton
			// 
			this.MDeleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("MDeleteButton.BackgroundImage")));
			this.MDeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.MDeleteButton.Location = new System.Drawing.Point(95, 8);
			this.MDeleteButton.Name = "MDeleteButton";
			this.MDeleteButton.Size = new System.Drawing.Size(40, 40);
			this.MDeleteButton.TabIndex = 6;
			this.MDeleteButton.UseVisualStyleBackColor = true;
			// 
			// TasksForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(537, 446);
			this.Controls.Add(this.MDeleteButton);
			this.Controls.Add(this.MEditButton);
			this.Controls.Add(this.MNewButton);
			this.Controls.Add(this.MTaskGrid);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TasksForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TasksForm";
			((System.ComponentModel.ISupportInitialize)(this.MTaskGrid)).EndInit();
			this.ResumeLayout(false);
		}
		public Core.UI.Controls.Buttons.CoreDeleteButton MDeleteButton;
		public System.Windows.Forms.DataGridView MTaskGrid;
		public Core.UI.Controls.Buttons.CoreEditButton MEditButton;
		public Core.UI.Controls.Buttons.CoreNewButton MNewButton;
	}
}
