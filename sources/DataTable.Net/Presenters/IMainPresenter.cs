using System;
using System.Windows.Forms;
using DataTable.Net.Views;

namespace DataTable.Net.Presenters
{
	public interface IMainPresenter
	{
		void SetView(IMainView mainView);
		void SetFileToOpen(string filePath);

		void OnLoad();
		void OnOpenFile();
		void OnOpenFile(string filePath);
		void OnClearRecentFilesList();
		void OnReloadFile();
		void OnExportToFile();
		void OnExportToExcel();
		void OnChangeDataProperties();
		void OnChangeSettings();
		void OnAbout();
		string OnMachineArgumentNeeded(int argumentIndex, int rowIndex);
		string OnMachineFunctionNeeded(int functionIndex, int rowIndex);
		int OnArgumentScaleNeeded(int agrumentIndex);
		int OnFunctionScaleNeeded(int functionIndex);
		decimal OnHumanArgumentNeeded(int argumentIndex, int rowIndex);
		decimal OnHumanFunctionNeeded(int functionIndex, int rowIndex);

		void StoreArgumentScale(int argumentIndex, int scale);
		void StoreFunctionScale(int functionIndex, int scale);

		void OnDataError(Exception exception);

		DragDropEffects OnDragEnter(IDataObject dataObject);
		void OnDragDrop(IDataObject dataObject);
	}
}