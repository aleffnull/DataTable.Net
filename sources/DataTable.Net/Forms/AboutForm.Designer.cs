namespace DataTable.Net.Forms
{
	partial class AboutForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
			this.label1 = new System.Windows.Forms.Label();
			this.OkButton = new System.Windows.Forms.Button();
			this.VersionTextBox = new System.Windows.Forms.TextBox();
			this.CopyInfoDataButton = new System.Windows.Forms.Button();
			this.AuthorLabel = new System.Windows.Forms.Label();
			this.OrganizationLabel = new System.Windows.Forms.Label();
			this.DepartmentLabel = new System.Windows.Forms.Label();
			this.YearLabel = new System.Windows.Forms.Label();
			this.MailLinkLabel = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// OkButton
			// 
			resources.ApplyResources(this.OkButton, "OkButton");
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.OkButton.Name = "OkButton";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// VersionTextBox
			// 
			resources.ApplyResources(this.VersionTextBox, "VersionTextBox");
			this.VersionTextBox.Name = "VersionTextBox";
			this.VersionTextBox.ReadOnly = true;
			// 
			// CopyInfoDataButton
			// 
			resources.ApplyResources(this.CopyInfoDataButton, "CopyInfoDataButton");
			this.CopyInfoDataButton.Name = "CopyInfoDataButton";
			this.CopyInfoDataButton.UseVisualStyleBackColor = true;
			this.CopyInfoDataButton.Click += new System.EventHandler(this.CopyInfoDataButton_Click);
			// 
			// AuthorLabel
			// 
			resources.ApplyResources(this.AuthorLabel, "AuthorLabel");
			this.AuthorLabel.Name = "AuthorLabel";
			// 
			// OrganizationLabel
			// 
			resources.ApplyResources(this.OrganizationLabel, "OrganizationLabel");
			this.OrganizationLabel.Name = "OrganizationLabel";
			// 
			// DepartmentLabel
			// 
			resources.ApplyResources(this.DepartmentLabel, "DepartmentLabel");
			this.DepartmentLabel.Name = "DepartmentLabel";
			// 
			// YearLabel
			// 
			resources.ApplyResources(this.YearLabel, "YearLabel");
			this.YearLabel.Name = "YearLabel";
			// 
			// MailLinkLabel
			// 
			resources.ApplyResources(this.MailLinkLabel, "MailLinkLabel");
			this.MailLinkLabel.Name = "MailLinkLabel";
			this.MailLinkLabel.TabStop = true;
			this.MailLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MailLinkLabel_LinkClicked);
			// 
			// AboutForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.OkButton;
			this.Controls.Add(this.MailLinkLabel);
			this.Controls.Add(this.YearLabel);
			this.Controls.Add(this.DepartmentLabel);
			this.Controls.Add(this.OrganizationLabel);
			this.Controls.Add(this.AuthorLabel);
			this.Controls.Add(this.CopyInfoDataButton);
			this.Controls.Add(this.VersionTextBox);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.Load += new System.EventHandler(this.AboutForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.TextBox VersionTextBox;
		private System.Windows.Forms.Button CopyInfoDataButton;
		private System.Windows.Forms.Label AuthorLabel;
		private System.Windows.Forms.Label OrganizationLabel;
		private System.Windows.Forms.Label DepartmentLabel;
		private System.Windows.Forms.Label YearLabel;
		private System.Windows.Forms.LinkLabel MailLinkLabel;
	}
}