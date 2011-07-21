using System;
using System.Collections.Generic;
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

		#region Properties

		public IEnumerable<string> Items
		{
			get
			{
				var key = GetKey();
				var items = GetItems(key);

				return items;
			}
		}

		#endregion Properties

		#region Methods

		public void AddItem(string item)
		{
			if (currentSize == 0)
			{
				return;
			}

			var key = GetKey();
			var items = GetItems(key);
			if (items.Contains(item))
			{
				var lastItem = items[items.Count - 1];
				if (string.Equals(item, lastItem))
				{
					key.Close();
					return;
				}

				items.Remove(item);
				key.Close();
				SetItems(items);
			}

			key = GetKey();
			var count = GetCount(key);

			if (count + 1 > currentSize)
			{
				count = currentSize - 1;
				key.Close();
				Shrink(count);
				key = GetKey();
			}

			var itemValueName = string.Format(InternalResources.ItemValueName, count);
			count++;
			key.SetValue(itemValueName, item);
			key.SetValue(InternalResources.CountValueName, count);

			key.Close();
		}

		public void Clear()
		{
			Registry.CurrentUser.DeleteSubKeyTree(KeyPath);
		}

		public void SetSize(int size)
		{
			if (size < currentSize)
			{
				Shrink(size);
			}
			currentSize = size;
		}

		#endregion Methods

		#region Helpers

		private static bool KeyExists()
		{
			var key = Registry.CurrentUser.OpenSubKey(KeyPath);
			if (key == null)
			{
				return false;
			}

			key.Close();
			return true;
		}

		private static RegistryKey GetKey()
		{
			var key = Registry.CurrentUser.CreateSubKey(KeyPath);
			if (key == null)
			{
				throw new InvalidOperationException(string.Format(Resources.FailedToCreateOrOpenKey, KeyPath));
			}

			return key;
		}

		private static int GetCount(RegistryKey key)
		{
			var countObject = key.GetValue(InternalResources.CountValueName);
			var count = countObject == null
			            	? 0
			            	: (int)countObject;
			return count;
		}

		private static string GetItem(RegistryKey key, int index)
		{
			var itemValueName = string.Format(InternalResources.ItemValueName, index);
			var item = (string)key.GetValue(itemValueName);

			return item;
		}

		private static List<string> GetItems(RegistryKey key)
		{
			var count = GetCount(key);
			var items = new List<string>(count);
			for (var index = 0; index < count; index++)
			{
				var item = GetItem(key, index);
				items.Add(item);
			}

			return items;
		}

		private static void SetItems(IList<string> items)
		{
			var key = GetKey();
			for (var index = 0; index < items.Count; index++)
			{
				var item = items[index];
				var itemValueName = string.Format(InternalResources.ItemValueName, index);
				key.SetValue(itemValueName, item);
			}
			key.SetValue(InternalResources.CountValueName, items.Count);
			key.Close();
		}

		private void Shrink(int newSize)
		{
			var keyExists = KeyExists();
			if (!keyExists)
			{
				return;
			}

			var key = GetKey();
			var items = GetItems(key);
			key.Close();

			if (newSize >= items.Count)
			{
				throw new InvalidOperationException(Resources.ImpossibleToShrinkListToBiggerSize);
			}

			Clear();
			if (newSize > 0)
			{
				var shrinkedItems = new string[newSize];
				items.CopyTo(items.Count - newSize, shrinkedItems, 0, newSize);
				SetItems(shrinkedItems);
			}
		}

		#endregion Helpers
	}
}