using System;
using DataTable.Net.Properties;
using Microsoft.Win32;

namespace DataTable.Net.Services.Common
{
	public class FixedRegistryBuffer
	{
		#region Fields

		private static readonly string KeyPath = string.Format(
			InternalResources.SoftwareRecentFiles, InternalResources.ProgramName);

		private int currentSize;

		#endregion Fields

		#region Methods

		public void AddItem(string item)
		{
			var key = GetKey();
			var countObject = key.GetValue(InternalResources.CountValueName);
			var count = countObject == null ? 0 : (int)countObject;
			var lastItem = count == 0
			               	? null
			               	: GetItem(key, count - 1);
			if (lastItem == null || !string.Equals(item, lastItem))
			{
				var itemValueName = string.Format(InternalResources.ItemValueName, count);
				count++;
				key.SetValue(itemValueName, item);
				key.SetValue(InternalResources.CountValueName, count);
			}

			key.Close();
		}

		public void SetSize(int size)
		{
			currentSize = size;
		}

		#endregion Methods

		#region Helpers

		private static RegistryKey GetKey()
		{
			var key = Registry.CurrentUser.CreateSubKey(KeyPath);
			if (key == null)
			{
				throw new InvalidOperationException(string.Format(Resources.FailedToCreateOrOpenKey, KeyPath));
			}

			return key;
		}

		private static string GetItem(RegistryKey key, int index)
		{
			var itemValueName = string.Format(InternalResources.ItemValueName, index);
			var item = (string)key.GetValue(itemValueName);

			return item;
		}

		#endregion Helpers
	}
}