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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataPropertiesForm));
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
			resources.ApplyResources(this.NumberOfArgumentsLabel, "NumberOfArgumentsLabel");
			this.NumberOfArgumentsLabel.Name = "NumberOfArgumentsLabel";
			// 
			// NumberOfArgumentsComboBox
			// 
			resources.ApplyResources(this.NumberOfArgumentsComboBox, "NumberOfArgumentsComboBox");
			this.NumberOfArgumentsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.NumberOfArgumentsComboBox.FormattingEnabled = true;
			this.NumberOfArgumentsComboBox.Name = "NumberOfArgumentsComboBox";
			// 
			// NumberOfFunctionsLabel
			// 
			resources.ApplyResources(this.NumberOfFunctionsLabel, "NumberOfFunctionsLabel");
			this.NumberOfFunctionsLabel.Name = "NumberOfFunctionsLabel";
			// 
			// NumberOfFuntionsComboBox
			// 
			resources.ApplyResources(this.NumberOfFuntionsComboBox, "NumberOfFuntionsComboBox");
			this.NumberOfFuntionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.NumberOfFuntionsComboBox.FormattingEnabled = true;
			this.NumberOfFuntionsComboBox.Name = "NumberOfFuntionsComboBox";
			// 
			// ArgumentsTypeLabel
			// 
			resources.ApplyResources(this.ArgumentsTypeLabel, "ArgumentsTypeLabel");
			this.ArgumentsTypeLabel.Name = "ArgumentsTypeLabel";
			// 
			// ArgumentsTypeComboBox
			// 
			resources.ApplyResources(this.ArgumentsTypeComboBox, "ArgumentsTypeComboBox");
			this.ArgumentsTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ArgumentsTypeComboBox.FormattingEnabled = true;
			this.ArgumentsTypeComboBox.Name = "ArgumentsTypeComboBox";
			// 
			// FunctionsTypeLabel
			// 
			resources.ApplyResources(this.FunctionsTypeLabel, "FunctionsTypeLabel");
			this.FunctionsTypeLabel.Name = "FunctionsTypeLabel";
			// 
			// FunctionsTypeComboBox
			// 
			resources.ApplyResources(this.FunctionsTypeComboBox, "FunctionsTypeComboBox");
			this.FunctionsTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.FunctionsTypeComboBox.FormattingEnabled = true;
			this.FunctionsTypeComboBox.Name = "FunctionsTypeComboBox";
			// 
			// OkButton
			// 
			resources.ApplyResources(this.OkButton, "OkButton");
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Name = "OkButton";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// CancellationButton
			// 
			resources.ApplyResources(this.CancellationButton, "CancellationButton");
			this.CancellationButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancellationButton.Name = "CancellationButton";
			this.CancellationButton.UseVisualStyleBackColor = true;
			// 
			// ArithmeticTypeComboBox
			// 
			resources.ApplyResources(this.ArithmeticTypeComboBox, "ArithmeticTypeComboBox");
			this.ArithmeticTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ArithmeticTypeComboBox.FormattingEnabled = true;
			this.ArithmeticTypeComboBox.Name = "ArithmeticTypeComboBox";
			// 
			// ArithmeticTypeLabel
			// 
			resources.ApplyResources(this.ArithmeticTypeLabel, "ArithmeticTypeLabel");
			this.ArithmeticTypeLabel.Name = "ArithmeticTypeLabel";
			// 
			// DataPropertiesForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.CancellationButton;
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