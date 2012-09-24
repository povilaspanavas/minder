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
			this.MNewButton = new System.Windows.Forms.Button();
			this.MEditButton = new System.Windows.Forms.Button();
			this.MTaskGrid = new System.Windows.Forms.DataGridView();
			this.MDeleteButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.MTaskGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// MNewButton
			// 
			this.MNewButton.Location = new System.Drawing.Point(3, 2);
			this.MNewButton.Name = "MNewButton";
			this.MNewButton.Size = new System.Drawing.Size(102, 34);
			this.MNewButton.TabIndex = 0;
			this.MNewButton.Text = "New";
			this.MNewButton.UseVisualStyleBackColor = true;
			// 
			// MEditButton
			// 
			this.MEditButton.Location = new System.Drawing.Point(111, 2);
			this.MEditButton.Name = "MEditButton";
			this.MEditButton.Size = new System.Drawing.Size(102, 34);
			this.MEditButton.TabIndex = 1;
			this.MEditButton.Text = "Edit";
			this.MEditButton.UseVisualStyleBackColor = true;
			// 
			// MTaskGrid
			// 
			this.MTaskGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.MTaskGrid.Location = new System.Drawing.Point(3, 42);
			this.MTaskGrid.Name = "MTaskGrid";
			this.MTaskGrid.Size = new System.Drawing.Size(530, 436);
			this.MTaskGrid.TabIndex = 2;
			// 
			// MDeleteButton
			// 
			this.MDeleteButton.Location = new System.Drawing.Point(219, 2);
			this.MDeleteButton.Name = "MDeleteButton";
			this.MDeleteButton.Size = new System.Drawing.Size(102, 34);
			this.MDeleteButton.TabIndex = 3;
			this.MDeleteButton.Text = "Delete";
			this.MDeleteButton.UseVisualStyleBackColor = true;
			// 
			// TasksForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(537, 480);
			this.Controls.Add(this.MDeleteButton);
			this.Controls.Add(this.MTaskGrid);
			this.Controls.Add(this.MEditButton);
			this.Controls.Add(this.MNewButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "TasksForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TasksForm";
			((System.ComponentModel.ISupportInitialize)(this.MTaskGrid)).EndInit();
			this.ResumeLayout(false);
		}
		public System.Windows.Forms.Button MDeleteButton;
		public System.Windows.Forms.DataGridView MTaskGrid;
		public System.Windows.Forms.Button MEditButton;
		public System.Windows.Forms.Button MNewButton;
	}
}
