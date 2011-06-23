using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataTable.Net.Services.Settings;

namespace DataTable.Net.Forms
{
	public partial class SettingsForm : Form
	{
		#region Constructors

		public SettingsForm(SettingsStorage settings)
		{
			InitializeComponent();
			LoadConfigFileSettings(settings.ConfigFileSettings);
			LoadRegistrySettings(settings.RegistrySettings);
		}

		#endregion Constructors

		#region Methods

		public SettingsStorage GetSettings()
		{
			return new SettingsStorage(SaveConfigFileSettings(), SaveRegistrySettings());
		}

		#endregion Methods

		#region Event handlers

		private void SelectAllFileTypesButton_Click(object sender, EventArgs e)
		{
			DatFileTypeCheckBox.Checked = HexFileTypeCheckBox.Checked = BinFileTypeCheckBox.Checked = true;
		}

		#endregion Event handlers

		#region Helpers

		private void LoadConfigFileSettings(ConfigFileSettings settings)
		{
			MaxAbsoluteScalePowerUpDown.Value = settings.MaxAbsoluteScalePower;
			ExportValuesSeparatorTextBox.Text = settings.ExportValuesSeparator;
		}

		private void LoadRegistrySettings(RegistrySettings registrySettings)
		{
			foreach (var extension in registrySettings.RegisteredExtensions)
			{
				var checkbox = GetCheckBoxByTag(extension);
				if (checkbox != null)
				{
					checkbox.Checked = true;
				}
			}
		}

		private ConfigFileSettings SaveConfigFileSettings()
		{
			return new ConfigFileSettings(
				(int)MaxAbsoluteScalePowerUpDown.Value, ExportValuesSeparatorTextBox.Text);
		}

		private RegistrySettings SaveRegistrySettings()
		{
			return new RegistrySettings(GetRegisteredExtensions());
		}

		private IEnumerable<string> GetRegisteredExtensions()
		{
			var extensions = new List<string>();
			foreach (var checkbox in new[] { DatFileTypeCheckBox, HexFileTypeCheckBox, BinFileTypeCheckBox })
			{
				if (checkbox.Checked)
				{
					var extension = (string)checkbox.Tag;
					extensions.Add(extension);
				}
			}

			return extensions;
		}

		private CheckBox GetCheckBoxByTag(string tagValue)
		{
			foreach (var checkbox in new[] {DatFileTypeCheckBox, HexFileTypeCheckBox, BinFileTypeCheckBox})
			{
				var tag = (string)checkbox.Tag;
				if (string.Equals(tag, tagValue, StringComparison.OrdinalIgnoreCase))
				{
					return checkbox;
				}
			}

			return null;
		}

		#endregion Helpers
	}
}
