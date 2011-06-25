using DataTable.Net.Properties;
using DataTable.Net.Services.Common;

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
			ServiceSuccessCallback<SettingsStorage> successCallback, ServiceErrorCallback errorCallback)
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

		private static SettingsStorage SaveSettings(SettingsStorage oldSettings, SettingsStorage newSettings)
		{
			SaveConfigFileSettings(newSettings);
			return newSettings;
		}

		#endregion ServiceActions

		#region Helpers

		private static void LoadConfigFileSettings(SettingsStorage settings)
		{
			settings.MaxAbsoluteScalePower = Settings.Default.MaxAbsoluteScalePower;
			settings.ExportValuesSeparator = Settings.Default.ExportValuesSeparator;
		}

		private static void SaveConfigFileSettings(SettingsStorage settings)
		{
			Settings.Default.MaxAbsoluteScalePower = settings.MaxAbsoluteScalePower;
			Settings.Default.ExportValuesSeparator = settings.ExportValuesSeparator;
			Settings.Default.Save();
		}

		#endregion Helpers
	}
}