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
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(86, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "DataTable.Net";
			// 
			// OkButton
			// 
			this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.OkButton.Location = new System.Drawing.Point(217, 227);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(75, 23);
			this.OkButton.TabIndex = 1;
			this.OkButton.Text = "&OK";
			this.OkButton.UseVisualStyleBackColor = true;
			// 
			// VersionTextBox
			// 
			this.VersionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.VersionTextBox.Location = new System.Drawing.Point(15, 90);
			this.VersionTextBox.Multiline = true;
			this.VersionTextBox.Name = "VersionTextBox";
			this.VersionTextBox.ReadOnly = true;
			this.VersionTextBox.Size = new System.Drawing.Size(279, 131);
			this.VersionTextBox.TabIndex = 2;
			// 
			// CopyInfoDataButton
			// 
			this.CopyInfoDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.CopyInfoDataButton.Location = new System.Drawing.Point(118, 227);
			this.CopyInfoDataButton.Name = "CopyInfoDataButton";
			this.CopyInfoDataButton.Size = new System.Drawing.Size(93, 23);
			this.CopyInfoDataButton.TabIndex = 3;
			this.CopyInfoDataButton.Text = "Скопировать";
			this.CopyInfoDataButton.UseVisualStyleBackColor = true;
			this.CopyInfoDataButton.Click += new System.EventHandler(this.CopyInfoDataButton_Click);
			// 
			// AuthorLabel
			// 
			this.AuthorLabel.AutoSize = true;
			this.AuthorLabel.Location = new System.Drawing.Point(12, 22);
			this.AuthorLabel.Name = "AuthorLabel";
			this.AuthorLabel.Size = new System.Drawing.Size(170, 13);
			this.AuthorLabel.TabIndex = 4;
			this.AuthorLabel.Text = "Михаил Константинович Савкин";
			// 
			// OrganizationLabel
			// 
			this.OrganizationLabel.AutoSize = true;
			this.OrganizationLabel.Location = new System.Drawing.Point(12, 35);
			this.OrganizationLabel.Name = "OrganizationLabel";
			this.OrganizationLabel.Size = new System.Drawing.Size(228, 13);
			this.OrganizationLabel.TabIndex = 5;
			this.OrganizationLabel.Text = "Калужский филиал МГТУ им. Н.Э. Баумана";
			// 
			// DepartmentLabel
			// 
			this.DepartmentLabel.AutoSize = true;
			this.DepartmentLabel.Location = new System.Drawing.Point(12, 48);
			this.DepartmentLabel.Name = "DepartmentLabel";
			this.DepartmentLabel.Size = new System.Drawing.Size(279, 13);
			this.DepartmentLabel.TabIndex = 6;
			this.DepartmentLabel.Text = "Кафеда \"Компьютерные системы и сети\" (ЭИУ2-КФ)";
			// 
			// YearLabel
			// 
			this.YearLabel.AutoSize = true;
			this.YearLabel.Location = new System.Drawing.Point(12, 61);
			this.YearLabel.Name = "YearLabel";
			this.YearLabel.Size = new System.Drawing.Size(42, 13);
			this.YearLabel.TabIndex = 7;
			this.YearLabel.Text = "2011 г.";
			// 
			// MailLinkLabel
			// 
			this.MailLinkLabel.AutoSize = true;
			this.MailLinkLabel.Location = new System.Drawing.Point(12, 74);
			this.MailLinkLabel.Name = "MailLinkLabel";
			this.MailLinkLabel.Size = new System.Drawing.Size(153, 13);
			this.MailLinkLabel.TabIndex = 8;
			this.MailLinkLabel.TabStop = true;
			this.MailLinkLabel.Text = "datatable.net@blackbox82.org";
			this.MailLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MailLinkLabel_LinkClicked);
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.OkButton;
			this.ClientSize = new System.Drawing.Size(304, 262);
			this.Controls.Add(this.MailLinkLabel);
			this.Controls.Add(this.YearLabel);
			this.Controls.Add(this.DepartmentLabel);
			this.Controls.Add(this.OrganizationLabel);
			this.Controls.Add(this.AuthorLabel);
			this.Controls.Add(this.CopyInfoDataButton);
			this.Controls.Add(this.VersionTextBox);
			this.Controls.Add(this.OkButton);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(320, 300);
			this.Name = "AboutForm";
			this.Text = "О программе";
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