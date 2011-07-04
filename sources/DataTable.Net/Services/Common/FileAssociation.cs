using DataTable.Net.Properties;
using Microsoft.Win32;
using log4net;

namespace DataTable.Net.Services.Common
{
	public class FileAssociation
	{
		#region Fields

		private static readonly ILog log = LogManager.GetLogger(typeof(FileAssociation));
		private readonly string extension;

		#endregion Fields

		#region Properties

		public bool Exists
		{
			get
			{
				log.Debug(InternalResources.CheckingIfAssociationExists);

				var extensionKeyPath = GetExtensionKeyPath();
				var extensionKey = Registry.CurrentUser.OpenSubKey(extensionKeyPath);
				if (extensionKey == null)
				{
					log.DebugFormat(InternalResources.KeyNotExists, extensionKeyPath);
					return false;
				}

				var typeName = (string)extensionKey.GetValue(null);
				if (string.IsNullOrEmpty(typeName))
				{
					log.DebugFormat(InternalResources.KeyValueIsNullOrEmpty, extensionKeyPath);
					return false;
				}

				var typeKeyPath = GetTypeKeyPath(typeName);
				var typeKey = Registry.CurrentUser.OpenSubKey(typeKeyPath);
				if (typeKey == null)
				{
					log.DebugFormat(InternalResources.KeyNotExists, typeKeyPath);
					return false;
				}

				var openCommand = (string)typeKey.GetValue(null);
				if (string.IsNullOrEmpty(openCommand))
				{
					log.DebugFormat(InternalResources.KeyValueIsNullOrEmpty, typeKeyPath);
					return false;
				}
				log.DebugFormat(InternalResources.OpenCommandIs, openCommand);

				var exixts = openCommand.StartsWith(PredefinedData.ProgramExecutable);
				log.Debug(exixts ? InternalResources.AssociationExists : InternalResources.AssociationNotExists);

				return exixts;
			}
		}

		#endregion Properties

		#region Constructors

		public FileAssociation(string extension)
		{
			this.extension = extension.StartsWith(".")
			                 	? extension
			                 	: string.Concat(".", extension);
			log.DebugFormat(InternalResources.CreatedFileAssociation, this.extension);
		}

		#endregion Constructors

		#region Methods

		public void SetOpeningProgram(string pathToExecutable)
		{
			log.DebugFormat(InternalResources.SettingOpeningProgram, pathToExecutable);

			// First, purge existing association data.
			Remove();

			// And register new one.
		}

		public void Remove()
		{
			log.Debug(InternalResources.RemovingAssociation);

			var extensionKeyPath = GetExtensionKeyPath();
			var extensionKey = Registry.CurrentUser.OpenSubKey(extensionKeyPath);
			if (extensionKey == null)
			{
				log.DebugFormat(InternalResources.KeyNotExists, extensionKeyPath);
				return;
			}

			var typeName = (string)extensionKey.GetValue(null);
			if (string.IsNullOrEmpty(typeName))
			{
				log.DebugFormat(InternalResources.KeyValueIsNullOrEmpty, extensionKeyPath);
			}
			else
			{
				var typeKeyPath = GetTypeKeyPath(typeName);
				var typeKey = Registry.CurrentUser.OpenSubKey(typeKeyPath);
				if (typeKey == null)
				{
					log.DebugFormat(InternalResources.KeyNotExists, typeKeyPath);
				}
				else
				{
					log.DebugFormat(InternalResources.DeletingKey, typeKeyPath);
					Registry.CurrentUser.DeleteSubKey(typeKeyPath);
				}
			}
			log.DebugFormat(InternalResources.DeletingKey, extensionKeyPath);
			Registry.CurrentUser.DeleteSubKey(extensionKeyPath);
		}

		#endregion Methods

		#region Helpers

		private string GetExtensionKeyPath()
		{
			return string.Format(InternalResources.SoftwareClasses, extension);
		}

		private static string GetTypeKeyPath(string typeName)
		{
			return string.Format(InternalResources.SoftwareClassesOpenCommand, typeName);
		}

		#endregion Helpers
	}
}