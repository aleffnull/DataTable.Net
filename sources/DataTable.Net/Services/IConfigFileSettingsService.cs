using DataTable.Net.Services.Common;
using DataTable.Net.Services.Settings;

namespace DataTable.Net.Services
{
	public interface IConfigFileSettingsService
	{
		ConfigFileSettings LoadSettings();
		void BeginSavingSettings(
			ConfigFileSettings settings, ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback);
	}
}