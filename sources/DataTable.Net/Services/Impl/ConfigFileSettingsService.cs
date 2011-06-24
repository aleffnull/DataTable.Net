using DataTable.Net.Services.Common;
using DataTable.Net.Services.Settings;
using ApplicationSettings = DataTable.Net.Properties.Settings;

namespace DataTable.Net.Services.Impl
{
	public class ConfigFileSettingsService : AbstractAsyncService, IConfigFileSettingsService
	{
		#region IConfigFileSettingsService implementation

		public ConfigFileSettings LoadSettings()
		{
			return new ConfigFileSettings(
				ApplicationSettings.Default.MaxAbsoluteScalePower, ApplicationSettings.Default.ExportValuesSeparator);
		}

		public void BeginSavingSettings(
			ConfigFileSettings settings, ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback)
		{
			DoRequest(() => SaveSettings(settings), successCallback, errorCallback);
		}

		#endregion IConfigFileSettingsService implementation

		#region Service actions

		private static void SaveSettings(ConfigFileSettings settings)
		{
			ApplicationSettings.Default.MaxAbsoluteScalePower = settings.MaxAbsoluteScalePower;
			ApplicationSettings.Default.ExportValuesSeparator = settings.ExportValuesSeparator;
			ApplicationSettings.Default.Save();
		}

		#endregion ServiceActions
	}
}