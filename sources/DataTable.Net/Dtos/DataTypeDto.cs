using DataTable.Net.Models;

namespace DataTable.Net.Dtos
{
	public class DataTypeDto
	{
		#region Properties

		public DataType DataType { get; set; }

		#endregion Properties

		#region Object overrides

		public override string ToString()
		{
			return DataType.ToString();
		}

		#endregion Object overrides
	}
}