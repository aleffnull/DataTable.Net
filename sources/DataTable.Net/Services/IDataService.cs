using System.IO;
using DataTable.Net.Dtos;
using DataTable.Net.Models;

namespace DataTable.Net.Services
{
	public interface IDataService
	{
		DataModel LoadData(string filePath, FullDataPropertiesDto fullDataPropertiesDto);
		void ExportDataToFile(string filePath, DataModel dataModel, string valuesSeparator);
		void ExportToExcel(DataModel dataModel);

		/// <summary>
		/// For testing.
		/// </summary>
		/// <param name="stream"></param>
		/// <param name="dataModel"></param>
		void LoadData(Stream stream, DataModel dataModel);
	}
}