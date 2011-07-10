﻿namespace DataTable.Net.Forms
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
			this.IntegrationTabPage = new System.Windows.Forms.TabPage();
			this.FileTypeCheckBoxesLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
			this.SelectAllFileTypesButton = new System.Windows.Forms.Button();
			this.FileTypesLabel = new System.Windows.Forms.Label();
			this.RecentFileCountLabel = new System.Windows.Forms.Label();
			this.RecentFileCountUpDown = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.MaxAbsoluteScalePowerUpDown)).BeginInit();
			this.SettingsTabControl.SuspendLayout();
			this.GeneralTabPage.SuspendLayout();
			this.IntegrationTabPage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.RecentFileCountUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// MaxAbsoluteScalePowerLabel
			// 
			this.MaxAbsoluteScalePowerLabel.Location = new System.Drawing.Point(6, 3);
			this.MaxAbsoluteScalePowerLabel.Name = "MaxAbsoluteScalePowerLabel";
			this.MaxAbsoluteScalePowerLabel.Size = new System.Drawing.Size(185, 30);
			this.MaxAbsoluteScalePowerLabel.TabIndex = 0;
			this.MaxAbsoluteScalePowerLabel.Text = "Модуль максимально возможного показателя степени масштаба:";
			// 
			// MaxAbsoluteScalePowerUpDown
			// 
			this.MaxAbsoluteScalePowerUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MaxAbsoluteScalePowerUpDown.Location = new System.Drawing.Point(245, 8);
			this.MaxAbsoluteScalePowerUpDown.Name = "MaxAbsoluteScalePowerUpDown";
			this.MaxAbsoluteScalePowerUpDown.Size = new System.Drawing.Size(120, 20);
			this.MaxAbsoluteScalePowerUpDown.TabIndex = 1;
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(223, 177);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 2;
			this.OkButton.Text = "&OK";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// CancelationButton
			// 
			this.CancelationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancelationButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelationButton.Location = new System.Drawing.Point(304, 177);
			this.CancelationButton.Name = "CancelationButton";
			this.CancelationButton.Size = new System.Drawing.Size(75, 23);
			this.CancelationButton.TabIndex = 3;
			this.CancelationButton.Text = "О&тмена";
			this.CancelationButton.UseVisualStyleBackColor = true;
			// 
			// ExportValuesSeparatorLabel
			// 
			this.ExportValuesSeparatorLabel.AutoSize = true;
			this.ExportValuesSeparatorLabel.Location = new System.Drawing.Point(6, 37);
			this.ExportValuesSeparatorLabel.Name = "ExportValuesSeparatorLabel";
			this.ExportValuesSeparatorLabel.Size = new System.Drawing.Size(197, 13);
			this.ExportValuesSeparatorLabel.TabIndex = 4;
			this.ExportValuesSeparatorLabel.Text = "Разделитель столбцов при экспорте:";
			// 
			// ExportValuesSeparatorTextBox
			// 
			this.ExportValuesSeparatorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ExportValuesSeparatorTextBox.Location = new System.Drawing.Point(245, 34);
			this.ExportValuesSeparatorTextBox.Name = "ExportValuesSeparatorTextBox";
			this.ExportValuesSeparatorTextBox.Size = new System.Drawing.Size(120, 20);
			this.ExportValuesSeparatorTextBox.TabIndex = 5;
			this.ExportValuesSeparatorTextBox.Text = ";";
			// 
			// SettingsTabControl
			// 
			this.SettingsTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.SettingsTabControl.Controls.Add(this.GeneralTabPage);
			this.SettingsTabControl.Controls.Add(this.IntegrationTabPage);
			this.SettingsTabControl.Location = new System.Drawing.Point(3, 3);
			this.SettingsTabControl.Name = "SettingsTabControl";
			this.SettingsTabControl.SelectedIndex = 0;
			this.SettingsTabControl.Size = new System.Drawing.Size(380, 168);
			this.SettingsTabControl.TabIndex = 6;
			// 
			// GeneralTabPage
			// 
			this.GeneralTabPage.Controls.Add(this.RecentFileCountUpDown);
			this.GeneralTabPage.Controls.Add(this.RecentFileCountLabel);
			this.GeneralTabPage.Controls.Add(this.MaxAbsoluteScalePowerLabel);
			this.GeneralTabPage.Controls.Add(this.ExportValuesSeparatorTextBox);
			this.GeneralTabPage.Controls.Add(this.MaxAbsoluteScalePowerUpDown);
			this.GeneralTabPage.Controls.Add(this.ExportValuesSeparatorLabel);
			this.GeneralTabPage.Location = new System.Drawing.Point(4, 22);
			this.GeneralTabPage.Name = "GeneralTabPage";
			this.GeneralTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.GeneralTabPage.Size = new System.Drawing.Size(372, 142);
			this.GeneralTabPage.TabIndex = 0;
			this.GeneralTabPage.Text = "Общие";
			this.GeneralTabPage.UseVisualStyleBackColor = true;
			// 
			// IntegrationTabPage
			// 
			this.IntegrationTabPage.Controls.Add(this.FileTypeCheckBoxesLayoutPanel);
			this.IntegrationTabPage.Controls.Add(this.SelectAllFileTypesButton);
			this.IntegrationTabPage.Controls.Add(this.FileTypesLabel);
			this.IntegrationTabPage.Location = new System.Drawing.Point(4, 22);
			this.IntegrationTabPage.Name = "IntegrationTabPage";
			this.IntegrationTabPage.Padding = new System.Windows.Forms.Padding(3);
			this.IntegrationTabPage.Size = new System.Drawing.Size(372, 142);
			this.IntegrationTabPage.TabIndex = 1;
			this.IntegrationTabPage.Text = "Интеграция";
			this.IntegrationTabPage.UseVisualStyleBackColor = true;
			// 
			// FileTypeCheckBoxesLayoutPanel
			// 
			this.FileTypeCheckBoxesLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.FileTypeCheckBoxesLayoutPanel.Location = new System.Drawing.Point(9, 19);
			this.FileTypeCheckBoxesLayoutPanel.Name = "FileTypeCheckBoxesLayoutPanel";
			this.FileTypeCheckBoxesLayoutPanel.Size = new System.Drawing.Size(356, 88);
			this.FileTypeCheckBoxesLayoutPanel.TabIndex = 5;
			// 
			// SelectAllFileTypesButton
			// 
			this.SelectAllFileTypesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.SelectAllFileTypesButton.Location = new System.Drawing.Point(6, 113);
			this.SelectAllFileTypesButton.Name = "SelectAllFileTypesButton";
			this.SelectAllFileTypesButton.Size = new System.Drawing.Size(105, 23);
			this.SelectAllFileTypesButton.TabIndex = 4;
			this.SelectAllFileTypesButton.Text = "Выбрать &все";
			this.SelectAllFileTypesButton.UseVisualStyleBackColor = true;
			this.SelectAllFileTypesButton.Click += new System.EventHandler(this.SelectAllFileTypesButton_Click);
			// 
			// FileTypesLabel
			// 
			this.FileTypesLabel.AutoSize = true;
			this.FileTypesLabel.Location = new System.Drawing.Point(6, 3);
			this.FileTypesLabel.Name = "FileTypesLabel";
			this.FileTypesLabel.Size = new System.Drawing.Size(195, 13);
			this.FileTypesLabel.TabIndex = 0;
			this.FileTypesLabel.Text = "Открывать файлы следующих типов:";
			// 
			// RecentFileCountLabel
			// 
			this.RecentFileCountLabel.Location = new System.Drawing.Point(6, 55);
			this.RecentFileCountLabel.Name = "RecentFileCountLabel";
			this.RecentFileCountLabel.Size = new System.Drawing.Size(197, 31);
			this.RecentFileCountLabel.TabIndex = 6;
			this.RecentFileCountLabel.Text = "Количество запоминаемых недавно открытых файлов:";
			// 
			// RecentFileCountUpDown
			// 
			this.RecentFileCountUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.RecentFileCountUpDown.Location = new System.Drawing.Point(245, 60);
			this.RecentFileCountUpDown.Name = "RecentFileCountUpDown";
			this.RecentFileCountUpDown.Size = new System.Drawing.Size(120, 20);
			this.RecentFileCountUpDown.TabIndex = 7;
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelationButton;
			this.ClientSize = new System.Drawing.Size(384, 212);
			this.Controls.Add(this.SettingsTabControl);
			this.Controls.Add(this.CancelationButton);
			this.Controls.Add(this.OkButton);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 250);
			this.Name = "SettingsForm";
			this.Text = "Настройки";
			((System.ComponentModel.ISupportInitialize)(this.MaxAbsoluteScalePowerUpDown)).EndInit();
			this.SettingsTabControl.ResumeLayout(false);
			this.GeneralTabPage.ResumeLayout(false);
			this.GeneralTabPage.PerformLayout();
			this.IntegrationTabPage.ResumeLayout(false);
			this.IntegrationTabPage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.RecentFileCountUpDown)).EndInit();
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
		private System.Windows.Forms.NumericUpDown RecentFileCountUpDown;
		private System.Windows.Forms.Label RecentFileCountLabel;
	}
}