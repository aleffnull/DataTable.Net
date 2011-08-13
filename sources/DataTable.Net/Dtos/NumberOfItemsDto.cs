using System.Globalization;

namespace DataTable.Net.Dtos
{
	public class NumberOfItemsDto
	{
		#region Properties

		public int Count { get; set; }

		#endregion Properties

		#region Object overrides

		public override string ToString()
		{
			return Count.ToString(CultureInfo.CurrentCulture);
		}

		#endregion Object overrides
	}
}