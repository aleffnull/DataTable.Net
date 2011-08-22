using System.Globalization;

namespace DataTable.Net.Models
{
	public class Language
	{
		#region Properties

		public LanguageType Type { get; private set; }
		public string Name { get; private set; }
		public CultureInfo Culture { get; private set; }

		#endregion Properties

		#region Constructors

		public Language(LanguageType type, string name, CultureInfo culture)
		{
			Type = type;
			Name = name;
			Culture = culture;
		}

		#endregion Constructors
	}
}