using DataTable.Net.Services.Common;

namespace DataTable.Net.Services
{
	public interface ISettingsService
	{
		void BeginLoadingSettings(
			ServiceSuccessCallback<SettingsStorage> successCallback, ServiceErrorCallback errorCallback);

		void BeginSavingSettings(
			SettingsStorage oldSettings, SettingsStorage newSettings,
			ServiceSuccessCallback<SettingsStorage> successCallback, ServiceErrorCallback errorCallback);
	}
}