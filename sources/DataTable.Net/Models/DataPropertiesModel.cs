using System;
using System.Collections.Generic;
using DataTable.Net.Dtos;
using DataTable.Net.Properties;

namespace DataTable.Net.Models
{
	public class DataPropertiesModel
	{
		#region Fields

		private int numberOfArguments;
		private int numberOfFunctions;

		private int[] argumentScales;
		private int[] functionScales;

		private readonly bool argumentScalesInitialized;
		private readonly bool functionScalesInitialized;

		#endregion Fields

		#region Properties

		public int NumberOfArguments
		{
			get { return numberOfArguments; }
			private set
			{
				numberOfArguments = value;
				if (argumentScales == null)
				{
					argumentScales = new int[value];
				}
			}
		}

		public int NumberOfFunctions
		{
			get { return numberOfFunctions; }
			private set
			{
				numberOfFunctions = value;
				if (functionScales == null)
				{
					functionScales = new int[value];
				}
			}
		}

		public DataType ArgumentsType { get; private set; }
		public DataType FunctionsType { get; private set; }
		public ArithmeticType ArithmeticType { get; private set; }

		#endregion Properties

		#region Constructors

		public DataPropertiesModel(
			int numberOfArguments, int numberOfFunctions,
			DataType argumentsType, DataType functionsType, ArithmeticType arithmeticType,
			int[] argumentScales, int[] functionScales)
		{
			NumberOfArguments = numberOfArguments;
			NumberOfFunctions = numberOfFunctions;
			ArgumentsType = argumentsType;
			FunctionsType = functionsType;
			ArithmeticType = arithmeticType;

			if (argumentScales != null)
			{
				if (argumentScales.Length != numberOfArguments)
				{
					throw new ArgumentException(Resources.ArgumentScalesCountMismatch);
				}

				this.argumentScales = new int[argumentScales.Length];
				argumentScales.CopyTo(this.argumentScales, 0);
				argumentScalesInitialized = true;
			}

			if (functionScales != null)
			{
				if (functionScales.Length != numberOfFunctions)
				{
					throw new ArgumentException(Resources.FunctionScalesCountMismatch);
				}

				this.functionScales = new int[functionScales.Length];
				functionScales.CopyTo(this.functionScales, 0);
				functionScalesInitialized = true;
			}
		}

		#endregion Constructors

		#region Methods

		public IEnumerable<int> CreateArgumentScales(int maxAbsolutePower)
		{
			return CreateScales(argumentScales, argumentScalesInitialized, maxAbsolutePower);
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
			return CreateScales(functionScales, functionScalesInitialized, maxAbsolutePower);
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

		private static IEnumerable<int> CreateScales(IList<int> scalesArray, bool initialized, int maxAbsolutePower)
		{
			var newScales = GetScales(maxAbsolutePower);
			var reinitialize = false;
			if (initialized)
			{
				foreach (var scale in scalesArray)
				{
					if (Math.Abs(scale) > maxAbsolutePower)
					{
						reinitialize = true;
						break;
					}
				}
			}
			else
			{
				reinitialize = true;
			}

			if (reinitialize)
			{
				var middleScale = newScales[newScales.Count / 2];
				for (var i = 0; i < scalesArray.Count; i++)
				{
					scalesArray[i] = middleScale;
				}
			}

			return newScales;
		}

		#endregion Helpers
	}
}