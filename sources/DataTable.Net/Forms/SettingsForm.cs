using System;
using System.Windows.Forms;
using DataTable.Net.Services.Common;

namespace DataTable.Net.Forms
{
	public partial class SettingsForm : Form
	{
		#region Constructors

		public SettingsForm(SettingsStorage settings)
		{
			InitializeComponent();
			MaxAbsoluteScalePowerUpDown.Value = settings.MaxAbsoluteScalePower;
			ExportValuesSeparatorTextBox.Text = settings.ExportValuesSeparator;
		}

		#endregion Constructors

		#region Methods

		public SettingsStorage GetSettigs()
		{
			return new SettingsStorage(
				(int)MaxAbsoluteScalePowerUpDown.Value, ExportValuesSeparatorTextBox.Text);
		}

		#endregion Methods

		#region Event handlers

		private void SelectAllFileTypesButton_Click(object sender, EventArgs e)
		{
			DatFileTypeCheckBox.Checked = HexFileTypeCheckBox.Checked = BinFileTypeCheckBox.Checked = true;
		}

		#endregion Event handlers
	}
}
