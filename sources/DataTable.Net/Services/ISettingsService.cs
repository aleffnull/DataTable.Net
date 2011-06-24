using DataTable.Net.Services.Common;
using DataTable.Net.Services.Settings;

namespace DataTable.Net.Services
{
	public interface ISettingsService
	{
		void BeginLoadingSettings(
			ServiceSuccessCallback<SettingsStorage> successCallback, ServiceErrorCallback errorCallback);

		void BeginSavingSettings(
			SettingsStorage oldSettings, SettingsStorage newSettings,
			ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback);
	}
}