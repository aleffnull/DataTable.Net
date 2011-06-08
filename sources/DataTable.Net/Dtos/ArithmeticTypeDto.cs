using System;
using DataTable.Net.Models;
using DataTable.Net.Properties;

namespace DataTable.Net.Dtos
{
	public class ArithmeticTypeDto
	{
		#region Properties

		public ArithmeticType ArithmeticType { get; set; }

		#endregion Properties

		#region Object overrides

		public override string ToString()
		{
			switch (ArithmeticType)
			{
				case ArithmeticType.Integer:
					return Resources.ArithmeticTypeInteger;
				case ArithmeticType.Fractional:
					return Resources.ArithmeticTypeFractional;
				default:
					throw new ArgumentException(string.Format(InternalResources.ArithmeticTypeUnknownMember, ArithmeticType));
			}
		}

		#endregion Object overrides
	}
}