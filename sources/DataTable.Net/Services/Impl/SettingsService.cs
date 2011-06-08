using DataTable.Net.Properties;
using DataTable.Net.Services.Common;

namespace DataTable.Net.Services.Impl
{
	public class SettingsService : ISettingsService
	{
		#region ISettingsService implementation

		public SettingsStorage LoadSettings()
		{
			var settings = new SettingsStorage(
				Settings.Default.MaxAbsoluteScalePower, Settings.Default.ExportValuesSeparator);
			return settings;
		}

		public void SaveSettings(SettingsStorage settings)
		{
			Settings.Default.MaxAbsoluteScalePower = settings.MaxAbsoluteScalePower;
			Settings.Default.ExportValuesSeparator = settings.ExportValuesSeparator;
			Settings.Default.Save();
		}

		#endregion ISettingsService implementation
	}
}