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
			this.MaxAbsoluteScalePowerLabel = new System.Windows.Forms.Label();
			this.MaxAbsoluteScalePowerUpDown = new System.Windows.Forms.NumericUpDown();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancelationButton = new System.Windows.Forms.Button();
			this.ExportValuesSeparatorLabel = new System.Windows.Forms.Label();
			this.ExportValuesSeparatorTextBox = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.MaxAbsoluteScalePowerUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// MaxAbsoluteScalePowerLabel
			// 
			this.MaxAbsoluteScalePowerLabel.Location = new System.Drawing.Point(12, 9);
			this.MaxAbsoluteScalePowerLabel.Name = "MaxAbsoluteScalePowerLabel";
			this.MaxAbsoluteScalePowerLabel.Size = new System.Drawing.Size(185, 30);
			this.MaxAbsoluteScalePowerLabel.TabIndex = 0;
			this.MaxAbsoluteScalePowerLabel.Text = "Максимально возможный модуль показателя степени масштаба:";
			// 
			// MaxAbsoluteScalePowerUpDown
			// 
			this.MaxAbsoluteScalePowerUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.MaxAbsoluteScalePowerUpDown.Location = new System.Drawing.Point(215, 12);
			this.MaxAbsoluteScalePowerUpDown.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.MaxAbsoluteScalePowerUpDown.Name = "MaxAbsoluteScalePowerUpDown";
			this.MaxAbsoluteScalePowerUpDown.Size = new System.Drawing.Size(120, 20);
			this.MaxAbsoluteScalePowerUpDown.TabIndex = 1;
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(179, 107);
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
			this.CancelationButton.Location = new System.Drawing.Point(260, 107);
			this.CancelationButton.Name = "CancelationButton";
			this.CancelationButton.Size = new System.Drawing.Size(75, 23);
			this.CancelationButton.TabIndex = 3;
			this.CancelationButton.Text = "О&тмена";
			this.CancelationButton.UseVisualStyleBackColor = true;
			// 
			// ExportValuesSeparatorLabel
			// 
			this.ExportValuesSeparatorLabel.AutoSize = true;
			this.ExportValuesSeparatorLabel.Location = new System.Drawing.Point(12, 41);
			this.ExportValuesSeparatorLabel.Name = "ExportValuesSeparatorLabel";
			this.ExportValuesSeparatorLabel.Size = new System.Drawing.Size(197, 13);
			this.ExportValuesSeparatorLabel.TabIndex = 4;
			this.ExportValuesSeparatorLabel.Text = "Разделитель столбцов при экспорте:";
			// 
			// ExportValuesSeparatorTextBox
			// 
			this.ExportValuesSeparatorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ExportValuesSeparatorTextBox.Location = new System.Drawing.Point(215, 38);
			this.ExportValuesSeparatorTextBox.Name = "ExportValuesSeparatorTextBox";
			this.ExportValuesSeparatorTextBox.Size = new System.Drawing.Size(120, 20);
			this.ExportValuesSeparatorTextBox.TabIndex = 5;
			this.ExportValuesSeparatorTextBox.Text = ";";
			// 
			// SettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancelationButton;
			this.ClientSize = new System.Drawing.Size(344, 142);
			this.Controls.Add(this.ExportValuesSeparatorTextBox);
			this.Controls.Add(this.ExportValuesSeparatorLabel);
			this.Controls.Add(this.CancelationButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.MaxAbsoluteScalePowerUpDown);
			this.Controls.Add(this.MaxAbsoluteScalePowerLabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(360, 180);
			this.Name = "SettingsForm";
			this.Text = "Настройки";
			((System.ComponentModel.ISupportInitialize)(this.MaxAbsoluteScalePowerUpDown)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label MaxAbsoluteScalePowerLabel;
		private System.Windows.Forms.NumericUpDown MaxAbsoluteScalePowerUpDown;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CancelationButton;
		private System.Windows.Forms.Label ExportValuesSeparatorLabel;
		private System.Windows.Forms.TextBox ExportValuesSeparatorTextBox;
	}
}