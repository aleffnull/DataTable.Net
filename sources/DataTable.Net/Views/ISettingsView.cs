using System.Collections.Generic;
using DataTable.Net.Dtos;

namespace DataTable.Net.Views
{
	internal interface ISettingsView
	{
		int MaxAbsoluteScalePower { get; set; }
		string ExportValuesSeparator { get; set; }
		int RecentFilesCount { get; set; }
		LanguageDto Language { get; set; }

		void AddExtension(string extension);
		void ToogleExtension(string extension, bool selected);
		IEnumerable<string> GetSelectedExtensions();
		void SelectAllExtensions();

		void AddLanguage(LanguageDto language);
	}
}