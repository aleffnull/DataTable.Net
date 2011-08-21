using System.Globalization;

namespace DataTable.Net.Models
{
	public class Language
	{
		#region Properties

		public CultureInfo Culture { get; private set; }

		public string Name { get; private set; }

		#endregion Properties

		#region Constructors

		public Language(CultureInfo culture, string name)
		{
			Culture = culture;
			Name = name;
		}

		#endregion Constructors
	}
}