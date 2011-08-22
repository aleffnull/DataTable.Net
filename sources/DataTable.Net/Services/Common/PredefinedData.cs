using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using DataTable.Net.Models;
using DataTable.Net.Properties;

namespace DataTable.Net.Services.Common
{
	public static class PredefinedData
	{
		#region Fields

		private static readonly string programExecutable;
		private static readonly string fileIcon;
		private static readonly List<string> supportedExtensions = new List<string>();
		private static readonly List<Language> supportedLanguages = new List<Language>();

		#endregion Fields

		#region Properties

		public static string ProgramExecutable
		{
			get { return programExecutable; }
		}

		public static string FileIcon
		{
			get { return fileIcon; }
		}

		public static IEnumerable<string> SupportedExtensions
		{
			get { return supportedExtensions; }
		}

		public static IEnumerable<Language> SupportedLanguages
		{
			get { return supportedLanguages; }
		}

		#endregion Properties

		#region Constructors

		static PredefinedData()
		{
			programExecutable = Assembly.GetExecutingAssembly().Location;
			fileIcon = Path.Combine(Path.GetDirectoryName(programExecutable) ?? string.Empty, InternalResources.FileIcon);

			supportedExtensions.Add(InternalResources.BinExtension);
			supportedExtensions.Add(InternalResources.DatExtension);
			supportedExtensions.Add(InternalResources.HexExtension);

			supportedLanguages.Add(
				new Language(LanguageType.Russian, InternalResources.RussianLanguage, new CultureInfo(InternalResources.RussianCultureInfo)));
			supportedLanguages.Add(
				new Language(LanguageType.English, InternalResources.EnglishLanguage, new CultureInfo(InternalResources.EnglishCultureInfo)));
		}

		#endregion Constructors
	}
}