using System.Collections.Generic;
using DataTable.Net.Dtos;

namespace DataTable.Net.Services
{
	public interface IRecentFilesService
	{
		IEnumerable<RecentFileDto> GetRecentFiles();
		void AddFile(string filePath);

		void SetSize(int size);
	}
}