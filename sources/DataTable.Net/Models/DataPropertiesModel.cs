using System.Collections.Generic;
using DataTable.Net.Dtos;

namespace DataTable.Net.Models
{
	public class DataPropertiesModel
	{
		#region Fields

		private int numberOfArguments;
		private int numberOfFunctions;

		private int[] argumentScales;
		private int[] functionScales;

		#endregion Fields

		#region Properties

		public int NumberOfArguments
		{
			get { return numberOfArguments; }
			private set
			{
				numberOfArguments = value;
				argumentScales = new int[value];
			}
		}

		public int NumberOfFunctions
		{
			get { return numberOfFunctions; }
			private set
			{
				numberOfFunctions = value;
				functionScales = new int[value];
			}
		}

		public DataType ArgumentsType { get; private set; }
		public DataType FunctionsType { get; private set; }
		public ArithmeticType ArithmeticType { get; private set; }

		#endregion Properties

		#region Constructors

		public DataPropertiesModel(
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

		#region Methods

		public IEnumerable<int> CreateArgumentScales(int maxAbsolutePower)
		{
			var scales = GetScales(maxAbsolutePower);
			var middleScale = scales[scales.Count/2];
			for (var i = 0; i < argumentScales.Length; i++)
			{
				argumentScales[i] = middleScale;
			}

			return scales;
		}

		public int GetArgumentScale(int index)
		{
			return argumentScales[index];
		}

		public void SetArgumentScale(int index, int scale)
		{
			argumentScales[index] = scale;
		}

		public IEnumerable<int> CreateFunctionScales(int maxAbsolutePower)
		{
			var scales = GetScales(maxAbsolutePower);
			var middleScale = scales[scales.Count / 2];
			for (var i = 0; i < functionScales.Length; i++)
			{
				functionScales[i] = middleScale;
			}

			return scales;
		}

		public int GetFunctionScale(int index)
		{
			return functionScales[index];
		}

		public void SetFunctionScale(int index, int scale)
		{
			functionScales[index] = scale;
		}

		public CoreDataPropertiesDto GetCoreDto()
		{
			var dto = new CoreDataPropertiesDto(
				NumberOfArguments, NumberOfFunctions,
				ArgumentsType, FunctionsType, ArithmeticType);
			return dto;
		}

		public FullDataPropertiesDto GetFullDto()
		{
			var dto = new FullDataPropertiesDto(
				NumberOfArguments, NumberOfFunctions,
				ArgumentsType, FunctionsType, ArithmeticType,
				argumentScales, functionScales);
			return dto;
		}

		#endregion Methods

		#region Helpers

		private static List<int> GetScales(int maxAbsolutePower)
		{
			var scales = new List<int>();
			for (var scale = -maxAbsolutePower; scale < maxAbsolutePower + 1; scale++)
			{
				scales.Add(scale);
			}

			return scales;
		}

		#endregion Helpers
	}
}