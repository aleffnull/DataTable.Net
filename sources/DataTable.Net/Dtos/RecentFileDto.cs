using DataTable.Net.Properties;

namespace DataTable.Net.Dtos
{
	public class RecentFileDto
	{
		#region Properties

		public string FileName { get; private set; }
		public string FullPath { get; private set; }

		#endregion Properties

		#region Constructors

		public RecentFileDto(string fileName, string fullPath)
		{
			FileName = fileName;
			FullPath = fullPath;
		}

		#endregion Constructors

		#region Object overrides

		public override string ToString()
		{
			return string.Format(InternalResources.RecentFileDtoToStringFormat, FileName, FullPath);
		}

		#endregion Object overrides
	}
}