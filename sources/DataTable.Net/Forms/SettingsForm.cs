using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataTable.Net.Dtos;
using DataTable.Net.Services.Common;

namespace DataTable.Net.Forms
{
	public partial class SettingsForm : Form
	{
		#region Constructors

		public SettingsForm(SettingsDto settings)
		{
			InitializeComponent();
			InitializeFileTypeCheckBoxes();
			LoadSettings(settings);
		}

		#endregion Constructors

		#region Methods

		public SettingsDto GetSettings()
		{
			return new SettingsDto(
				(int)MaxAbsoluteScalePowerUpDown.Value, ExportValuesSeparatorTextBox.Text,
				(int)RecentFileCountUpDown.Value, GetRegisteredExtensions());
		}

		#endregion Methods

		#region Event handlers

		private void SelectAllFileTypesButton_Click(object sender, EventArgs e)
		{
			foreach (var control in FileTypeCheckBoxesLayoutPanel.Controls)
			{
				if (!(control is CheckBox))
				{
					continue;
				}

				var checkBox = control as CheckBox;
				checkBox.Checked = true;
			}
		}

		#endregion Event handlers

		#region Helpers

		private void InitializeFileTypeCheckBoxes()
		{
			foreach (var extension in PredefinedData.SupportedExtensions)
			{
				var checkBox = new CheckBox
				               {
				               	Text = extension,
				               	Tag = extension,
				               };
				FileTypeCheckBoxesLayoutPanel.Controls.Add(checkBox);
			}
		}

		private void LoadSettings(SettingsDto settings)
		{
			MaxAbsoluteScalePowerUpDown.Value = settings.MaxAbsoluteScalePower;
			ExportValuesSeparatorTextBox.Text = settings.ExportValuesSeparator;
			RecentFileCountUpDown.Value = settings.RecentFilesCount;

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
			foreach (var control in FileTypeCheckBoxesLayoutPanel.Controls)
			{
				if (!(control is CheckBox))
				{
					continue;
				}

				var checkBox = control as CheckBox;
				var tag = (string)checkBox.Tag;
				if (string.Equals(tag, tagValue, StringComparison.OrdinalIgnoreCase))
				{
					return checkBox;
				}
			}

			return null;
		}

		private IEnumerable<string> GetRegisteredExtensions()
		{
			var extensions = new List<string>();
			foreach (var control in FileTypeCheckBoxesLayoutPanel.Controls)
			{
				if (!(control is CheckBox))
				{
					continue;
				}

				var checkBox = control as CheckBox;
				if (checkBox.Checked)
				{
					var extension = (string)checkBox.Tag;
					extensions.Add(extension);
				}
			}

			return extensions;
		}

		#endregion Helpers
	}
}
