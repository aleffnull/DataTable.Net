using System.Collections.Generic;
using DataTable.Net.Properties;

namespace DataTable.Net.Services.Settings
{
	public class RegistrySettings
	{
		#region Properties

		public IEnumerable<string> RegisteredExtensions { get; private set; }

		#endregion Properties

		#region Constructors

		public RegistrySettings(IEnumerable<string> registeredExtensions)
		{
			RegisteredExtensions = registeredExtensions;
		}

		#endregion Constructors

		#region Object overrides

		public override string ToString()
		{
			var extensionsString = string.Join(
				InternalResources.ExtensionsSeparator, new List<string>(RegisteredExtensions).ToArray());
			if (string.IsNullOrEmpty(extensionsString))
			{
				extensionsString = InternalResources.RegistrySettingsNoExtensions;
			}

			return string.Format(InternalResources.RegistrySettingsToStringFormat, extensionsString);
		}

		#endregion Object overrides
	}
}