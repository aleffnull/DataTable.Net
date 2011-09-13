using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using DataTable.Net.Dtos;
using DataTable.Net.Models;
using DataTable.Net.Properties;
using DataTable.Net.Services;
using DataTable.Net.Services.Common;
using DataTable.Net.Views;
using log4net;

namespace DataTable.Net.Presenters.Impl
{
	internal class MainPresenter : IMainPresenter
	{
		#region Fields

		private readonly ILog log = LogManager.GetLogger(typeof(MainPresenter));
		private readonly ISettingsService settingsService;
		private readonly IRecentFilesService recentFilesService;
		private readonly IDataService dataService;
		private readonly ITaskService taskService;
		private IMainView view;
		private string fileToOpen;
		private DataModel currentDataModel;

		#endregion Fields

		#region Constructors

		public MainPresenter(
			ISettingsService settingsService, IRecentFilesService recentFilesService,
			IDataService dataService, ITaskService taskService)
		{
			this.settingsService = settingsService;
			this.recentFilesService = recentFilesService;
			this.dataService = dataService;
			this.taskService = taskService;
		}

		#endregion Constructors

		#region IMainPresenter implementation

		public void SetView(IMainView mainView)
		{
			view = mainView;
		}

		public void SetFileToOpen(string filePath)
		{
			fileToOpen = filePath;
		}

		public void OnLoad()
		{
			taskService.CreateTask(() =>
			                       {
			                       	recentFilesService.SetSize(settingsService.CurrentSettings.RecentFilesCount);
			                       	return recentFilesService.GetRecentFiles();
			                       })
				.RunBefore(() =>
				           {
				           	log.Info(InternalResources.LoadingRecentFiles);
				           	view.SetStatus(Resources.LoadingRecentFilesStatus);
				           	view.DisableFileDependentControls();
				           })
				.RunOnSuccess(recentFiles => view.SetRecentFiles(recentFiles))
				.RunOnError(exception =>
				            {
				            	log.Error(exception);
				            	var message = string.Format(Resources.FailedToLoadRecentFiles, exception.Message);
				            	view.ShowError(message);
				            })
				.RunOnDone(() =>
				           {
				           	log.Info(InternalResources.RecentFilesLoaded);
				           	view.EnableRecentFilesDependentControls();
				           	view.SetStatus(Resources.ReadyStatus);

				           	// Application is loaded. Open file, if needed.
				           	if (!string.IsNullOrEmpty(fileToOpen))
				           	{
				           		OnOpenFile(fileToOpen);
				           	}
				           })
				.Start();
		}

		public void OnOpenFile()
		{
			var filePath = view.AskUserForFileToOpen();
			if (string.IsNullOrEmpty(filePath))
			{
				return;
			}

			OnOpenFile(filePath);
		}

		public void OnOpenFile(string filePath)
		{
			log.InfoFormat(InternalResources.OpeningFile, filePath);

			var coreDataPropertiesDto = view.AskUserForDataPropertiesDto();
			if (coreDataPropertiesDto == null)
			{
				log.Info(InternalResources.NoDataPropertiesOpeningCanceled);
				return;
			}

			log.InfoFormat(InternalResources.GotDataProperties, coreDataPropertiesDto);
			LoadFile(filePath, coreDataPropertiesDto);
		}

		public void OnClearRecentFilesList()
		{
			log.Info(InternalResources.ClearingRecentFilesList);

			view.GoToWaitMode();
			view.SetStatus(Resources.ClearingRecentFilesList);

			taskService.CreateTask(() => recentFilesService.Clear())
				.RunOnSuccess(ClearRecentFilesSuccessCallback)
				.RunOnError(ClearRecentFilesErrorCallback)
				.Start();
		}

		public void OnReloadFile()
		{
			ReloadFile();
		}

		public void OnExportToFile()
		{
			var filePath = view.AskUserForFileToExportTo();
			if (string.IsNullOrEmpty(filePath))
			{
				return;
			}

			log.InfoFormat(InternalResources.ExportingToFile, filePath);
			view.SetStatus(Resources.ExportingToFileStatus);
			view.GoToWaitMode();
			taskService.CreateTask(
				() =>
				dataService.ExportDataToFile(filePath, currentDataModel, settingsService.CurrentSettings.ExportValuesSeparator))
				.RunOnSuccess(ExportDataToFileSuccessCallback)
				.RunOnError(ExportDataToFileErrorCallback)
				.Start();
		}

		public void OnExportToExcel()
		{
			log.Info(InternalResources.ExportingToExcel);
			view.SetStatus(Resources.ExportingToExcelStatus);

			view.GoToWaitMode();
			taskService.CreateTask(() => dataService.ExportToExcel(currentDataModel))
				.RunOnSuccess(ExportToExcelSuccessCallback)
				.RunOnError(ExportToExcelErrorCallback)
				.Start();
		}

		public void OnChangeDataProperties()
		{
			var newCoreDataPropertiesDto = view.AskUserForDataPropertiesDto(currentDataModel.GetCoreDataPropertiesDto());
			if (newCoreDataPropertiesDto == null)
			{
				return;
			}

			log.InfoFormat(
				InternalResources.ReloadingFileWithNewDataProperties,
				currentDataModel.FilePath, newCoreDataPropertiesDto);
			LoadFile(currentDataModel.FilePath, newCoreDataPropertiesDto);
		}

