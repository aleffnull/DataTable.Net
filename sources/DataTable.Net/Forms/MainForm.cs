using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DataTable.Net.Dtos;
using DataTable.Net.Models;
using DataTable.Net.Presenters;
using DataTable.Net.Presenters.Impl;
using DataTable.Net.Properties;
using DataTable.Net.Views;

namespace DataTable.Net.Forms
{
	public partial class MainForm : Form, IMainView
	{
		#region Fields

		private readonly IMainPresenter presenter;
		private readonly ColumnIndicesModel columnIndicesModel = new ColumnIndicesModel();

		#endregion Fields

		#region Constructors

		public MainForm(string fileToOpen)
		{
			InitializeComponent();
			presenter = new MainPresenter(this, fileToOpen);
		}

		#endregion Constructors

		#region IMainView implementation

		void IMainView.DisableFileDependentControls()
		{
			ReloadToolStripMenuItem.Enabled = DataPropertiesToolStripMenuItem.Enabled = ExportToolStripMenuItem.Enabled = false;
			ReloadToolStripButton.Enabled =
				ExportToFileToolStripButton.Enabled =
				ExportToExcelToolStripButton.Enabled =
				DataPropertiesToolStripButton.Enabled = false;
		}

		void IMainView.EnableFileDependentControls()
		{
			ReloadToolStripMenuItem.Enabled = DataPropertiesToolStripMenuItem.Enabled = ExportToolStripMenuItem.Enabled = true;
			ReloadToolStripButton.Enabled =
				ExportToFileToolStripButton.Enabled =
				ExportToExcelToolStripButton.Enabled =
				DataPropertiesToolStripButton.Enabled = true;
		}

		void IMainView.DisableSettingsDependentControls()
		{
			OpenToolStripMenuItem.Enabled = false;
			OpenToolStripButton.Enabled = false;
		}

		void IMainView.EnableSettingsDependentControls()
		{
			OpenToolStripMenuItem.Enabled = true;
			OpenToolStripButton.Enabled = true;
		}

		void IMainView.DisableRecentFilesDependentControls()
		{
			OpenToolStripMenuItem.Enabled = false;
			OpenToolStripButton.Enabled = false;
		}

		void IMainView.EnableRecentFilesDependentControls()
		{
			OpenToolStripMenuItem.Enabled = true;
			OpenToolStripButton.Enabled = true;
		}

		string IMainView.AskUserForFileToOpen()
		{
			var result = OpenFileDialog.ShowDialog(this);
			return result == DialogResult.OK
			       	? OpenFileDialog.FileName
			       	: string.Empty;
		}

		CoreDataPropertiesDto IMainView.AskUserForDataPropertiesDto(CoreDataPropertiesDto currentDataProperties)
		{
			var dataPropertiesForm = new DataPropertiesForm(currentDataProperties);
			var result = dataPropertiesForm.ShowDialog(this);
			var model = result == DialogResult.OK
			            	? dataPropertiesForm.GetCoreDataPropertiesDto()
			            	: null;

			return model;
		}

		string IMainView.AskUserForFileToExportTo()
		{
			var result = ExportFileDialog.ShowDialog(this);
			return result == DialogResult.OK
			       	? ExportFileDialog.FileName
			       	: string.Empty;
		}

		SettingsDto IMainView.AskUserForSettings(SettingsDto currentSettings)
		{
			var settingsForm = new SettingsForm(currentSettings);
			var result = settingsForm.ShowDialog(this);
			var settings = result == DialogResult.OK
			               	? settingsForm.GetSettings()
			               	: null;

			return settings;
		}

