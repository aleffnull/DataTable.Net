namespace DataTable.Net.Forms
{
	partial class DataPropertiesForm
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
			this.NumberOfArgumentsLabel = new System.Windows.Forms.Label();
			this.NumberOfArgumentsComboBox = new System.Windows.Forms.ComboBox();
			this.NumberOfFunctionsLabel = new System.Windows.Forms.Label();
			this.NumberOfFuntionsComboBox = new System.Windows.Forms.ComboBox();
			this.ArgumentsTypeLabel = new System.Windows.Forms.Label();
			this.ArgumentsTypeComboBox = new System.Windows.Forms.ComboBox();
			this.FunctionsTypeLabel = new System.Windows.Forms.Label();
			this.FunctionsTypeComboBox = new System.Windows.Forms.ComboBox();
			this.OkButton = new System.Windows.Forms.Button();
			this.CancellationButton = new System.Windows.Forms.Button();
			this.ArithmeticTypeComboBox = new System.Windows.Forms.ComboBox();
			this.ArithmeticTypeLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// NumberOfArgumentsLabel
			// 
			this.NumberOfArgumentsLabel.AutoSize = true;
			this.NumberOfArgumentsLabel.Location = new System.Drawing.Point(12, 9);
			this.NumberOfArgumentsLabel.Name = "NumberOfArgumentsLabel";
			this.NumberOfArgumentsLabel.Size = new System.Drawing.Size(177, 13);
			this.NumberOfArgumentsLabel.TabIndex = 0;
			this.NumberOfArgumentsLabel.Text = "Количество аргументов функций:";
			// 
			// NumberOfArgumentsComboBox
			// 
			this.NumberOfArgumentsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.NumberOfArgumentsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.NumberOfArgumentsComboBox.FormattingEnabled = true;
			this.NumberOfArgumentsComboBox.Location = new System.Drawing.Point(195, 6);
			this.NumberOfArgumentsComboBox.Name = "NumberOfArgumentsComboBox";
			this.NumberOfArgumentsComboBox.Size = new System.Drawing.Size(152, 21);
			this.NumberOfArgumentsComboBox.TabIndex = 1;
			// 
			// NumberOfFunctionsLabel
			// 
			this.NumberOfFunctionsLabel.AutoSize = true;
			this.NumberOfFunctionsLabel.Location = new System.Drawing.Point(12, 36);
			this.NumberOfFunctionsLabel.Name = "NumberOfFunctionsLabel";
			this.NumberOfFunctionsLabel.Size = new System.Drawing.Size(115, 13);
			this.NumberOfFunctionsLabel.TabIndex = 2;
			this.NumberOfFunctionsLabel.Text = "Количество функций:";
			// 
			// NumberOfFuntionsComboBox
			// 
			this.NumberOfFuntionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.NumberOfFuntionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.NumberOfFuntionsComboBox.FormattingEnabled = true;
			this.NumberOfFuntionsComboBox.Location = new System.Drawing.Point(195, 33);
			this.NumberOfFuntionsComboBox.Name = "NumberOfFuntionsComboBox";
			this.NumberOfFuntionsComboBox.Size = new System.Drawing.Size(152, 21);
			this.NumberOfFuntionsComboBox.TabIndex = 3;
			// 
			// ArgumentsTypeLabel
			// 
			this.ArgumentsTypeLabel.AutoSize = true;
			this.ArgumentsTypeLabel.Location = new System.Drawing.Point(12, 64);
			this.ArgumentsTypeLabel.Name = "ArgumentsTypeLabel";
			this.ArgumentsTypeLabel.Size = new System.Drawing.Size(141, 13);
			this.ArgumentsTypeLabel.TabIndex = 4;
			this.ArgumentsTypeLabel.Text = "Тип значений аргументов:";
			// 
			// ArgumentsTypeComboBox
			// 
			this.ArgumentsTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.ArgumentsTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ArgumentsTypeComboBox.FormattingEnabled = true;
			this.ArgumentsTypeComboBox.Location = new System.Drawing.Point(195, 61);
			this.ArgumentsTypeComboBox.Name = "ArgumentsTypeComboBox";
			this.ArgumentsTypeComboBox.Size = new System.Drawing.Size(152, 21);
			this.ArgumentsTypeComboBox.TabIndex = 5;
			// 
			// FunctionsTypeLabel
			// 
			this.FunctionsTypeLabel.AutoSize = true;
			this.FunctionsTypeLabel.Location = new System.Drawing.Point(12, 92);
			this.FunctionsTypeLabel.Name = "FunctionsTypeLabel";
			this.FunctionsTypeLabel.Size = new System.Drawing.Size(125, 13);
			this.FunctionsTypeLabel.TabIndex = 6;
			this.FunctionsTypeLabel.Text = "Тип значений функций:";
			// 
			// FunctionsTypeComboBox
			// 
			this.FunctionsTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.FunctionsTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FunctionsTypeComboBox.FormattingEnabled = true;
			this.FunctionsTypeComboBox.Location = new System.Drawing.Point(195, 89);
			this.FunctionsTypeComboBox.Name = "FunctionsTypeComboBox";
			this.FunctionsTypeComboBox.Size = new System.Drawing.Size(152, 21);
			this.FunctionsTypeComboBox.TabIndex = 7;
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(191, 173);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 8;
			this.OkButton.Text = "&OK";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// CancellationButton
			// 
			this.CancellationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CancellationButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancellationButton.Location = new System.Drawing.Point(272, 173);
			this.CancellationButton.Name = "CancellationButton";
			this.CancellationButton.Size = new System.Drawing.Size(75, 23);
			this.CancellationButton.TabIndex = 9;
			this.CancellationButton.Text = "О&тмена";
			this.CancellationButton.UseVisualStyleBackColor = true;
			// 
			// ArithmeticTypeComboBox
			// 
			this.ArithmeticTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
									| System.Windows.Forms.AnchorStyles.Right)));
			this.ArithmeticTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ArithmeticTypeComboBox.FormattingEnabled = true;
			this.ArithmeticTypeComboBox.Location = new System.Drawing.Point(195, 116);
			this.ArithmeticTypeComboBox.Name = "ArithmeticTypeComboBox";
			this.ArithmeticTypeComboBox.Size = new System.Drawing.Size(152, 21);
			this.ArithmeticTypeComboBox.TabIndex = 10;
			// 
			// ArithmeticTypeLabel
			// 
			this.ArithmeticTypeLabel.AutoSize = true;
			this.ArithmeticTypeLabel.Location = new System.Drawing.Point(12, 119);
			this.ArithmeticTypeLabel.Name = "ArithmeticTypeLabel";
			this.ArithmeticTypeLabel.Size = new System.Drawing.Size(95, 13);
			this.ArithmeticTypeLabel.TabIndex = 11;
			this.ArithmeticTypeLabel.Text = "Тип арифметики:";
			// 
			// DataPropertiesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancellationButton;
			this.ClientSize = new System.Drawing.Size(359, 208);
			this.Controls.Add(this.ArithmeticTypeLabel);
			this.Controls.Add(this.ArithmeticTypeComboBox);
			this.Controls.Add(this.CancellationButton);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.FunctionsTypeComboBox);
			this.Controls.Add(this.FunctionsTypeLabel);
			this.Controls.Add(this.ArgumentsTypeComboBox);
			this.Controls.Add(this.ArgumentsTypeLabel);
			this.Controls.Add(this.NumberOfFuntionsComboBox);
			this.Controls.Add(this.NumberOfFunctionsLabel);
			this.Controls.Add(this.NumberOfArgumentsComboBox);
			this.Controls.Add(this.NumberOfArgumentsLabel);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DataPropertiesForm";
			this.Text = "Свойства данных";
			this.Load += new System.EventHandler(this.DataPropertiesForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label NumberOfArgumentsLabel;
		private System.Windows.Forms.ComboBox NumberOfArgumentsComboBox;
		private System.Windows.Forms.Label NumberOfFunctionsLabel;
		private System.Windows.Forms.ComboBox NumberOfFuntionsComboBox;
		private System.Windows.Forms.Label ArgumentsTypeLabel;
		private System.Windows.Forms.ComboBox ArgumentsTypeComboBox;
		private System.Windows.Forms.Label FunctionsTypeLabel;
		private System.Windows.Forms.ComboBox FunctionsTypeComboBox;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Button CancellationButton;
		private System.Windows.Forms.ComboBox ArithmeticTypeComboBox;
		private System.Windows.Forms.Label ArithmeticTypeLabel;
	}
}