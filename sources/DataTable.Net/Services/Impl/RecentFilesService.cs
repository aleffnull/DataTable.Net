using System.Collections.Generic;
using System.IO;
using DataTable.Net.Dtos;
using DataTable.Net.Services.Common;

namespace DataTable.Net.Services.Impl
{
	public class RecentFilesService : IRecentFilesService
	{
		#region Fields

		private readonly FixedRegistryBuffer buffer = new FixedRegistryBuffer();

		#endregion Fields

		#region IRecentFilesService implementation

		public IEnumerable<RecentFileDto> GetRecentFiles()
		{
			return new List<RecentFileDto>();
		}

		public void AddFile(string filePath)
		{
			buffer.AddFile(filePath);
		}

		public void SetSize(int size)
		{
			buffer.SetSize(size);
		}

		#endregion IRecentFilesService implementation

		#region Helpers

		private static IEnumerable<RecentFileDto> GetRecentFileDtos(ICollection<string> files)
		{
			if (files.Count == 0)
			{
				return new List<RecentFileDto>();
			}

			var dtos = new List<RecentFileDto>();
			foreach (var file in files)
			{
				var fileName = Path.GetFileName(file);
				var dto = new RecentFileDto(fileName, file);
				dtos.Add(dto);
			}

			return dtos;
		}

		#endregion Helpers
	}
}