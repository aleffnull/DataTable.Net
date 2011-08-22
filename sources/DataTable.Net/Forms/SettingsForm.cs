using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataTable.Net.Dtos;
using DataTable.Net.Presenters;
using DataTable.Net.Presenters.Impl;
using DataTable.Net.Views;

namespace DataTable.Net.Forms
{
	public partial class SettingsForm : Form, ISettingsView
	{
		#region Fields

		private readonly ISettingsPresenter presenter;

		#endregion Fields

		#region Constructors

		public SettingsForm(SettingsDto settings)
		{
			InitializeComponent();
			presenter = new SettingsPresenter(this, settings);
		}

		#endregion Constructors

		#region ISettingsView implementation

		int ISettingsView.MaxAbsoluteScalePower
		{
			get { return (int)MaxAbsoluteScalePowerUpDown.Value; }
			set { MaxAbsoluteScalePowerUpDown.Value = value; }
		}

		string ISettingsView.ExportValuesSeparator
		{
			get { return ExportValuesSeparatorTextBox.Text; }
			set { ExportValuesSeparatorTextBox.Text = value; }
		}

		int ISettingsView.RecentFilesCount
		{
			get { return (int)RecentFilesCountUpDown.Value; }
			set { RecentFilesCountUpDown.Value = value; }
		}

		void ISettingsView.AddExtension(string extension)
		{
			var checkBox = new CheckBox
			               {
			               	Text = extension,
			               	Tag = extension,
			               };
			FileTypeCheckBoxesLayoutPanel.Controls.Add(checkBox);
		}

		void ISettingsView.ToogleExtension(string extension, bool selected)
		{
			var checkbox = GetCheckBoxByTag(extension);
			if (checkbox != null)
			{
				checkbox.Checked = selected;
			}
		}

		IEnumerable<string> ISettingsView.GetSelectedExtensions()
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

		void ISettingsView.SelectAllExtensions()
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

		#endregion ISettingsView implementation

		#region Methods

		public SettingsDto GetSettings()
		{
			return presenter.GetSettings();
		}

		#endregion Methods

		#region Event handlers

		private void SettingsForm_Load(object sender, EventArgs e)
		{
			presenter.OnLoad();
		}

		private void SelectAllFileTypesButton_Click(object sender, EventArgs e)
		{
			presenter.OnSelectAllExtensions();
		}

		#endregion Event handlers

		#region Helpers

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

		#endregion Helpers
	}
}
