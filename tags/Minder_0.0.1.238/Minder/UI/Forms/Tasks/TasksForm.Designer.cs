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
			this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.SOURCE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
			this.MTaskGrid.AllowUserToAddRows = false;
			this.MTaskGrid.AllowUserToDeleteRows = false;
			this.MTaskGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.MTaskGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.MTaskGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Column1,
									this.Column2,
									this.Column3,
									this.ID,
									this.SOURCE_ID});
			this.MTaskGrid.Location = new System.Drawing.Point(3, 42);
			this.MTaskGrid.Name = "MTaskGrid";
			this.MTaskGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.MTaskGrid.Size = new System.Drawing.Size(469, 434);
			this.MTaskGrid.TabIndex = 2;
			// 
			// Column1
			// 
			this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column1.HeaderText = "Task";
			this.Column1.MinimumWidth = 100;
			this.Column1.Name = "Column1";
			this.Column1.ReadOnly = true;
			// 
			// Column2
			// 
			this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column2.FillWeight = 60F;
			this.Column2.HeaderText = "Date";
			this.Column2.MinimumWidth = 60;
			this.Column2.Name = "Column2";
			this.Column2.ReadOnly = true;
			// 
			// Column3
			// 
			this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Column3.FillWeight = 40F;
			this.Column3.HeaderText = "Showed";
			this.Column3.MinimumWidth = 40;
			this.Column3.Name = "Column3";
			this.Column3.ReadOnly = true;
			// 
			// ID
			// 
			this.ID.HeaderText = "Column4";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			this.ID.Visible = false;
			// 
			// SOURCE_ID
			// 
			this.SOURCE_ID.HeaderText = "Column4";
			this.SOURCE_ID.Name = "SOURCE_ID";
			this.SOURCE_ID.ReadOnly = true;
			this.SOURCE_ID.Visible = false;
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
			this.ClientSize = new System.Drawing.Size(476, 478);
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
		private System.Windows.Forms.DataGridViewTextBoxColumn SOURCE_ID;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		public System.Windows.Forms.Button MDeleteButton;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		public System.Windows.Forms.DataGridView MTaskGrid;
		public System.Windows.Forms.Button MEditButton;
		public System.Windows.Forms.Button MNewButton;
	}
}
