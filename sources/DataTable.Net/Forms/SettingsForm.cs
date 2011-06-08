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
	}
}
