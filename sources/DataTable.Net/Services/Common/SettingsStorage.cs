using System.Collections.Generic;
using DataTable.Net.Models;
using DataTable.Net.Properties;

namespace DataTable.Net.Services.Common
{
	public class SettingsStorage
	{
		#region Fields

		private readonly List<string> registeredExtensions = new List<string>();

		#endregion Fields

		#region Properties

		public int MaxAbsoluteScalePower { get; set; }
		public string ExportValuesSeparator { get; set; }
		public int RecentFilesCount { get; set; }
		public Language Language { get; set; }

		public IEnumerable<string> RegisteredExtensions
		{
			get { return registeredExtensions; }
		}

		#endregion Properties

		#region Constructors

		public SettingsStorage()
		{
			//
		}

		public SettingsStorage(
			int maxAbsoluteScalePower, string exportValuesSeparator, int recentFilesCount,
			IEnumerable<string> registeredExtensions, Language language)
		{
			MaxAbsoluteScalePower = maxAbsoluteScalePower;
			ExportValuesSeparator = exportValuesSeparator;
			RecentFilesCount = recentFilesCount;
			Language = language;
			this.registeredExtensions.AddRange(registeredExtensions);
		}

		#endregion Constructors

		#region Methods

		public void AddRegisteredExtension(string extension)
		{
			registeredExtensions.Add(extension);
		}

		#endregion Methods

		#region Object overrides

		public override string ToString()
		{
			return string.Format(
				InternalResources.SettingsStorageToStringFormat,
				MaxAbsoluteScalePower, ExportValuesSeparator, RecentFilesCount, GetRegisteredExtensionsString(), Language);
		}

		#endregion Object overrides

		#region Helpers

		private string GetRegisteredExtensionsString()
		{
			var extensionsString = string.Join(
				InternalResources.ExtensionsSeparator, registeredExtensions.ToArray());
			if (string.IsNullOrEmpty(extensionsString))
			{
				extensionsString = InternalResources.RegistrySettingsNoExtensions;
			}

			return extensionsString;
		}

		#endregion Helpers
	}
}