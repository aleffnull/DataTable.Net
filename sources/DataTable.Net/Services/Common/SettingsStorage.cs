using DataTable.Net.Properties;

namespace DataTable.Net.Services.Common
{
	public class SettingsStorage
	{
		#region Properties

		public int MaxAbsoluteScalePower { get; private set; }
		public string ExportValuesSeparator { get; private set; }

		#endregion Properties

		#region Constructors

		public SettingsStorage(int maxAbsoluteScalePower, string exportValuesSeparator)
		{
			MaxAbsoluteScalePower = maxAbsoluteScalePower;
			ExportValuesSeparator = exportValuesSeparator;
		}

		#endregion Constructors

		#region Object overrides

		public override string ToString()
		{
			return string.Format(
				InternalResources.SettingsStorageToStringFormat,
				MaxAbsoluteScalePower, ExportValuesSeparator);
		}

		#endregion Object overrides
	}
}