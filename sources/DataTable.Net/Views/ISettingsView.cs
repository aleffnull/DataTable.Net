using System.Collections.Generic;

namespace DataTable.Net.Views
{
	internal interface ISettingsView
	{
		int MaxAbsoluteScalePower { get; set; }
		string ExportValuesSeparator { get; set; }
		int RecentFilesCount { get; set; }

		void AddExtension(string extension);
		void ToogleExtension(string extension, bool selected);
		IEnumerable<string> GetSelectedExtensions();
		void SelectAllExtensions();
	}
}