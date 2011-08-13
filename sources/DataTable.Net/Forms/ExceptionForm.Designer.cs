// Copyright (C) 2005 - 2007 American College of Radiology
//

namespace DataTable.Net.Forms
{
	sealed partial class ExceptionForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExceptionForm));
			this.okButton = new System.Windows.Forms.Button();
			this.errorPictureBox = new System.Windows.Forms.PictureBox();
			this.exceptionTextBox = new System.Windows.Forms.TextBox();
			this.MessageLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// okButton
			// 
			resources.ApplyResources(this.okButton, "okButton");
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Name = "okButton";
			this.okButton.UseVisualStyleBackColor = true;
			// 
			// errorPictureBox
			// 
			resources.ApplyResources(this.errorPictureBox, "errorPictureBox");
			this.errorPictureBox.Name = "errorPictureBox";
			this.errorPictureBox.TabStop = false;
			// 
			// exceptionTextBox
			// 
			resources.ApplyResources(this.exceptionTextBox, "exceptionTextBox");
			this.exceptionTextBox.Name = "exceptionTextBox";
			this.exceptionTextBox.ReadOnly = true;
			// 
			// MessageLabel
			// 
			resources.ApplyResources(this.MessageLabel, "MessageLabel");
			this.MessageLabel.Name = "MessageLabel";
			// 
			// ExceptionForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MessageLabel);
			this.Controls.Add(this.exceptionTextBox);
			this.Controls.Add(this.errorPictureBox);
			this.Controls.Add(this.okButton);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ExceptionForm";
			this.ShowIcon = false;
			((System.ComponentModel.ISupportInitialize)(this.errorPictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.PictureBox errorPictureBox;
		private System.Windows.Forms.TextBox exceptionTextBox;
		private System.Windows.Forms.Label MessageLabel;
	}
}