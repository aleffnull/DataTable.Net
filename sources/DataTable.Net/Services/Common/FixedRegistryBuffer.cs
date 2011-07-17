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

		public void AddFile(string filePath)
		{
			
		}

		public void SetSize(int size)
		{
			var key = Registry.CurrentUser.CreateSubKey(KeyPath);
			if (key == null)
			{
				throw new InvalidOperationException(string.Format(Resources.FailedToCreateOrOpenKey, KeyPath));
			}

			key.SetValue(InternalResources.SizeValueName, size);
			key.Close();

			currentSize = size;
		}

		#endregion Methods
	}
}