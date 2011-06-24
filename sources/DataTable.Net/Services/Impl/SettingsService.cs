using DataTable.Net.Services.Common;
using DataTable.Net.Services.Settings;
using ApplicationSettings = DataTable.Net.Properties.Settings;

namespace DataTable.Net.Services.Impl
{
	public class SettingsService : AbstractAsyncService, ISettingsService
	{
		#region ISettingsService implementation

		public void BeginLoadingSettings(
			ServiceSuccessCallback<SettingsStorage> successCallback, ServiceErrorCallback errorCallback)
		{
			DoRequest(LoadSettings, successCallback, errorCallback);
		}

		public void BeginSavingSettings(
			SettingsStorage oldSettings, SettingsStorage newSettings,
			ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback)
		{
			DoRequest(() => SaveSettings(oldSettings, newSettings), successCallback, errorCallback);
		}

		#endregion ISettingsService implementation

		#region Service actions

		private static SettingsStorage LoadSettings()
		{
			var settings = new SettingsStorage();
			LoadConfigFileSettings(settings);

			return settings;
		}

		private static void SaveSettings(SettingsStorage oldSettings, SettingsStorage newSettings)
		{
			SaveConfigFileSettings(newSettings);
		}

		#endregion ServiceActions

		#region Helpers

		private static void LoadConfigFileSettings(SettingsStorage settings)
		{
			settings.MaxAbsoluteScalePower = ApplicationSettings.Default.MaxAbsoluteScalePower;
			settings.ExportValuesSeparator = ApplicationSettings.Default.ExportValuesSeparator;
		}

		private static void SaveConfigFileSettings(SettingsStorage settings)
		{
			ApplicationSettings.Default.MaxAbsoluteScalePower = settings.MaxAbsoluteScalePower;
			ApplicationSettings.Default.ExportValuesSeparator = settings.ExportValuesSeparator;
			ApplicationSettings.Default.Save();
		}

		#endregion Helpers
	}
}