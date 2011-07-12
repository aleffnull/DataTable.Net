using DataTable.Net.Services.Common;

namespace DataTable.Net.Services
{
	public interface ISettingsService
	{
		SettingsStorage LoadSettings();
		SettingsStorage SaveSettings(SettingsStorage oldSettings, SettingsStorage newSettings);
	}
}