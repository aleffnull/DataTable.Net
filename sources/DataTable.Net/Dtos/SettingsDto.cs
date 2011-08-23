using System.Collections.Generic;
using DataTable.Net.Models;

namespace DataTable.Net.Dtos
{
	public class SettingsDto
	{
		#region Fields

		private readonly List<string> registeredExtensions = new List<string>();

		#endregion Fields

		#region Properties

		public int MaxAbsoluteScalePower { get; private set; }
		public string ExportValuesSeparator { get; private set; }
		public int RecentFilesCount { get; private set; }
		public Language Language { get; private set; }

		public IEnumerable<string> RegisteredExtensions
		{
			get { return registeredExtensions; }
		}

		#endregion Properties

		#region Constructors

		public SettingsDto(
			int maxAbsoluteScalePower, string exportValuesSeparator, int recentFilesCount,
			IEnumerable<string> registeredExtensions, Language language)
		{
			MaxAbsoluteScalePower = maxAbsoluteScalePower;
			ExportValuesSeparator = exportValuesSeparator;
			RecentFilesCount = recentFilesCount;
			Language = language;
			this.registeredExtensions.AddRange(registeredExtensions);
		}

		#endregion Constructors
	}
}