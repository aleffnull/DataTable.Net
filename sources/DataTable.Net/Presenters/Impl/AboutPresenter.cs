using System;
using System.Diagnostics;
using System.Windows.Forms;
using DataTable.Net.Properties;
using DataTable.Net.Views;

namespace DataTable.Net.Presenters.Impl
{
	public class AboutPresenter : IAboutPresenter
	{
		#region Fields

		private readonly IAboutView view;

		#endregion Fields

		#region Constructors

		public AboutPresenter(IAboutView view)
		{
			this.view = view;
		}

		#endregion Constructors

		#region IAboutPresenter implementation

		public void OnLoad()
		{
			var versionInfo = string.Format(
				Resources.VersionInfoFormat,
				Environment.NewLine, ProgramInfo.Version, ProgramInfo.BuildDate);
			view.VersionInfo = versionInfo;
			view.SetMailLink(InternalResources.ContactEmailLink);
		}

		public void OnMailLinkClicked(string mailLink)
		{
			view.SetMailLinkVisited();
			Process.Start(mailLink);
		}

		public void OnCopyVersionInfo()
		{
			Clipboard.SetText(view.VersionInfo);
		}

		#endregion IAboutPresenter implementation
	}
}