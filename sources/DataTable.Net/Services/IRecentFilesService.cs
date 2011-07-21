using System.Collections.Generic;
using DataTable.Net.Dtos;

namespace DataTable.Net.Services
{
	public interface IRecentFilesService
	{
		ICollection<RecentFileDto> GetRecentFiles();
		void AddFile(string filePath);
		void Clear();

		void SetSize(int size);
	}
}