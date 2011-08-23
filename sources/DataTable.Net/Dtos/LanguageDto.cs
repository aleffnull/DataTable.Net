using System;
using DataTable.Net.Models;
using DataTable.Net.Properties;

namespace DataTable.Net.Dtos
{
	public class LanguageDto : IEquatable<LanguageDto>
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

		#region IEquatable implementation

		public bool Equals(LanguageDto other)
		{
			return other != null && other.Language.Equals(Language);
		}

		#endregion IEquatable implementation

		#region Object overrides

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}
			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			return Equals((LanguageDto)obj);
		}

		public override int GetHashCode()
		{
			return (Language == null ? 0 : Language.GetHashCode());
		}

		public override string ToString()
		{
			return string.Format(InternalResources.LanguageDtoToStringFormat, Language.Name, Language.Culture);
		}

		#endregion Object overrides
	}
}