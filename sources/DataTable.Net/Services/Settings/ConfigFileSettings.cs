using DataTable.Net.Properties;

namespace DataTable.Net.Services.Settings
{
	public class ConfigFileSettings
	{
		#region Properties

		public int MaxAbsoluteScalePower { get; private set; }
		public string ExportValuesSeparator { get; private set; }

		#endregion Properties

		#region Constructors

		public ConfigFileSettings(int maxAbsoluteScalePower, string exportValuesSeparator)
		{
			MaxAbsoluteScalePower = maxAbsoluteScalePower;
			ExportValuesSeparator = exportValuesSeparator;
		}

		#endregion Constructors

		#region Object overrides

		public override string ToString()
		{
			return string.Format(
				InternalResources.ConfigFileSettingsToStringFormat,
				MaxAbsoluteScalePower, ExportValuesSeparator);
		}

		#endregion Object overrides
	}
}