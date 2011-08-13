using System.Globalization;
using DataTable.Net.Models;
using DataTable.Net.Properties;

namespace DataTable.Net.Dtos
{
	public class FullDataPropertiesDto
	{
		#region Properties

		public int NumberOfArguments { get; private set; }
		public int NumberOfFunctions { get; private set; }
		public DataType ArgumentsType { get; private set; }
		public DataType FunctionsType { get; private set; }
		public ArithmeticType ArithmeticType { get; private set; }

		public int[] ArgumentScales { get; private set; }
		public int[] FunctionScales { get; private set; }

		#endregion Properties

		#region Constructors

		public FullDataPropertiesDto(CoreDataPropertiesDto coreDto)
		{
			NumberOfArguments = coreDto.NumberOfArguments;
			NumberOfFunctions = coreDto.NumberOfFunctions;
			ArgumentsType = coreDto.ArgumentsType;
			FunctionsType = coreDto.FunctionsType;
			ArithmeticType = coreDto.ArithmeticType;
		}

		public FullDataPropertiesDto(
			int numberOfArguments, int numberOfFunctions,
			DataType argumentsType, DataType functionsType, ArithmeticType arithmeticType,
			int[] argumentScales, int[] functionScales)
		{
			NumberOfArguments = numberOfArguments;
			NumberOfFunctions = numberOfFunctions;
			ArgumentsType = argumentsType;
			FunctionsType = functionsType;
			ArithmeticType = arithmeticType;

			ArgumentScales = new int[argumentScales.Length];
			argumentScales.CopyTo(ArgumentScales, 0);
			FunctionScales = new int[functionScales.Length];
			functionScales.CopyTo(FunctionScales, 0);
		}

		#endregion Constructors

		#region Object overrides

		public override string ToString()
		{
			if (ArgumentScales != null && FunctionScales != null)
			{
				var argumentScalesStringArray = new string[ArgumentScales.Length];
				for (var i = 0; i < ArgumentScales.Length; i++ )
				{
					argumentScalesStringArray[i] = ArgumentScales[i].ToString(CultureInfo.CurrentCulture);
				}
				var argumentScalesString = string.Join(", ", argumentScalesStringArray);

				var functionScalesStringArray = new string[FunctionScales.Length];
				for (var i = 0; i < FunctionScales.Length; i++)
				{
					functionScalesStringArray[i] = FunctionScales[i].ToString(CultureInfo.CurrentCulture);
				}
				var fucntionScalesString = string.Join(", ", functionScalesStringArray);

				return string.Format(
					InternalResources.DataPropertiesDtoScalesToStringFormat,
					NumberOfArguments, NumberOfFunctions, ArgumentsType, FunctionsType, ArithmeticType,
					argumentScalesString, fucntionScalesString);
			}

			return string.Format(
				InternalResources.DataPropertiesDtoToStringFormat,
				NumberOfArguments, NumberOfFunctions, ArgumentsType, FunctionsType, ArithmeticType);
		}

		#endregion Object overrides
	}
}