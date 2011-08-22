using DataTable.Net.Models;
using DataTable.Net.Properties;

namespace DataTable.Net.Dtos
{
	public class LanguageDto
	{
		#region Properties

		public Language Language { get; private set; }

		#endregion Properties

		#region Constructors

		public LanguageDto(Language language)
		{
			Language = language;
		}

		#endregion Constructors

		#region Object overrides

		public override string ToString()
		{
			return string.Format(InternalResources.LanguageDtoToStringFormat, Language.Name, Language.Culture);
		}

		#endregion Object overrides
	}
}