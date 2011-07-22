using System;
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
				var extensionKey = RegistryHelper.OpenKey(extensionKeyPath);
				if (extensionKey == null)
				{
					log.DebugFormat(InternalResources.KeyNotExists, extensionKeyPath);
					return false;
				}

				var typeName = (string)RegistryHelper.GetValue(extensionKey, null);
				if (string.IsNullOrEmpty(typeName))
				{
					log.DebugFormat(InternalResources.KeyValueIsNullOrEmpty, extensionKeyPath);
					return false;
				}

				var openCommandPath = GetOpenCommandPath(typeName);
				var openCommandKey = RegistryHelper.OpenKey(openCommandPath);
				if (openCommandKey == null)
				{
					log.DebugFormat(InternalResources.KeyNotExists, openCommandPath);
					return false;
				}

				var openCommand = (string)RegistryHelper.GetValue(openCommandKey, null);
				if (string.IsNullOrEmpty(openCommand))
				{
					log.DebugFormat(InternalResources.KeyValueIsNullOrEmpty, openCommandPath);
					return false;
				}
				log.DebugFormat(InternalResources.OpenCommandIs, openCommand);

				var exixts = openCommand.Contains(PredefinedData.ProgramExecutable);
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

			// Create extension key.
			var extensionKeyPath = GetExtensionKeyPath();
			var extensionKey = RegistryHelper.CreateSubKey(extensionKeyPath);
			if (extensionKey == null)
			{
				throw new InvalidOperationException(string.Format(Resources.FailedToCreateOrOpenKey, extensionKeyPath));
			}

			// Set extension key value (file type).
			var typeName = GetTypeName();
			RegistryHelper.SetValue(extensionKey, null, typeName);
			extensionKey.Close();

			// Create file type key.
			var typeKeyPath = GetTypeKeyPath(typeName);
			var typeKey = RegistryHelper.CreateSubKey(typeKeyPath);
			if (typeKey == null)
			{
				throw new InvalidOperationException(string.Format(Resources.FailedToCreateOrOpenKey, typeKeyPath));
			}

			// Set open command.
			typeKey.SetValue(null, Resources.FileTypeDescription);
			var openCommandKey = typeKey.CreateSubKey(InternalResources.OpenCommandPath);
			if (openCommandKey == null)
			{
				throw new InvalidOperationException(
					string.Format(Resources.FailedToCreateOrOpenKey, InternalResources.OpenCommandPath));
			}

			var openCommandValue = GetOpenCommandValue();
			openCommandKey.SetValue(null, openCommandValue);
			openCommandKey.Close();

			// Set file icon.
			var defaultIconKey = RegistryHelper.CreateSubKey(typeKey, InternalResources.DefaultIcon);
			if (defaultIconKey == null)
			{
				throw new InvalidOperationException(
					string.Format(Resources.FailedToCreateOrOpenKey, InternalResources.DefaultIcon));
			}
			RegistryHelper.SetValue(defaultIconKey, null, GetDefaultIconValue());
			defaultIconKey.Close();
			typeKey.Close();

			log.Debug(InternalResources.SendingShellNotification);
			ShellNotification.NotifyOfChange();
		}

		public void Remove()
		{
			log.Debug(InternalResources.RemovingAssociation);

			var extensionKeyPath = GetExtensionKeyPath();
			var extensionKey = RegistryHelper.OpenKey(extensionKeyPath);
			if (extensionKey == null)
			{
				log.DebugFormat(InternalResources.KeyNotExists, extensionKeyPath);
				return;
			}

			var typeName = (string)RegistryHelper.GetValue(extensionKey, null);
			if (string.IsNullOrEmpty(typeName))
			{
				log.DebugFormat(InternalResources.KeyValueIsNullOrEmpty, extensionKeyPath);
			}
			else
			{
				var typeKeyPath = GetTypeKeyPath(typeName);
				var typeKey = RegistryHelper.OpenKey(typeKeyPath);
				if (typeKey == null)
				{
					log.DebugFormat(InternalResources.KeyNotExists, typeKeyPath);
				}
				else
				{
					RegistryHelper.DeleteTree(typeKeyPath);
				}
			}
			RegistryHelper.DeleteTree(extensionKeyPath);

			log.Debug(InternalResources.SendingShellNotification);
			ShellNotification.NotifyOfChange();
		}

		#endregion Methods

		#region Helpers

		private string GetExtensionKeyPath()
		{
			return string.Format(InternalResources.SoftwareClasses, extension);
		}

		private string GetTypeName()
		{
			return string.Concat(InternalResources.ProgramName, extension);
		}

		private static string GetTypeKeyPath(string typeName)
		{
			return string.Format(InternalResources.SoftwareClasses, typeName);
		}

		private static string GetOpenCommandPath(string typeName)
		{
			return string.Concat(GetTypeKeyPath(typeName), InternalResources.OpenCommandPath);
		}

		private static string GetOpenCommandValue()
		{
			return string.Format(InternalResources.OpenCommandFormat, PredefinedData.ProgramExecutable);
		}

		private static string GetDefaultIconValue()
		{
			return string.Format(InternalResources.DefaultIconFormat, PredefinedData.FileIcon);
		}

		#endregion Helpers
	}
}