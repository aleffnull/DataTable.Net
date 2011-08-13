namespace DataTable.Net.Forms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.MainToolStripContainer = new System.Windows.Forms.ToolStripContainer();
			this.DataGridView = new System.Windows.Forms.DataGridView();
			this.MainToolBar = new System.Windows.Forms.ToolStrip();
			this.OpenToolStripSplitButton = new System.Windows.Forms.ToolStripSplitButton();
			this.ReloadToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ExportToFileToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.ExportToExcelToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.DataPropertiesToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.SettingsToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.AboutToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.RecentFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ReloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ExportToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ExportToExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolsToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.DataPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.DummyMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ClearRecentFilesListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.FilePathStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.ExportFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.MainToolStripContainer.ContentPanel.SuspendLayout();
			this.MainToolStripContainer.TopToolStripPanel.SuspendLayout();
			this.MainToolStripContainer.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
			this.MainToolBar.SuspendLayout();
			this.MainMenu.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainToolStripContainer
			// 
			resources.ApplyResources(this.MainToolStripContainer, "MainToolStripContainer");
			// 
			// MainToolStripContainer.BottomToolStripPanel
			// 
			resources.ApplyResources(this.MainToolStripContainer.BottomToolStripPanel, "MainToolStripContainer.BottomToolStripPanel");
			this.MainToolStripContainer.BottomToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// MainToolStripContainer.ContentPanel
			// 
			resources.ApplyResources(this.MainToolStripContainer.ContentPanel, "MainToolStripContainer.ContentPanel");
			this.MainToolStripContainer.ContentPanel.Controls.Add(this.DataGridView);
			// 
			// MainToolStripContainer.LeftToolStripPanel
			// 
			resources.ApplyResources(this.MainToolStripContainer.LeftToolStripPanel, "MainToolStripContainer.LeftToolStripPanel");
			this.MainToolStripContainer.LeftToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.MainToolStripContainer.Name = "MainToolStripContainer";
			// 
			// MainToolStripContainer.RightToolStripPanel
			// 
			resources.ApplyResources(this.MainToolStripContainer.RightToolStripPanel, "MainToolStripContainer.RightToolStripPanel");
			this.MainToolStripContainer.RightToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// MainToolStripContainer.TopToolStripPanel
			// 
			resources.ApplyResources(this.MainToolStripContainer.TopToolStripPanel, "MainToolStripContainer.TopToolStripPanel");
			this.MainToolStripContainer.TopToolStripPanel.Controls.Add(this.MainToolBar);
			this.MainToolStripContainer.TopToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// DataGridView
			// 
			resources.ApplyResources(this.DataGridView, "DataGridView");
			this.DataGridView.AllowDrop = true;
			this.DataGridView.AllowUserToAddRows = false;
			this.DataGridView.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.DataGridView.DefaultCellStyle = dataGridViewCellStyle2;
			this.DataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.DataGridView.Name = "DataGridView";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.DataGridView.VirtualMode = true;
			this.DataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridView_CellBeginEdit);
			this.DataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DataGridView_CellValueNeeded);
			this.DataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DataGridView_CellValuePushed);
			this.DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView_DataError);
			this.DataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.DataGridView_DragDrop);
			this.DataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.DataGridView_DragEnter);
			// 
			// MainToolBar
			// 
			resources.ApplyResources(this.MainToolBar, "MainToolBar");
			this.MainToolBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripSplitButton,
            this.ReloadToolStripButton,
            this.toolStripSeparator1,
            this.ExportToFileToolStripButton,
            this.ExportToExcelToolStripButton,
            this.DataPropertiesToolStripButton,
            this.SettingsToolStripButton,
            this.toolStripSeparator2,
            this.AboutToolStripButton});
			this.MainToolBar.Name = "MainToolBar";
			this.MainToolBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// OpenToolStripSplitButton
			// 
			resources.ApplyResources(this.OpenToolStripSplitButton, "OpenToolStripSplitButton");
			this.OpenToolStripSplitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.OpenToolStripSplitButton.Name = "OpenToolStripSplitButton";
			this.OpenToolStripSplitButton.Click += new System.EventHandler(this.OpenToolStripSplitButton_Click);
			// 
			// ReloadToolStripButton
			// 
			resources.ApplyResources(this.ReloadToolStripButton, "ReloadToolStripButton");
			this.ReloadToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ReloadToolStripButton.Name = "ReloadToolStripButton";
			this.ReloadToolStripButton.Click += new System.EventHandler(this.ReloadToolStripButton_Click);
			// 
			// toolStripSeparator1
			// 
			resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			// 
			// ExportToFileToolStripButton
			// 
			resources.ApplyResources(this.ExportToFileToolStripButton, "ExportToFileToolStripButton");
			this.ExportToFileToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ExportToFileToolStripButton.Name = "ExportToFileToolStripButton";
			this.ExportToFileToolStripButton.Click += new System.EventHandler(this.ExportToFileToolStripButton_Click);
			// 
			// ExportToExcelToolStripButton
			// 
			resources.ApplyResources(this.ExportToExcelToolStripButton, "ExportToExcelToolStripButton");
			this.ExportToExcelToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.ExportToExcelToolStripButton.Name = "ExportToExcelToolStripButton";
			this.ExportToExcelToolStripButton.Click += new System.EventHandler(this.ExportToExcelToolStripButton_Click);
			// 
			// DataPropertiesToolStripButton
			// 
			resources.ApplyResources(this.DataPropertiesToolStripButton, "DataPropertiesToolStripButton");
			this.DataPropertiesToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.DataPropertiesToolStripButton.Name = "DataPropertiesToolStripButton";
			this.DataPropertiesToolStripButton.Click += new System.EventHandler(this.DataPropertiesToolStripButton_Click);
			// 
			// SettingsToolStripButton
			// 
			resources.ApplyResources(this.SettingsToolStripButton, "SettingsToolStripButton");
			this.SettingsToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.SettingsToolStripButton.Name = "SettingsToolStripButton";
			this.SettingsToolStripButton.Click += new System.EventHandler(this.SettingsToolStripButton_Click);
			// 
			// toolStripSeparator2
			// 
			resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			// 
			// AboutToolStripButton
			// 
			resources.ApplyResources(this.AboutToolStripButton, "AboutToolStripButton");
			this.AboutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.AboutToolStripButton.Name = "AboutToolStripButton";
			this.AboutToolStripButton.Click += new System.EventHandler(this.AboutToolStripButton_Click);
			// 
			// MainMenu
			// 
			resources.ApplyResources(this.MainMenu, "MainMenu");
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.HelpToolStripMenuItem,
            this.DummyMenuToolStripMenuItem});
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			// 
			// FileToolStripMenuItem
			// 
			resources.ApplyResources(this.FileToolStripMenuItem, "FileToolStripMenuItem");
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.RecentFilesToolStripMenuItem,
            this.ReloadToolStripMenuItem});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			// 
			// OpenToolStripMenuItem
			// 
			resources.ApplyResources(this.OpenToolStripMenuItem, "OpenToolStripMenuItem");
			this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
			this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// RecentFilesToolStripMenuItem
			// 
			resources.ApplyResources(this.RecentFilesToolStripMenuItem, "RecentFilesToolStripMenuItem");
			this.RecentFilesToolStripMenuItem.Name = "RecentFilesToolStripMenuItem";
			// 
			// ReloadToolStripMenuItem
			// 
			resources.ApplyResources(this.ReloadToolStripMenuItem, "ReloadToolStripMenuItem");
			this.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem";
			this.ReloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItem_Click);
			// 
			// ToolsToolStripMenuItem
			// 
			resources.ApplyResources(this.ToolsToolStripMenuItem, "ToolsToolStripMenuItem");
			this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportToolStripMenuItem,
            this.ToolsToolStripSeparator,
            this.DataPropertiesToolStripMenuItem,
            this.SettingsToolStripMenuItem});
			this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
			// 
			// ExportToolStripMenuItem
			// 
			resources.ApplyResources(this.ExportToolStripMenuItem, "ExportToolStripMenuItem");
			this.ExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportToFileToolStripMenuItem,
            this.ExportToExcelToolStripMenuItem});
			this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
			// 
			// ExportToFileToolStripMenuItem
			// 
			resources.ApplyResources(this.ExportToFileToolStripMenuItem, "ExportToFileToolStripMenuItem");
			this.ExportToFileToolStripMenuItem.Name = "ExportToFileToolStripMenuItem";
			this.ExportToFileToolStripMenuItem.Click += new System.EventHandler(this.ExportToFileToolStripMenuItem_Click);
			// 
			// ExportToExcelToolStripMenuItem
			// 
			resources.ApplyResources(this.ExportToExcelToolStripMenuItem, "ExportToExcelToolStripMenuItem");
			this.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem";
			this.ExportToExcelToolStripMenuItem.Click += new System.EventHandler(this.ExportToExcelToolStripMenuItem_Click);
			// 
			// ToolsToolStripSeparator
			// 
			resources.ApplyResources(this.ToolsToolStripSeparator, "ToolsToolStripSeparator");
			this.ToolsToolStripSeparator.Name = "ToolsToolStripSeparator";
			// 
			// DataPropertiesToolStripMenuItem
			// 
			resources.ApplyResources(this.DataPropertiesToolStripMenuItem, "DataPropertiesToolStripMenuItem");
			this.DataPropertiesToolStripMenuItem.Name = "DataPropertiesToolStripMenuItem";
			this.DataPropertiesToolStripMenuItem.Click += new System.EventHandler(this.DataPropertiesToolStripMenuItem_Click);
			// 
			// SettingsToolStripMenuItem
			// 
			resources.ApplyResources(this.SettingsToolStripMenuItem, "SettingsToolStripMenuItem");
			this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
			this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
			// 
			// HelpToolStripMenuItem
			// 
			resources.ApplyResources(this.HelpToolStripMenuItem, "HelpToolStripMenuItem");
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			// 
			// AboutToolStripMenuItem
			// 
			resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
			this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
			this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// DummyMenuToolStripMenuItem
			// 
			resources.ApplyResources(this.DummyMenuToolStripMenuItem, "DummyMenuToolStripMenuItem");
			this.DummyMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearRecentFilesListToolStripMenuItem});
			this.DummyMenuToolStripMenuItem.Name = "DummyMenuToolStripMenuItem";
			// 
			// ClearRecentFilesListToolStripMenuItem
			// 
			resources.ApplyResources(this.ClearRecentFilesListToolStripMenuItem, "ClearRecentFilesListToolStripMenuItem");
			this.ClearRecentFilesListToolStripMenuItem.Name = "ClearRecentFilesListToolStripMenuItem";
			// 
			// OpenFileDialog
			// 
			resources.ApplyResources(this.OpenFileDialog, "OpenFileDialog");
			// 
			// StatusStrip
			// 
			resources.ApplyResources(this.StatusStrip, "StatusStrip");
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.FilePathStatusLabel});
			this.StatusStrip.Name = "StatusStrip";
			// 
			// StatusLabel
			// 
			resources.ApplyResources(this.StatusLabel, "StatusLabel");
			this.StatusLabel.Name = "StatusLabel";
			// 
			// FilePathStatusLabel
			// 
			resources.ApplyResources(this.FilePathStatusLabel, "FilePathStatusLabel");
			this.FilePathStatusLabel.Name = "FilePathStatusLabel";
			// 
			// ExportFileDialog
			// 
			resources.ApplyResources(this.ExportFileDialog, "ExportFileDialog");
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MainToolStripContainer);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.MainMenu);
			this.Name = "MainForm";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MainToolStripContainer.ContentPanel.ResumeLayout(false);
			this.MainToolStripContainer.TopToolStripPanel.ResumeLayout(false);
			this.MainToolStripContainer.TopToolStripPanel.PerformLayout();
			this.MainToolStripContainer.ResumeLayout(false);
			this.MainToolStripContainer.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
			this.MainToolBar.ResumeLayout(false);
			this.MainToolBar.PerformLayout();
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip MainMenu;
		private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ReloadToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog OpenFileDialog;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.DataGridView DataGridView;
		private System.Windows.Forms.ToolStripStatusLabel FilePathStatusLabel;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.ToolStripMenuItem ToolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem DataPropertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ExportToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ExportToFileToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator ToolsToolStripSeparator;
		private System.Windows.Forms.SaveFileDialog ExportFileDialog;
		private System.Windows.Forms.ToolStripMenuItem ExportToExcelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem HelpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
		private System.Windows.Forms.ToolStrip MainToolBar;
		private System.Windows.Forms.ToolStripButton ReloadToolStripButton;
		private System.Windows.Forms.ToolStripContainer MainToolStripContainer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton ExportToExcelToolStripButton;
		private System.Windows.Forms.ToolStripButton ExportToFileToolStripButton;
		private System.Windows.Forms.ToolStripButton DataPropertiesToolStripButton;
		private System.Windows.Forms.ToolStripButton SettingsToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton AboutToolStripButton;
		private System.Windows.Forms.ToolStripMenuItem RecentFilesToolStripMenuItem;
		private System.Windows.Forms.ToolStripSplitButton OpenToolStripSplitButton;
		private System.Windows.Forms.ToolStripMenuItem DummyMenuToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ClearRecentFilesListToolStripMenuItem;
	}
}

