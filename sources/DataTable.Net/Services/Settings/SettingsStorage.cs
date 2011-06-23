using System;
using DataTable.Net.Properties;

namespace DataTable.Net.Services.Settings
{
	public class SettingsStorage
	{
		#region Properties

		public ConfigFileSettings ConfigFileSettings { get; private set; }
		public RegistrySettings RegistrySettings { get; private set; }

		public int MaxAbsoluteScalePower
		{
			get { return ConfigFileSettings.MaxAbsoluteScalePower; }
		}

		public string ExportValuesSeparator
		{
			get { return ConfigFileSettings.ExportValuesSeparator; }
		}

		#endregion Properties

		#region Constructors

		public SettingsStorage(ConfigFileSettings configFileSettings, RegistrySettings registrySettings)
		{
			ConfigFileSettings = configFileSettings;
			RegistrySettings = registrySettings;
		}

		#endregion Constructors

		#region Object overrides

		public override string ToString()
		{
			return string.Format(InternalResources.SettingsStorageToStringFormat, ConfigFileSettings, RegistrySettings);
		}

		#endregion Object overrides
	}
}