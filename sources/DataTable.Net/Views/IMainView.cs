using System.Collections.Generic;
using DataTable.Net.Dtos;
using DataTable.Net.Services.Common;

namespace DataTable.Net.Views
{
	public interface IMainView
	{
		void DisableFileDependentControls();
		void EnableFileDependentControls();
		void DisableInitializationDependentControls();
		void EnableInitializationDependentControls();

		string AskUserForFileToOpen();
		DataPropertiesDto AskUserForDataPropertiesDto(DataPropertiesDto currentDataProperties = null);
		string AskUserForFileToExportTo();
		SettingsStorage AskUserForSettings(SettingsStorage currentSettings);

		void CreateColumns(
			int argumentsCount, int functionsCount,
			IEnumerable<ScaleDto> argumentScales, IEnumerable<ScaleDto> functionScales);
		void SetDataRowsCount(int rowsCount);

		void GoToWaitMode();
		void GoToNormalMode();
		void SetStatus(string status);
		void ShowFilePath(string filePath);
		void ShowInformation(string message);
		void ShowWarning(string message);
		void ShowError(string message);
		void ShowAboutForm();
	}
}