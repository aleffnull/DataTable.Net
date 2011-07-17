using System.Collections.Generic;
using DataTable.Net.Properties;
using DataTable.Net.Services.Common;

namespace DataTable.Net.Services.Impl
{
	public class SettingsService : ISettingsService
	{
		#region ISettingsService implementation

		public SettingsStorage CurrentSettings { get; private set; }

		public void LoadSettings()
		{
			var settings = new SettingsStorage();
			LoadConfigFileSettings(settings);
			LoadRegistrySettings(settings);

			CurrentSettings = settings;
		}

		public void SaveSettings(SettingsStorage newSettings)
		{
			SaveConfigFileSettings(newSettings);
			SaveRegistrySettings(CurrentSettings, newSettings);

			CurrentSettings = newSettings;
		}

		#endregion ISettingsService implementation

		#region Helpers

		private static void LoadConfigFileSettings(SettingsStorage settings)
		{
			settings.MaxAbsoluteScalePower = Settings.Default.MaxAbsoluteScalePower;
			settings.ExportValuesSeparator = Settings.Default.ExportValuesSeparator;
			settings.RecentFilesCount = Settings.Default.RecentFilesCount;
		}

		private static void LoadRegistrySettings(SettingsStorage settings)
		{
			foreach (var extension in PredefinedData.SupportedExtensions)
			{
				var fileAssociation = new FileAssociation(extension);
				if (fileAssociation.Exists)
				{
					settings.AddRegisteredExtension(extension);
				}
			}
		}

		private static void SaveConfigFileSettings(SettingsStorage settings)
		{
			Settings.Default.MaxAbsoluteScalePower = settings.MaxAbsoluteScalePower;
			Settings.Default.ExportValuesSeparator = settings.ExportValuesSeparator;
			Settings.Default.RecentFilesCount = settings.RecentFilesCount;
			Settings.Default.Save();
		}

		private static void SaveRegistrySettings(SettingsStorage oldSettings, SettingsStorage newSettings)
		{
			var oldRegisteredExtensions = new List<string>(oldSettings.RegisteredExtensions);
			foreach (var extension in newSettings.RegisteredExtensions)
			{
				if (!oldRegisteredExtensions.Contains(extension))
				{
					RegisterExtension(extension);
				}
			}

			var newRegisteredExtensions = new List<string>(newSettings.RegisteredExtensions);
			foreach (var extension in oldSettings.RegisteredExtensions)
			{
				if (!newRegisteredExtensions.Contains(extension))
				{
					UnregisterExtension(extension);
				}
			}
		}

		private static void RegisterExtension(string extension)
		{
			var fileAssociation = new FileAssociation(extension);
			fileAssociation.SetOpeningProgram(PredefinedData.ProgramExecutable);
		}

		private static void UnregisterExtension(string extension)
		{
			var fileAssociation = new FileAssociation(extension);
			fileAssociation.Remove();
		}

		#endregion Helpers
	}
}