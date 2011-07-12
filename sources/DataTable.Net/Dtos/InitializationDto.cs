using System.Collections.Generic;
using DataTable.Net.Services.Common;

namespace DataTable.Net.Dtos
{
	public class InitializationDto
	{
		#region Properties

		public SettingsStorage Settings { get; private set; }
		public IEnumerable<RecentFileDto> RecentFiles { get; private set; }

		#endregion Properties

		#region Constructors

		public InitializationDto(SettingsStorage settings, IEnumerable<RecentFileDto> recentFiles)
		{
			Settings = settings;
			RecentFiles = recentFiles;
		}

		#endregion Constructors
	}
}