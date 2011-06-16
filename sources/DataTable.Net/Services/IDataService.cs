using System.IO;
using DataTable.Net.Dtos;
using DataTable.Net.Models;
using DataTable.Net.Services.Common;

namespace DataTable.Net.Services
{
	public interface IDataService
	{
		void BeginLoadingData(
			string filePath, FullDataPropertiesDto fullDataPropertiesDto,
			ServiceSuccessCallback<DataModel> successCallback, ServiceErrorCallback errorCallback);

		void BeginExportingDataToFile(
			string filePath, DataModel dataModel, string valuesSeparator,
			ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback);

		void BeginExportingDataToExcel(
			DataModel dataModel,
			ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback);

		/// <summary>
		/// For testing.
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="dataModel"></param>
		void LoadData(Stream stream, DataModel dataModel);
	}
}