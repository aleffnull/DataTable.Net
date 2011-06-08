using DataTable.Net.Models;
using DataTable.Net.Properties;

namespace DataTable.Net.Dtos
{
	public class DataPropertiesDto
	{
		#region Properties

		public int NumberOfArguments { get; private set; }
		public int NumberOfFunctions { get; private set; }
		public DataType ArgumentsType { get; private set; }
		public DataType FunctionsType { get; private set; }
		public ArithmeticType ArithmeticType { get; private set; }

		#endregion Properties

		#region Constructors

		public DataPropertiesDto(
			int numberOfArguments, int numberOfFunctions,
			DataType argumentsType, DataType functionsType, ArithmeticType arithmeticType)
		{
			NumberOfArguments = numberOfArguments;
			NumberOfFunctions = numberOfFunctions;
			ArgumentsType = argumentsType;
			FunctionsType = functionsType;
			ArithmeticType = arithmeticType;
		}

		#endregion Constructors

		#region Object overrides

		public override string ToString()
		{
			return string.Format(
				InternalResources.DataPropertiesDtoToStringFormat,
				NumberOfArguments, NumberOfFunctions, ArgumentsType, FunctionsType, ArithmeticType);
		}

		#endregion Object overrides
	}
}