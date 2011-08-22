using DataTable.Net.Dtos;
using DataTable.Net.Services.Common;
using DataTable.Net.Views;

namespace DataTable.Net.Presenters.Impl
{
	internal class SettingsPresenter : ISettingsPresenter
	{
		#region Fields

		private readonly ISettingsView view;
		private readonly SettingsDto settingsToLoad;

		#endregion Fields

		#region Constructors

		public SettingsPresenter(ISettingsView view, SettingsDto settingsToLoad)
		{
			this.view = view;
			this.settingsToLoad = settingsToLoad;
		}

		#endregion Constructors

		#region ISettingsPresenter implementation

		public void OnLoad()
		{
			InitPredefinedData();
			LoadSettings(settingsToLoad);
		}

		public SettingsDto GetSettings()
		{
			return new SettingsDto(
				view.MaxAbsoluteScalePower, view.ExportValuesSeparator,
				view.RecentFilesCount, view.GetSelectedExtensions());
		}

		public void OnSelectAllExtensions()
		{
			view.SelectAllExtensions();
		}

		#endregion ISettingsPresenter implementation

		#region Helpers

		private void InitPredefinedData()
		{
			foreach (var extension in PredefinedData.SupportedExtensions)
			{
				view.AddExtension(extension);
			}
		}

		private void LoadSettings(SettingsDto settings)
		{
			view.MaxAbsoluteScalePower = settings.MaxAbsoluteScalePower;
			view.ExportValuesSeparator = settings.ExportValuesSeparator;
			view.RecentFilesCount = settings.RecentFilesCount;

			foreach (var extension in settings.RegisteredExtensions)
			{
				view.ToogleExtension(extension, true);
			}
		}

		#endregion Helpers
	}
}