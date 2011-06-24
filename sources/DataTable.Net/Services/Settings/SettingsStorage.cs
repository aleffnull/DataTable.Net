using DataTable.Net.Properties;

namespace DataTable.Net.Services.Settings
{
	public class SettingsStorage
	{
		#region Properties

		public int MaxAbsoluteScalePower { get; set; }
		public string ExportValuesSeparator { get; set; }

		public ConfigFileSettings ConfigFileSettings { get; private set; }
		public RegistrySettings RegistrySettings { get; private set; }

		#endregion Properties

		#region Constructors

		//public SettingsStorage(ConfigFileSettings configFileSettings, RegistrySettings registrySettings)
		//{
		//  ConfigFileSettings = configFileSettings;
		//  RegistrySettings = registrySettings;
		//}

		#endregion Constructors

		#region Object overrides

		public override string ToString()
		{
			return string.Format(InternalResources.SettingsStorageToStringFormat, ConfigFileSettings, RegistrySettings);
		}

		#endregion Object overrides
	}
}