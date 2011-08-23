namespace DataTable.Net.Forms
{
	partial class SettingsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
			this.MaxAbsoluteScalePowerLabel = new System.Windows.Forms.Label();
			this.MaxAbsoluteScalePowerUpDown = new System.Windows.Forms.NumericUpDown();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancelationButton = new System.Windows.Forms.Button();
			this.ExportValuesSeparatorLabel = new System.Windows.Forms.Label();
			this.ExportValuesSeparatorTextBox = new System.Windows.Forms.TextBox();
			this.SettingsTabControl = new System.Windows.Forms.TabControl();
			this.GeneralTabPage = new System.Windows.Forms.TabPage();
			this.LanguageComboBox = new System.Windows.Forms.ComboBox();
			this.LanguageLabel = new System.Windows.Forms.Label();
			this.RecentFilesCountUpDown = new System.Windows.Forms.NumericUpDown();
			this.RecentFileCountLabel = new System.Windows.Forms.Label();
			this.IntegrationTabPage = new System.Windows.Forms.TabPage();
			this.FileTypeCheckBoxesLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SelectAllFileTypesButton = new System.Windows.Forms.Button();
			this.FileTypesLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.MaxAbsoluteScalePowerUpDown)).BeginInit();
			this.SettingsTabControl.SuspendLayout();
			this.GeneralTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RecentFilesCountUpDown)).BeginInit();
			this.IntegrationTabPage.SuspendLayout();
			this.SuspendLayout();
			// 
			// MaxAbsoluteScalePowerLabel
			// 
			resources.ApplyResources(this.MaxAbsoluteScalePowerLabel, "MaxAbsoluteScalePowerLabel");
			this.MaxAbsoluteScalePowerLabel.Name = "MaxAbsoluteScalePowerLabel";
			// 
			// MaxAbsoluteScalePowerUpDown
			// 
			resources.ApplyResources(this.MaxAbsoluteScalePowerUpDown, "MaxAbsoluteScalePowerUpDown");
			this.MaxAbsoluteScalePowerUpDown.Name = "MaxAbsoluteScalePowerUpDown";
			// 
			// OkButton
			// 
			resources.ApplyResources(this.OkButton, "OkButton");
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Name = "OkButton";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// CancelationButton
			// 
			resources.ApplyResources(this.CancelationButton, "CancelationButton");
			this.CancelationButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelationButton.Name = "CancelationButton";
			this.CancelationButton.UseVisualStyleBackColor = true;
			// 
			// ExportValuesSeparatorLabel
			// 
			resources.ApplyResources(this.ExportValuesSeparatorLabel, "ExportValuesSeparatorLabel");
			this.ExportValuesSeparatorLabel.Name = "ExportValuesSeparatorLabel";
			// 
			// ExportValuesSeparatorTextBox
			// 
			resources.ApplyResources(this.ExportValuesSeparatorTextBox, "ExportValuesSeparatorTextBox");
			this.ExportValuesSeparatorTextBox.Name = "ExportValuesSeparatorTextBox";
			// 
			// SettingsTabControl
			// 
			resources.ApplyResources(this.SettingsTabControl, "SettingsTabControl");
			this.SettingsTabControl.Controls.Add(this.GeneralTabPage);
			this.SettingsTabControl.Controls.Add(this.IntegrationTabPage);
			this.SettingsTabControl.Name = "SettingsTabControl";
			this.SettingsTabControl.SelectedIndex = 0;
			// 
			// GeneralTabPage
			// 
			resources.ApplyResources(this.GeneralTabPage, "GeneralTabPage");
			this.GeneralTabPage.Controls.Add(this.LanguageComboBox);
			this.GeneralTabPage.Controls.Add(this.LanguageLabel);
			this.GeneralTabPage.Controls.Add(this.RecentFilesCountUpDown);
			this.GeneralTabPage.Controls.Add(this.RecentFileCountLabel);
			this.GeneralTabPage.Controls.Add(this.MaxAbsoluteScalePowerLabel);
			this.GeneralTabPage.Controls.Add(this.ExportValuesSeparatorTextBox);
			this.GeneralTabPage.Controls.Add(this.MaxAbsoluteScalePowerUpDown);
			this.GeneralTabPage.Controls.Add(this.ExportValuesSeparatorLabel);
			this.GeneralTabPage.Name = "GeneralTabPage";
			this.GeneralTabPage.UseVisualStyleBackColor = true;
			// 
			// LanguageComboBox
			// 
			resources.ApplyResources(this.LanguageComboBox, "LanguageComboBox");
			this.LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.LanguageComboBox.FormattingEnabled = true;
			this.LanguageComboBox.Name = "LanguageComboBox";
			// 
			// LanguageLabel
			// 
			resources.ApplyResources(this.LanguageLabel, "LanguageLabel");
			this.LanguageLabel.Name = "LanguageLabel";
			// 
			// RecentFilesCountUpDown
			// 
			resources.ApplyResources(this.RecentFilesCountUpDown, "RecentFilesCountUpDown");
			this.RecentFilesCountUpDown.Name = "RecentFilesCountUpDown";
			// 
			// RecentFileCountLabel
			// 
			resources.ApplyResources(this.RecentFileCountLabel, "RecentFileCountLabel");
			this.RecentFileCountLabel.Name = "RecentFileCountLabel";
			// 
			// IntegrationTabPage
			// 
			resources.ApplyResources(this.IntegrationTabPage, "IntegrationTabPage");
			this.IntegrationTabPage.Controls.Add(this.FileTypeCheckBoxesLayoutPanel);
			this.IntegrationTabPage.Controls.Add(this.SelectAllFileTypesButton);
			this.IntegrationTabPage.Controls.Add(this.FileTypesLabel);
			this.IntegrationTabPage.Name = "IntegrationTabPage";
			this.IntegrationTabPage.UseVisualStyleBackColor = true;
			// 
			// FileTypeCheckBoxesLayoutPanel
			// 
			resources.ApplyResources(this.FileTypeCheckBoxesLayoutPanel, "FileTypeCheckBoxesLayoutPanel");
			this.FileTypeCheckBoxesLayoutPanel.Name = "FileTypeCheckBoxesLayoutPanel";
			// 
			// SelectAllFileTypesButton
			// 
			resources.ApplyResources(this.SelectAllFileTypesButton, "SelectAllFileTypesButton");
			this.SelectAllFileTypesButton.Name = "SelectAllFileTypesButton";
			this.SelectAllFileTypesButton.UseVisualStyleBackColor = true;
			this.SelectAllFileTypesButton.Click += new System.EventHandler(this.SelectAllFileTypesButton_Click);
			// 
			// FileTypesLabel
			// 
			resources.ApplyResources(this.FileTypesLabel, "FileTypesLabel");
			this.FileTypesLabel.Name = "FileTypesLabel";
			// 
			// SettingsForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelationButton;
			this.Controls.Add(this.SettingsTabControl);
			this.Controls.Add(this.CancelationButton);
			this.Controls.Add(this.OkButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsForm";
			this.Load += new System.EventHandler(this.SettingsForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.MaxAbsoluteScalePowerUpDown)).EndInit();
			this.SettingsTabControl.ResumeLayout(false);
			this.GeneralTabPage.ResumeLayout(false);
			this.GeneralTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RecentFilesCountUpDown)).EndInit();
			this.IntegrationTabPage.ResumeLayout(false);
			this.IntegrationTabPage.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label MaxAbsoluteScalePowerLabel;
		private System.Windows.Forms.NumericUpDown MaxAbsoluteScalePowerUpDown;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CancelationButton;
		private System.Windows.Forms.Label ExportValuesSeparatorLabel;
		private System.Windows.Forms.TextBox ExportValuesSeparatorTextBox;
		private System.Windows.Forms.TabControl SettingsTabControl;
		private System.Windows.Forms.TabPage GeneralTabPage;
		private System.Windows.Forms.TabPage IntegrationTabPage;
		private System.Windows.Forms.Label FileTypesLabel;
		private System.Windows.Forms.Button SelectAllFileTypesButton;
		private System.Windows.Forms.FlowLayoutPanel FileTypeCheckBoxesLayoutPanel;
		private System.Windows.Forms.NumericUpDown RecentFilesCountUpDown;
		private System.Windows.Forms.Label RecentFileCountLabel;
		private System.Windows.Forms.ComboBox LanguageComboBox;
		private System.Windows.Forms.Label LanguageLabel;
	}
}