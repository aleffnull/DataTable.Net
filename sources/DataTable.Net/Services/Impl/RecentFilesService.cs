using System.Collections.Generic;
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

		public ICollection<RecentFileDto> GetRecentFiles()
		{
			var dtos = GetRecentFileDtos(buffer.Items);
			return dtos;
		}

		public void AddFile(string filePath)
		{
			buffer.AddItem(filePath);
		}

		public void Clear()
		{
			buffer.Clear();
		}

		public void SetSize(int size)
		{
			buffer.SetSize(size);
		}

		#endregion IRecentFilesService implementation

		#region Helpers

		private static ICollection<RecentFileDto> GetRecentFileDtos(IEnumerable<string> files)
		{
			var dtos = new List<RecentFileDto>();
			foreach (var file in files)
			{
				var dto = new RecentFileDto(file);
				dtos.Add(dto);
			}

			return dtos;
		}

		#endregion Helpers
	}
}