		void IMainView.CreateColumns(
			int argumentsCount, int functionsCount,
			IEnumerable<ScaleDto> argumentScales, IEnumerable<ScaleDto> functionScales)
		{
			((ISupportInitialize)DataGridView).BeginInit();

			columnIndicesModel.Clear();
			DataGridView.Rows.Clear();
			DataGridView.Columns.Clear();

			for (var i = 0; i < argumentsCount; i++)
			{
				var name = argumentsCount == 1
				           	? InternalResources.MachineArgumentSingleColumnTitle
				           	: string.Format(InternalResources.MachineArgumentMultipleColumnTitle, i + 1);
				var index = DataGridView.Columns.Add(name, name);
				columnIndicesModel.AddMachineArgumentIndex(index);
			}

			for (var i = 0; i < functionsCount; i++)
			{
				var name = functionsCount == 1
				           	? InternalResources.MachineFunctionSingleColumnTitle
				           	: string.Format(InternalResources.MachineFunctionMultipleColumnTitle, i + 1);
				var index = DataGridView.Columns.Add(name, name);
				columnIndicesModel.AddMachineFunctionIndex(index);
			}

			DataGridView.Rows.Add();

			// Now add columns with changable scale.

			for (var i = 0; i < argumentsCount; i++)
			{
				var name = argumentsCount == 1
				           	? InternalResources.HumanArgumentSingleColumnTitle
				           	: string.Format(InternalResources.HumanArgumentMultipleColumnTitle, i + 1);
				var index = DataGridView.Columns.Add(name, name);

				var scalesCell = new DataGridViewComboBoxCell
				                 {
				                 	DataSource = argumentScales,
				                 	ValueMember = InternalResources.ScaleDtoValueMember,
				                 	DisplayMember = InternalResources.ScaleDtoDisplayMember
				                 };
				DataGridView.Rows[0].Cells[argumentsCount + functionsCount + i] = scalesCell;
				columnIndicesModel.AddHumanArgumentIndex(index);
			}

			for (var i = 0; i < functionsCount; i++)
			{
				var name = functionsCount == 1
				           	? InternalResources.HumanFunctiontSingleColumnTitle
				           	: string.Format(InternalResources.HumanFunctionMultipleColumnTitle, i + 1);
				var index = DataGridView.Columns.Add(name, name);
				var scalesCell = new DataGridViewComboBoxCell
				                 {
				                 	DataSource = functionScales,
				                 	ValueMember = InternalResources.ScaleDtoValueMember,
				                 	DisplayMember = InternalResources.ScaleDtoDisplayMember
				                 };
				DataGridView.Rows[0].Cells[2*argumentsCount + functionsCount + i] = scalesCell;
				columnIndicesModel.AddHumanFunctionIndex(index);
			}

			// Row with comboboxes cannot be scrolled.
			DataGridView.Rows[0].Frozen = true;
			DataGridView.Rows[0].DefaultCellStyle = DataGridView.RowHeadersDefaultCellStyle;

			((ISupportInitialize)DataGridView).EndInit();
		}

		void IMainView.SetDataRowsCount(int rowsCount)
		{
			// Reserve one row for comboboxes.
			DataGridView.RowCount = rowsCount + 1;

			for (var i = 1; i < rowsCount + 1; i++)
			{
				DataGridView.Rows[i].HeaderCell.Value = i.ToString();
			}
			DataGridView.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
		}

		void IMainView.SetRecentFiles(IEnumerable<RecentFileDto> recentFiles)
		{
			//
		}

		void IMainView.Activate()
		{
			Activate();
		}

		void IMainView.GoToWaitMode()
		{
			MainMenu.Enabled = MainToolBar.Enabled = DataGridView.Enabled = false;
		}

		void IMainView.GoToNormalMode()
		{
			MainMenu.Enabled = MainToolBar.Enabled = DataGridView.Enabled = true;
		}

		void IMainView.SetStatus(string status)
		{
			StatusLabel.Text = status;
		}

		void IMainView.ShowFilePath(string filePath)
		{
			FilePathStatusLabel.Text = filePath;
		}

		void IMainView.ShowInformation(string message)
		{
			MessageBox.Show(message, Resources.InformationMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		void IMainView.ShowError(string message)
		{
			MessageBox.Show(message, Resources.ErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		void IMainView.ShowAboutForm()
		{
			var aboutForm = new AboutForm();
			aboutForm.ShowDialog(this);
		}

		#endregion IMainView implementation

		#region Event handlers

		#region Form

		private void MainForm_Load(object sender, EventArgs e)
		{
			presenter.OnLoad();
		}

		#endregion Form

		#region Menu

		private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			presenter.OnOpenFile();
		}

		private void ReloadToolStripMenuItem_Click(object sender, EventArgs e)
		{
			presenter.OnReloadFile();
		}

		private void ExportToFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			presenter.OnExportToFile();
		}

		private void ExportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			presenter.OnExportToExcel();
		}

		private void DataPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
		{
			presenter.OnChangeDataProperties();
		}

		private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			presenter.OnChangeSettings();
		}

