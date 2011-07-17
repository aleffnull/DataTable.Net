using DataTable.Net.Services.Common;

namespace DataTable.Net.Services
{
	public interface ISettingsService
	{
		SettingsStorage CurrentSettings { get; }

		void LoadSettings();
		void SaveSettings(SettingsStorage newSettings);
	}
}