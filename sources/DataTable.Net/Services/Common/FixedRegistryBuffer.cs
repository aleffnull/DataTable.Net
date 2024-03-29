﻿using System;
using System.Collections.Generic;
using DataTable.Net.Properties;
using Microsoft.Win32;
using log4net;

namespace DataTable.Net.Services.Common
{
	public class FixedRegistryBuffer
	{
		#region Fields

		private static readonly ILog log = LogManager.GetLogger(typeof(FixedRegistryBuffer));
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
			log.DebugFormat(InternalResources.AddingItem, item);

			if (currentSize == 0)
			{
				log.Debug(InternalResources.ZeroBufferSize);
				return;
			}

			var key = GetKey();
			var items = GetItems(key);
			if (items.Contains(item))
			{
				log.DebugFormat(InternalResources.ItemAlreadyExists, item);

				var lastItem = items[items.Count - 1];
				if (string.Equals(item, lastItem))
				{
					log.Debug(InternalResources.NewItemDuplicatesTheLastOne);
					key.Close();

					return;
				}

				log.Debug(InternalResources.RemovingDuplicatedItem);
				items.Remove(item);
				key.Close();
				SetItems(items);
			}

			key = GetKey();
			var count = GetCount(key);

			if (count + 1 > currentSize)
			{
				log.DebugFormat(InternalResources.BufferWillExceedItsSize, count, currentSize);

				count = currentSize - 1;
				key.Close();
				Shrink(count);
				key = GetKey();
			}

			log.Debug(InternalResources.SavingItem);
			var itemValueName = string.Format(InternalResources.ItemValueName, count);
			count++;
			RegistryHelper.SetValue(key, itemValueName, item);
			RegistryHelper.SetValue(key, InternalResources.CountValueName, count);

			key.Close();
		}

		public void Clear()
		{
			log.Debug(InternalResources.ClearingBuffer);
			RegistryHelper.DeleteTree(KeyPath);
		}

		public void SetSize(int size)
		{
			log.DebugFormat(InternalResources.ChangingBufferSize, currentSize, size);

			if (size < currentSize)
			{
				log.Debug(InternalResources.NeedToShrunkBuffer);
				Shrink(size);
			}
			currentSize = size;
		}

		#endregion Methods

		#region Helpers

		private static bool KeyExists()
		{
			log.DebugFormat(InternalResources.CheckingKeyExistance, KeyPath);

			var key = RegistryHelper.OpenKey(KeyPath);
			if (key == null)
			{
				log.Debug(InternalResources.NotExists);
				return false;
			}

			key.Close();
			log.Debug(InternalResources.Exists);

			return true;
		}

		private static RegistryKey GetKey()
		{
			var key = RegistryHelper.CreateSubKey(KeyPath);
			if (key == null)
			{
				throw new InvalidOperationException(string.Format(Resources.FailedToCreateOrOpenKey, KeyPath));
			}

			return key;
		}

		private static int GetCount(RegistryKey key)
		{
			var countObject = RegistryHelper.GetValue(key, InternalResources.CountValueName);
			var count = countObject == null
			            	? 0
			            	: (int)countObject;
			return count;
		}

		private static string GetItem(RegistryKey key, int index)
		{
			var itemValueName = string.Format(InternalResources.ItemValueName, index);
			var item = (string)RegistryHelper.GetValue(key, itemValueName);

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
			log.Debug(InternalResources.SettingItems);

			var key = GetKey();
			for (var index = 0; index < items.Count; index++)
			{
				var item = items[index];
				var itemValueName = string.Format(InternalResources.ItemValueName, index);
				RegistryHelper.SetValue(key, itemValueName, item);
			}
			RegistryHelper.SetValue(key, InternalResources.CountValueName, items.Count);
			key.Close();
		}

		private void Shrink(int newSize)
		{
			log.DebugFormat(InternalResources.ShrinkingBuffer, newSize);

			var keyExists = KeyExists();
			if (!keyExists)
			{
				log.Debug(InternalResources.NoBufferInRegistry);
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