using System.Collections.Generic;
using System.Globalization;
using System.Text;
using DataTable.Net.Dtos;
using DataTable.Net.Properties;
using DataTable.Net.Services;

namespace DataTable.Net.Models
{
	public class DataModel
	{
		private readonly IMathService mathService;

		#region Fields

		private readonly List<DataEntry> dataEntries = new List<DataEntry>();
		private readonly DataPropertiesModel dataPropertiesModel;

		#endregion Fields

		#region Properties

		public int NumberOfArguments
		{
			get { return dataPropertiesModel.NumberOfArguments; }
		}

		public int NumberOfFunctions
		{
			get { return dataPropertiesModel.NumberOfFunctions; }
		}

		public DataType ArgumentsType
		{
			get { return dataPropertiesModel.ArgumentsType; }
		}

		public DataType FunctionsType
		{
			get { return dataPropertiesModel.FunctionsType; }
		}

		public string FilePath { get; private set; }

		public int DataEntriesCount
		{
			get { return dataEntries.Count; }
		}

		#endregion Properties

		#region Constructors

		public DataModel(string filePath, FullDataPropertiesDto fullDataPropertiesDto, IMathService mathService)
		{
			FilePath = filePath;
			dataPropertiesModel = GetDataPropertiesModel(fullDataPropertiesDto);
			this.mathService = mathService;
		}

		#endregion Constructors

		#region Methods

		public virtual void AddEntry(DataEntry dataEntry)
		{
			dataEntries.Add(dataEntry);
		}

		public IEnumerable<int> CreateArgumentScales(int maxAbsolutePower)
		{
			return dataPropertiesModel.CreateArgumentScales(maxAbsolutePower);
		}

		public int GetArgumentScale(int index)
		{
			return dataPropertiesModel.GetArgumentScale(index);
		}

		public virtual void SetArgumentScale(int index, int scale)
		{
			dataPropertiesModel.SetArgumentScale(index, scale);
		}

		public IEnumerable<int> CreateFunctionScales(int maxAbsolutePower)
		{
			return dataPropertiesModel.CreateFunctionScales(maxAbsolutePower);
		}

		public int GetFunctionScale(int index)
		{
			return dataPropertiesModel.GetFunctionScale(index);
		}

		public virtual void SetFunctionScale(int index, int scale)
		{
			dataPropertiesModel.SetFunctionScale(index, scale);
		}

		public virtual string GetMachineArgument(int index, int dataEntryIndex)
		{
			var rawArgumentValue = dataEntries[dataEntryIndex].Arguments[index];
			var value = ConvertByteArrayToString(rawArgumentValue);

			return value;
		}

		public virtual string GetMachineFunction(int index, int dataEntryIndex)
		{
			var rawArgumentValue = dataEntries[dataEntryIndex].Functions[index];
			var value = ConvertByteArrayToString(rawArgumentValue);

			return value;
		}

		public virtual decimal GetHumanArgument(int index, int dataEntryIndex)
		{
			var rawArgumentValue = dataEntries[dataEntryIndex].Arguments[index];
			var argument = mathService.GetValue(
				rawArgumentValue, dataPropertiesModel.ArithmeticType, dataPropertiesModel.GetArgumentScale(index));

			return argument;
		}

		public virtual decimal GetHumanFunction(int index, int dataEntryIndex)
		{
			var rawFunctionValue = dataEntries[dataEntryIndex].Functions[index];
			var function = mathService.GetValue(
				rawFunctionValue, dataPropertiesModel.ArithmeticType, dataPropertiesModel.GetFunctionScale(index));

			return function;
		}

		public CoreDataPropertiesDto GetCoreDataPropertiesDto()
		{
			return dataPropertiesModel.GetCoreDto();
		}

		public FullDataPropertiesDto GetFullDataPropertiesDto()
		{
			return dataPropertiesModel.GetFullDto();
		}

		#endregion Methods

		#region Helpers

		private static DataPropertiesModel GetDataPropertiesModel(FullDataPropertiesDto dto)
		{
			var model = new DataPropertiesModel(
				dto.NumberOfArguments, dto.NumberOfFunctions,
				dto.ArgumentsType, dto.FunctionsType, dto.ArithmeticType,
				dto.ArgumentScales, dto.FunctionScales);
			return model;
		}

		private static string ConvertByteArrayToString(IEnumerable<byte> bytes)
		{
			var stringBuilder = new StringBuilder();
			foreach (var oneByte in bytes)
			{
				stringBuilder.Insert(0, oneByte.ToString(InternalResources.ByteToHexFormat, CultureInfo.CurrentCulture));
			}

			return stringBuilder.ToString();
		}

		#endregion Helpers
	}
}