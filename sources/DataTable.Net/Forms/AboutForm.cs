using System;
using System.Windows.Forms;
using DataTable.Net.Presenters;
using DataTable.Net.Presenters.Impl;
using DataTable.Net.Views;

namespace DataTable.Net.Forms
{
	public partial class AboutForm : Form, IAboutView
	{
		#region Fields

		private readonly IAboutPresenter presenter;

		#endregion Fields

		#region Constructors

		public AboutForm()
		{
			InitializeComponent();
			presenter = new AboutPresenter(this);
		}

		#endregion Constructors

		#region IAboutView implemenation

		string IAboutView.VersionInfo
		{
			get { return VersionTextBox.Text; }
			set { VersionTextBox.Text = value; }
		}

		void IAboutView.SetMailLink(string link)
		{
			MailLinkLabel.Links[0].LinkData = link;
		}

		void IAboutView.SetMailLinkVisited()
		{
			MailLinkLabel.LinkVisited = true;
		}

		#endregion IAboutView implemenation

		#region Event handlers

		private void AboutForm_Load(object sender, EventArgs e)
		{
			presenter.OnLoad();
		}

		private void CopyInfoDataButton_Click(object sender, EventArgs e)
		{
			presenter.OnCopyVersionInfo();
		}

		#endregion Event handlers

		private void MailLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			presenter.OnMailLinkClicked(e.Link.LinkData as string);
		}
	}
}
