using System.Collections.Generic;
using DataTable.Net.Services.Common;
using DataTable.Net.Services.Settings;
using ApplicationSettings = DataTable.Net.Properties.Settings;

namespace DataTable.Net.Services.Impl
{
	public class SettingsService : AbstractAsyncService, ISettingsService
	{
		#region ISettingsService implementation

		public SettingsStorage LoadSettings()
		{
			var configFileSettings = new ConfigFileSettings(
				ApplicationSettings.Default.MaxAbsoluteScalePower, ApplicationSettings.Default.ExportValuesSeparator);
			var registrySettings = new RegistrySettings(new List<string>());
			var settings = new SettingsStorage(configFileSettings, registrySettings);

			return settings;
		}

		public void BeginSavingSettings(
			SettingsStorage settings, ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback)
		{
			DoRequest(() => SaveSettings(settings), successCallback, errorCallback);
		}

		#endregion ISettingsService implementation

		#region Service actions

		private static void SaveSettings(SettingsStorage settings)
		{
			ApplicationSettings.Default.MaxAbsoluteScalePower = settings.MaxAbsoluteScalePower;
			ApplicationSettings.Default.ExportValuesSeparator = settings.ExportValuesSeparator;
			ApplicationSettings.Default.Save();
		}

		#endregion ServiceActions
	}
}