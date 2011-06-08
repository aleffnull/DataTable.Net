using DataTable.Net.Services.Common;

namespace DataTable.Net.Services
{
	public interface ISettingsService
	{
		SettingsStorage LoadSettings();
		void SaveSettings(SettingsStorage settings);
	}
}