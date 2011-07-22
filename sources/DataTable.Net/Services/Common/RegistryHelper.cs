using DataTable.Net.Properties;
using Microsoft.Win32;
using log4net;

namespace DataTable.Net.Services.Common
{
	public static class RegistryHelper
	{
		#region Fields

		private static readonly ILog log = LogManager.GetLogger(typeof(RegistryHelper));

		#endregion Fields

		#region Methods

		public static RegistryKey CreateSubKey(string path)
		{
			log.DebugFormat(InternalResources.CreatingOrOpeningKey, path);
			return Registry.CurrentUser.CreateSubKey(path);
		}

		public static RegistryKey CreateSubKey(RegistryKey key, string path)
		{
			log.DebugFormat(InternalResources.CreatingOrOpeningSubkey, path, key);
			return Registry.CurrentUser.CreateSubKey(path);
		}

		public static RegistryKey OpenKey(string path)
		{
			log.DebugFormat(InternalResources.OpeningKeyReadOnly, path);
			return Registry.CurrentUser.OpenSubKey(path);
		}

		public static object GetValue(RegistryKey key, string name)
		{
			log.DebugFormat(InternalResources.GettingKeyValue, key, name);
			var value = key.GetValue(name);
			log.DebugFormat(InternalResources.GotValue, value);

			return key.GetValue(name);
		}

		public static void SetValue(RegistryKey key, string name, object value)
		{
			log.DebugFormat(InternalResources.SettingKeyValue, key, name, value);
			key.SetValue(name, value);
		}

		public static void DeleteTree(string path)
		{
			log.DebugFormat(InternalResources.DeletingKey, path);
			Registry.CurrentUser.DeleteSubKeyTree(path);
		}

		#endregion Methods
	}
}