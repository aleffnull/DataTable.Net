using System.Collections.Generic;
using DataTable.Net.Dtos;

namespace DataTable.Net.Views
{
	public interface IMainView
	{
		void DisableFileDependentControls();
		void EnableFileDependentControls();
		void DisableSettingsDependentControls();
		void EnableSettingsDependentControls();

		string AskUserForFileToOpen();
		CoreDataPropertiesDto AskUserForDataPropertiesDto(CoreDataPropertiesDto currentDataProperties = null);
		string AskUserForFileToExportTo();
		SettingsDto AskUserForSettings(SettingsDto currentSettings);

		void CreateColumns(
			int argumentsCount, int functionsCount,
			IEnumerable<ScaleDto> argumentScales, IEnumerable<ScaleDto> functionScales);
		void SetDataRowsCount(int rowsCount);

		void Activate();

		void GoToWaitMode();
		void GoToNormalMode();
		void SetStatus(string status);
		void ShowFilePath(string filePath);
		void ShowInformation(string message);
		void ShowError(string message);
		void ShowAboutForm();
	}
}