		public void OnChangeSettings()
		{
			var currentSettingsDto = GetSettingsDto(settingsService.CurrentSettings);
			var newSettingsDto = view.AskUserForSettings(currentSettingsDto);
			if (newSettingsDto == null)
			{
				return;
			}

			var newSettings = GetSettingsStorage(newSettingsDto);

			log.InfoFormat(InternalResources.ChangingSettingsFromTo, settingsService.CurrentSettings, newSettings);
			view.SetStatus(Resources.SavingSettingsStatus);
			view.GoToWaitMode();

			var loadRecentFilesTask = taskService.CreateTask(
				() =>
				{
					recentFilesService.SetSize(settingsService.CurrentSettings.RecentFilesCount);
					return recentFilesService.GetRecentFiles();
				})
				.RunOnSuccess(recentFiles => view.SetRecentFiles(recentFiles))
				.RunOnError(exception =>
				            {
				            	log.Error(exception);
				            	var message = string.Format(Resources.FailedToLoadRecentFiles, exception.Message);
				            	view.ShowError(message);
				            });
			taskService.CreateTask(() => settingsService.SaveSettings(newSettings))
				.WithContinuation(loadRecentFilesTask)
				.RunOnSuccess(SaveSettingsSuccessCallback).RunOnError(SaveSettingErrorCallback)
				.Start();
		}

		public void OnAbout()
		{
			view.ShowAboutForm();
		}

		public string OnMachineArgumentNeeded(int argumentIndex, int rowIndex)
		{
			return currentDataModel.GetMachineArgument(argumentIndex, rowIndex);
		}

		public string OnMachineFunctionNeeded(int functionIndex, int rowIndex)
		{
			return currentDataModel.GetMachineFunction(functionIndex, rowIndex);
		}

		public int OnArgumentScaleNeeded(int agrumentIndex)
		{
			return currentDataModel.GetArgumentScale(agrumentIndex);
		}

		public int OnFunctionScaleNeeded(int functionIndex)
		{
			return currentDataModel.GetFunctionScale(functionIndex);
		}

		public decimal OnHumanArgumentNeeded(int argumentIndex, int rowIndex)
		{
			return currentDataModel.GetHumanArgument(argumentIndex, rowIndex);
		}

		public decimal OnHumanFunctionNeeded(int functionIndex, int rowIndex)
		{
			return currentDataModel.GetHumanFunction(functionIndex, rowIndex);
		}

		public void StoreArgumentScale(int argumentIndex, int scale)
		{
			currentDataModel.SetArgumentScale(argumentIndex, scale);
		}

		public void StoreFunctionScale(int functionIndex, int scale)
		{
			currentDataModel.SetFunctionScale(functionIndex, scale);
		}

		public void OnDataError(Exception exception)
		{
			log.Error(InternalResources.DataError, exception);
			view.ShowError(string.Format(Resources.DataErrorMessage, exception.Message));
		}

		public DragDropEffects OnDragEnter(IDataObject dataObject)
		{
			if (!dataObject.GetDataPresent(DataFormats.FileDrop))
			{
				return DragDropEffects.None;
			}

			var paths = (string[])dataObject.GetData(DataFormats.FileDrop);
			if (paths.Length != 1)
			{
				return DragDropEffects.None;
			}

			var attributes = File.GetAttributes(paths[0]);
			var isFolder = (attributes & FileAttributes.Directory) == FileAttributes.Directory;
			if (isFolder)
			{
				return DragDropEffects.None;
			}

			return DragDropEffects.Copy;
		}

		public void OnDragDrop(IDataObject dataObject)
		{
			var filePath = ((string[])dataObject.GetData(DataFormats.FileDrop))[0];

			/*
			 * We need to leave current thread to free the application,
			 * that was the source of drag-n-drop operation. So we do a dummy action
			 * in a separate thread and open file in callback executed in the UI thread.
			 */
			taskService.CreateTask(delegate { }).RunOnSuccess(() => OpenDragDroppedFile(filePath)).Start();
		}

		#endregion IMainPresenter implementation

		#region Service callbacks

		private void SaveSettingsSuccessCallback()
		{
			view.SetStatus(Resources.ReadyStatus);
			view.GoToNormalMode();

			if (currentDataModel != null)
			{
				ReloadFile();
			}
		}

		private void SaveSettingErrorCallback(Exception exception)
		{
			log.Error(exception);

			var message = string.Format(Resources.SaveSettingsFailed, exception.Message);
			view.ShowError(message);
			view.SetStatus(Resources.ReadyStatus);
			view.GoToNormalMode();
		}

