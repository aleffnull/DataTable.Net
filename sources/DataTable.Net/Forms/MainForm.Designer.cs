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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			this.MainMenu = new System.Windows.Forms.MenuStrip();
			this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
			this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.FilePathStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.DataGridView = new System.Windows.Forms.DataGridView();
			this.ExportFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.MainMenu.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
			this.SuspendLayout();
			// 
			// MainMenu
			// 
			this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ToolsToolStripMenuItem,
            this.HelpToolStripMenuItem});
			this.MainMenu.Location = new System.Drawing.Point(0, 0);
			this.MainMenu.Name = "MainMenu";
			this.MainMenu.Size = new System.Drawing.Size(617, 24);
			this.MainMenu.TabIndex = 0;
			this.MainMenu.Text = "menuStrip1";
			// 
			// FileToolStripMenuItem
			// 
			this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenToolStripMenuItem,
            this.ReloadToolStripMenuItem});
			this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
			this.FileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.FileToolStripMenuItem.Text = "&Файл";
			// 
			// OpenToolStripMenuItem
			// 
			this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
			this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.OpenToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.OpenToolStripMenuItem.Text = "&Открыть...";
			this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
			// 
			// ReloadToolStripMenuItem
			// 
			this.ReloadToolStripMenuItem.Name = "ReloadToolStripMenuItem";
			this.ReloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.ReloadToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
			this.ReloadToolStripMenuItem.Text = "&Перезагрузить";
			this.ReloadToolStripMenuItem.Click += new System.EventHandler(this.ReloadToolStripMenuItem_Click);
			// 
			// ToolsToolStripMenuItem
			// 
			this.ToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportToolStripMenuItem,
            this.ToolsToolStripSeparator,
            this.DataPropertiesToolStripMenuItem,
            this.SettingsToolStripMenuItem});
			this.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem";
			this.ToolsToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
			this.ToolsToolStripMenuItem.Text = "&Иструменты";
			// 
			// ExportToolStripMenuItem
			// 
			this.ExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExportToFileToolStripMenuItem,
            this.ExportToExcelToolStripMenuItem});
			this.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem";
			this.ExportToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.ExportToolStripMenuItem.Text = "&Экспорт";
			// 
			// ExportToFileToolStripMenuItem
			// 
			this.ExportToFileToolStripMenuItem.Name = "ExportToFileToolStripMenuItem";
			this.ExportToFileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
			this.ExportToFileToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.ExportToFileToolStripMenuItem.Text = "В &файл...";
			this.ExportToFileToolStripMenuItem.Click += new System.EventHandler(this.ExportToFileToolStripMenuItem_Click);
			// 
			// ExportToExcelToolStripMenuItem
			// 
			this.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem";
			this.ExportToExcelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
			this.ExportToExcelToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
			this.ExportToExcelToolStripMenuItem.Text = "В &Excel...";
			this.ExportToExcelToolStripMenuItem.Click += new System.EventHandler(this.ExportToExcelToolStripMenuItem_Click);
			// 
			// ToolsToolStripSeparator
			// 
			this.ToolsToolStripSeparator.Name = "ToolsToolStripSeparator";
			this.ToolsToolStripSeparator.Size = new System.Drawing.Size(174, 6);
			// 
			// DataPropertiesToolStripMenuItem
			// 
			this.DataPropertiesToolStripMenuItem.Name = "DataPropertiesToolStripMenuItem";
			this.DataPropertiesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.DataPropertiesToolStripMenuItem.Text = "&Свойства данных...";
			this.DataPropertiesToolStripMenuItem.Click += new System.EventHandler(this.DataPropertiesToolStripMenuItem_Click);
			// 
			// SettingsToolStripMenuItem
			// 
			this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
			this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
			this.SettingsToolStripMenuItem.Text = "&Настройки...";
			this.SettingsToolStripMenuItem.Click += new System.EventHandler(this.SettingsToolStripMenuItem_Click);
			// 
			// HelpToolStripMenuItem
			// 
			this.HelpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
			this.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem";
			this.HelpToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.HelpToolStripMenuItem.Text = "&Справка";
			// 
			// AboutToolStripMenuItem
			// 
			this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
			this.AboutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
			this.AboutToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
			this.AboutToolStripMenuItem.Text = "О &программе...";
			this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
			// 
			// OpenFileDialog
			// 
			this.OpenFileDialog.Filter = "Файлы данных|*.dat;*.hex|Все файлы|*.*";
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.FilePathStatusLabel});
			this.StatusStrip.Location = new System.Drawing.Point(0, 403);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(617, 22);
			this.StatusStrip.TabIndex = 1;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// FilePathStatusLabel
			// 
			this.FilePathStatusLabel.Name = "FilePathStatusLabel";
			this.FilePathStatusLabel.Size = new System.Drawing.Size(0, 17);
			// 
			// DataGridView
			// 
			this.DataGridView.AllowDrop = true;
			this.DataGridView.AllowUserToAddRows = false;
			this.DataGridView.AllowUserToDeleteRows = false;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.DataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.DataGridView.DefaultCellStyle = dataGridViewCellStyle3;
			this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.DataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.DataGridView.Location = new System.Drawing.Point(0, 24);
			this.DataGridView.Name = "DataGridView";
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.DataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.DataGridView.Size = new System.Drawing.Size(617, 379);
			this.DataGridView.TabIndex = 2;
			this.DataGridView.VirtualMode = true;
			this.DataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.DataGridView_CellBeginEdit);
			this.DataGridView.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DataGridView_CellValueNeeded);
			this.DataGridView.CellValuePushed += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DataGridView_CellValuePushed);
			this.DataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridView_DataError);
			this.DataGridView.DragDrop += new System.Windows.Forms.DragEventHandler(this.DataGridView_DragDrop);
			this.DataGridView.DragEnter += new System.Windows.Forms.DragEventHandler(this.DataGridView_DragEnter);
			// 
			// ExportFileDialog
			// 
			this.ExportFileDialog.Filter = "CSV файлы|*.csv|Все файлы|*.*";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(617, 425);
			this.Controls.Add(this.DataGridView);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.MainMenu);
			this.Name = "MainForm";
			this.Text = "DataTable.Net";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MainMenu.ResumeLayout(false);
			this.MainMenu.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
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
	}
}