		private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			presenter.OnAbout();
		}

		#endregion Menu

		#region Toolbar

		private void OpenToolStripButton_Click(object sender, EventArgs e)
		{
			presenter.OnOpenFile();
		}

		private void ReloadToolStripButton_Click(object sender, EventArgs e)
		{
			presenter.OnReloadFile();
		}

		private void ExportToFileToolStripButton_Click(object sender, EventArgs e)
		{
			presenter.OnExportToFile();
		}

		private void ExportToExcelToolStripButton_Click(object sender, EventArgs e)
		{
			presenter.OnExportToExcel();
		}

		private void DataPropertiesToolStripButton_Click(object sender, EventArgs e)
		{
			presenter.OnChangeDataProperties();
		}

		private void SettingsToolStripButton_Click(object sender, EventArgs e)
		{
			presenter.OnChangeSettings();
		}

		private void AboutToolStripButton_Click(object sender, EventArgs e)
		{
			presenter.OnAbout();
		}

		#endregion Toolbar

		#region Grid

		private void DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			if (e.RowIndex != 0)
			{
				// Cancel editing for all rows except combobox row.
				e.Cancel = true;
			}
		}

		private void DataGridView_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
		{
			if (columnIndicesModel.IsMachineArgumentIndex(e.ColumnIndex))
			{
				if (e.RowIndex == 0)
				{
					return;
				}

				e.Value = presenter.OnMachineArgumentNeeded(
					columnIndicesModel.GetMachineArgumentIndex(e.ColumnIndex), e.RowIndex - 1);
			}
			else if (columnIndicesModel.IsMachineFunctionIndex(e.ColumnIndex))
			{
				if (e.RowIndex == 0)
				{
					return;
				}

				e.Value = presenter.OnMachineFunctionNeeded(
					columnIndicesModel.GetMachineFunctionIndex(e.ColumnIndex), e.RowIndex - 1);
			}
			else if (columnIndicesModel.IsHumanArgumentIndex(e.ColumnIndex))
			{
				if (e.RowIndex == 0)
				{
					e.Value = presenter.OnArgumentScaleNeeded(
						columnIndicesModel.GetHumanArgumentIndex(e.ColumnIndex));
				}
				else
				{
					e.Value = presenter.OnHumanArgumentNeeded(
						columnIndicesModel.GetHumanArgumentIndex(e.ColumnIndex), e.RowIndex - 1);
				}
			}
			else if (columnIndicesModel.IsHumanFunctionIndex(e.ColumnIndex))
			{
				if (e.RowIndex == 0)
				{
					e.Value = presenter.OnFunctionScaleNeeded(
						columnIndicesModel.GetHumanFunctionIndex(e.ColumnIndex));
				}
				else
				{
					e.Value = presenter.OnHumanFunctionNeeded(
						columnIndicesModel.GetHumanFunctionIndex(e.ColumnIndex), e.RowIndex - 1);
				}
			}
		}

		private void DataGridView_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
		{
			if (e.RowIndex != 0)
			{
				// Only combobox row can be edited.
				return;
			}

			if (columnIndicesModel.IsHumanArgumentIndex(e.ColumnIndex))
			{
				var scale = (int)e.Value;
				presenter.StoreArgumentScale(columnIndicesModel.GetHumanArgumentIndex(e.ColumnIndex), scale);
				DataGridView.InvalidateColumn(e.ColumnIndex);
			}
			else if (columnIndicesModel.IsHumanFunctionIndex(e.ColumnIndex))
			{
				var scale = (int)e.Value;
				presenter.StoreFunctionScale(columnIndicesModel.GetHumanFunctionIndex(e.ColumnIndex), scale);
				DataGridView.InvalidateColumn(e.ColumnIndex);
			}
		}

		private void DataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			presenter.OnDataError(e.Exception);
		}

		private void DataGridView_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = presenter.OnDragEnter(e.Data);
		}

		private void DataGridView_DragDrop(object sender, DragEventArgs e)
		{
			presenter.OnDragDrop(e.Data);
		}

		#endregion Grid

		#endregion Event handlers
	}
}