		private void LoadDataSuccessCallback(DataModel model)
		{
			log.Info(InternalResources.DataWasLoadedSuccessfully);
			currentDataModel = model;

			view.CreateColumns(
				model.NumberOfArguments, model.NumberOfFunctions,
				GetScaleDtos(model.CreateArgumentScales(settingsService.CurrentSettings.MaxAbsoluteScalePower)),
				GetScaleDtos(model.CreateFunctionScales(settingsService.CurrentSettings.MaxAbsoluteScalePower)));
			view.SetDataRowsCount(model.DataEntriesCount);
			view.ShowFilePath(model.FilePath);
			view.SetStatus(Resources.ReadyStatus);
			view.GoToNormalMode();
			view.EnableFileDependentControls();
		}

		private void LoadDataErrorCallback(Exception exception)
		{
			log.Error(exception);
			currentDataModel = null;

			var message = string.Format(Resources.DataLoadingFailedMessage, exception.Message);
			view.ShowError(message);
			view.SetStatus(Resources.ReadyStatus);
			view.GoToNormalMode();
		}

		private void ClearRecentFilesSuccessCallback()
		{
			view.ClearRecentFiles();
			view.SetStatus(Resources.ReadyStatus);
			view.GoToNormalMode();
		}

		private void ClearRecentFilesErrorCallback(Exception exception)
		{
			log.Error(exception);

			var message = string.Format(InternalResources.FailedToClearRecentFilesList, exception.Message);
			view.ShowError(message);
			view.SetStatus(Resources.ReadyStatus);
			view.GoToNormalMode();
		}

		private void ExportDataToFileSuccessCallback()
		{
			log.Info(InternalResources.ExportToFileWasFinishedSuccessfully);

			view.ShowInformation(Resources.ExportToFileSucceededMessage);
			view.SetStatus(Resources.ReadyStatus);
			view.GoToNormalMode();
		}

		private void ExportDataToFileErrorCallback(Exception exception)
		{
			log.Error(exception);

			var message = string.Format(Resources.ExportToFileFailedMessage, exception.Message);
			view.ShowError(message);
			view.SetStatus(Resources.ReadyStatus);
			view.GoToNormalMode();
		}

		private void ExportToExcelSuccessCallback()
		{
			log.Info(InternalResources.ExportToExcelWasFinishedSuccessfully);
			view.SetStatus(Resources.ReadyStatus);
			view.GoToNormalMode();
		}

		private void ExportToExcelErrorCallback(Exception exception)
		{
			log.Error(exception);

			var message = string.Format(Resources.ExportToExcelFailedMessage, exception.Message);
			view.ShowError(message);
			view.SetStatus(Resources.ReadyStatus);
			view.GoToNormalMode();
		}

		#endregion Service callbacks

		#region Helpers

		private static IEnumerable<ScaleDto> GetScaleDtos(IEnumerable<int> scales)
		{
			var dtos = new List<ScaleDto>();
			foreach (var scale in scales)
			{
				var dto = new ScaleDto(scale);
				dtos.Add(dto);
			}

			return dtos;
		}

		private void OpenDragDroppedFile(string filePath)
		{
			view.Activate();
			OnOpenFile(filePath);
		}

		private void ReloadFile()
		{
			var fullDataPropertiesDto = currentDataModel.GetFullDataPropertiesDto();

			log.InfoFormat(
				InternalResources.ReloadingFileWithDataPropertiesModel,
				currentDataModel.FilePath, fullDataPropertiesDto);
			LoadFile(currentDataModel.FilePath, fullDataPropertiesDto);
		}

		private void LoadFile(string filePath, CoreDataPropertiesDto coreDataPropertiesDto)
		{
			var fullDataPropertiesDto = new FullDataPropertiesDto(coreDataPropertiesDto);
			LoadFile(filePath, fullDataPropertiesDto);
		}

		private void LoadFile(string filePath, FullDataPropertiesDto fullDataPropertiesDto)
		{
			view.SetStatus(Resources.LoadingFileStatus);
			view.GoToWaitMode();

			var updateRecentFilesTask = taskService.CreateTask(
				() =>
				{
					recentFilesService.AddFile(filePath);
					return recentFilesService.GetRecentFiles();
				})
				.RunOnSuccess(recentFiles => view.SetRecentFiles(recentFiles))
				.RunOnError(exception =>
				            {
				            	log.Error(exception);
				            	var message = string.Format(Resources.FailedToUpdateRecentFilesList, exception.Message);
				            	view.ShowError(message);
				            });
			taskService.CreateTask(
				() => dataService.LoadData(filePath, fullDataPropertiesDto))
				.WithContinuation(updateRecentFilesTask)
				.RunOnSuccess(LoadDataSuccessCallback)
				.RunOnError(LoadDataErrorCallback)
				.Start();
		}

		private static SettingsDto GetSettingsDto(SettingsStorage storage)
		{
			return new SettingsDto(
				storage.MaxAbsoluteScalePower, storage.ExportValuesSeparator,
				storage.RecentFilesCount, storage.RegisteredExtensions, storage.Language);
		}

		private static SettingsStorage GetSettingsStorage(SettingsDto dto)
		{
			return new SettingsStorage(
				dto.MaxAbsoluteScalePower, dto.ExportValuesSeparator,
				dto.RecentFilesCount, dto.RegisteredExtensions, dto.Language);
		}

		#endregion Helpers
	}
}