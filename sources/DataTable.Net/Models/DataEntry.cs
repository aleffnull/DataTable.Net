namespace DataTable.Net.Models
{
	public class DataEntry
	{
		#region Properties

		public byte[][] Arguments { get; private set; }
		public byte[][] Functions { get; private set; }

		#endregion Properties

		#region Constructors

		public DataEntry(byte[][] arguments, byte[][] functions)
		{
			Arguments = arguments;
			Functions = functions;
		}

		#endregion Constructors
	}
}