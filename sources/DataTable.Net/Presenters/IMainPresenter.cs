using System;

namespace DataTable.Net.Presenters
{
	public interface IMainPresenter
	{
		void OnLoad();
		void OnOpenFile();
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
	}
}