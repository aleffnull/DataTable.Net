using DataTable.Net.Services.Common;
using DataTable.Net.Services.Settings;

namespace DataTable.Net.Services
{
	public interface ISettingsService
	{
		SettingsStorage LoadSettings();
		void BeginSavingSettings(
			SettingsStorage settings, ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback);
	}
}