using System.Collections.Generic;

namespace DataTable.Net.Dtos
{
	public class SettingsDto
	{
		#region Properties

		public int MaxAbsoluteScalePower { get; private set; }
		public string ExportValuesSeparator { get; private set; }
		public IEnumerable<string> RegisteredExtensions { get; private set; }

		#endregion Properties

		#region Constructors

		public SettingsDto(
			int maxAbsoluteScalePower, string exportValuesSeparator, IEnumerable<string> registeredExtensions)
		{
			MaxAbsoluteScalePower = maxAbsoluteScalePower;
			ExportValuesSeparator = exportValuesSeparator;
			RegisteredExtensions = registeredExtensions;
		}

		#endregion Constructors
	}
}