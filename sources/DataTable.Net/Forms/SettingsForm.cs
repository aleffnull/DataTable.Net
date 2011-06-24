using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataTable.Net.Dtos;

namespace DataTable.Net.Forms
{
	public partial class SettingsForm : Form
	{
		#region Constructors

		public SettingsForm(SettingsDto settings)
		{
			InitializeComponent();
			LoadSettings(settings);
		}

		#endregion Constructors

		#region Methods

		public SettingsDto GetSettings()
		{
			return new SettingsDto(
				(int)MaxAbsoluteScalePowerUpDown.Value, ExportValuesSeparatorTextBox.Text, GetRegisteredExtensions());
		}

		#endregion Methods

		#region Event handlers

		private void SelectAllFileTypesButton_Click(object sender, EventArgs e)
		{
			DatFileTypeCheckBox.Checked = HexFileTypeCheckBox.Checked = BinFileTypeCheckBox.Checked = true;
		}

		#endregion Event handlers

		#region Helpers

		private void LoadSettings(SettingsDto settings)
		{
			MaxAbsoluteScalePowerUpDown.Value = settings.MaxAbsoluteScalePower;
			ExportValuesSeparatorTextBox.Text = settings.ExportValuesSeparator;

			foreach (var extension in settings.RegisteredExtensions)
			{
				var checkbox = GetCheckBoxByTag(extension);
				if (checkbox != null)
				{
					checkbox.Checked = true;
				}
			}
		}

		private CheckBox GetCheckBoxByTag(string tagValue)
		{
			foreach (var checkbox in new[] { DatFileTypeCheckBox, HexFileTypeCheckBox, BinFileTypeCheckBox })
			{
				var tag = (string)checkbox.Tag;
				if (string.Equals(tag, tagValue, StringComparison.OrdinalIgnoreCase))
				{
					return checkbox;
				}
			}

			return null;
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

		#endregion Helpers
	}
}
