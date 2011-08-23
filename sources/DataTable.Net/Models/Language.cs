using System;
using System.Globalization;

namespace DataTable.Net.Models
{
	public class Language : IEquatable<Language>
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

		#region IEquatable implementation

		public bool Equals(Language other)
		{
			return other != null && (Type == other.Type && Name.Equals(other.Name) && Culture.Equals(other.Culture));
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

			return Equals((Language)obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var result = Type.GetHashCode();
				result = (result * 397) ^ (Name != null ? Name.GetHashCode() : 0);
				result = (result * 397) ^ (Culture != null ? Culture.GetHashCode() : 0);
				return result;
			}
		}

		public override string ToString()
		{
			return Culture.ToString();
		}

		#endregion Object overrides
	}
}