using System.IO;
using DataTable.Net.Properties;

namespace DataTable.Net.Dtos
{
	public class RecentFileDto
	{
		#region Fields

		private readonly string fileName;
		private readonly string fullPath;

		#endregion Fields

		#region Properties

		public string FullPath
		{
			get { return fullPath; }
		}

		#endregion Properties

		#region Constructors

		public RecentFileDto(string fullFileName)
		{
			fullPath = fullFileName;
			fileName = Path.GetFileName(fullFileName);
		}

		#endregion Constructors

		#region Object overrides

		public override string ToString()
		{
			return string.Format(InternalResources.RecentFileDtoToStringFormat, fileName, fullPath);
		}

		#endregion Object overrides
	}
}