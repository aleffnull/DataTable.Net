using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using DataTable.Net.Dtos;
using DataTable.Net.Exceptions;
using DataTable.Net.Models;
using DataTable.Net.Properties;
using log4net;
using Microsoft.Office.Interop.Excel;

namespace DataTable.Net.Services.Impl
{
	public class DataService : IDataService
	{
		#region Fields

		private readonly ILog log = LogManager.GetLogger(typeof(DataService));
		private readonly IMathService mathService;

		#endregion Fields

		#region Constructors

		public DataService(IMathService mathService)
		{
			this.mathService = mathService;
		}

		#endregion Constructors

		#region IDataService implementation

		public DataModel LoadData(string filePath, FullDataPropertiesDto fullDataPropertiesDto)
		{
			if (!File.Exists(filePath))
			{
				log.ErrorFormat(InternalResources.FileDoesNotExist, filePath);
				throw new FileNotExistsException(filePath);
			}

			var dataModel = new CachingDataModel(filePath, fullDataPropertiesDto, mathService);
			using (var stream = File.OpenRead(filePath))
			{
				LoadDataImpl(stream, dataModel);
			}

			return dataModel;
		}

		public void ExportDataToFile(string filePath, DataModel dataModel, string valuesSeparator)
		{
			using (var streamWriter = File.CreateText(filePath))
			{
				Action<List<object>> dataLineAction =
					lineList =>
					{
						var lineStringList = new List<string>(lineList.Count);
						foreach (var obj in lineList)
						{
							if (obj is decimal)
							{
								var number = (decimal)obj;
								lineStringList.Add(number.ToString(CultureInfo.InstalledUICulture));
							}
							else
							{
								lineStringList.Add(obj.ToString());
							}
						}

						var line = string.Join(valuesSeparator, lineStringList.ToArray());
						streamWriter.WriteLine(line);
					};

				DoHeader(dataModel, dataLineAction);
				DoBody(dataModel, dataLineAction);
			}
		}

		public void ExportToExcel(DataModel dataModel)
		{
			var data = DoDataArray(dataModel);
			var excel = new Application { Visible = true };
			var workbook = excel.Workbooks.Add();
			var worksheet = (Worksheet)(workbook.Worksheets[1]);
			var range = worksheet.Range["A1"].Resize[data.GetLength(0), data.GetLength(1)];
			range.Value = data;
		}

		public void LoadData(Stream stream, DataModel dataModel)
		{
			LoadDataImpl(stream, dataModel);
		}

		#endregion IDataService implementation

		#region Helpers

		private void LoadDataImpl(Stream stream, DataModel dataModel)
		{
			if (dataModel.NumberOfArguments == 0 && dataModel.NumberOfFunctions == 0)
			{
				return;
			}

			var stopFlag = false;
			var argumentBuffer = CreateBuffer(dataModel.ArgumentsType);
			var functionBuffer = CreateBuffer(dataModel.FunctionsType);

			while (true)
			{
				var dataEntry = CreateDataEntry(dataModel);

				for (var i = 0; i < dataModel.NumberOfArguments; i++)
				{
					var readBytesCount = stream.Read(argumentBuffer, 0, argumentBuffer.Length);
					if (readBytesCount == 0)
					{
						stopFlag = true;
						break;
					}

					CheckBufferFilling(argumentBuffer, readBytesCount);
					argumentBuffer.CopyTo(dataEntry.Arguments[i], 0);
				}

				if (stopFlag)
				{
					break;
				}

				for (var i = 0; i < dataModel.NumberOfFunctions; i++)
				{
					var readBytesCount = stream.Read(functionBuffer, 0, functionBuffer.Length);
					if (readBytesCount == 0)
					{
						stopFlag = true;
						break;
					}

					CheckBufferFilling(functionBuffer, readBytesCount);
					functionBuffer.CopyTo(dataEntry.Functions[i], 0);
				}

				if (stopFlag)
				{
					break;
				}

				dataModel.AddEntry(dataEntry);
			}
		}

		private static int GetBufferLength(DataType dataType)
		{
			switch (dataType)
			{
				case DataType.Byte:
					return 1;
				case DataType.Word:
					return 2;
				case DataType.Dword:
					return 4;
				case DataType.Qword:
					return 8;
				default:
					throw new ArgumentException(string.Format(InternalResources.DataTypeUnknownMember, dataType));
			}
		}

		private static byte[] CreateBuffer(DataType dataType)
		{
			var bufferLength = GetBufferLength(dataType);
			return new byte[bufferLength];
		}

		private static DataEntry CreateDataEntry(DataModel dataModel)
		{
			var argumentBufferLength = GetBufferLength(dataModel.ArgumentsType);
			var functionBufferLength = GetBufferLength(dataModel.FunctionsType);

			var argumentsArray = new byte[dataModel.NumberOfArguments][];
			for (var i = 0; i < argumentsArray.Length; i++)
			{
				argumentsArray[i] = new byte[argumentBufferLength];
			}

			var functionsArray = new byte[dataModel.NumberOfFunctions][];
			for (var i = 0; i < functionsArray.Length; i++)
			{
				functionsArray[i] = new byte[functionBufferLength];
			}

			var dataEntry = new DataEntry(argumentsArray, functionsArray);

			return dataEntry;
		}

		private void CheckBufferFilling(ICollection<byte> argumentBuffer, int readBytesCount)
		{
			if (readBytesCount != argumentBuffer.Count)
			{
				log.ErrorFormat(InternalResources.InsufficientBytesRead, readBytesCount, argumentBuffer.Count);
				throw new ReadException(argumentBuffer.Count, readBytesCount);
			}
		}

		private static void DoHeader(DataModel dataModel, Action<List<object>> dataLineAction)
		{
			var lineList = new List<object>();

			for (var argumentIndex = 0; argumentIndex < dataModel.NumberOfArguments; argumentIndex++)
			{
				var columnName = dataModel.NumberOfArguments == 1
				                 	? InternalResources.MachineArgumentSingleColumnTitle
				                 	: string.Format(InternalResources.MachineArgumentMultipleColumnTitle, argumentIndex + 1);
				lineList.Add(columnName);
			}
			for (var functionIndex = 0; functionIndex < dataModel.NumberOfFunctions; functionIndex++)
			{
				var columnName = dataModel.NumberOfFunctions == 1
				           	? InternalResources.MachineFunctionSingleColumnTitle
				           	: string.Format(InternalResources.MachineFunctionMultipleColumnTitle, functionIndex + 1);
				lineList.Add(columnName);
			}
			for (var argumentIndex = 0; argumentIndex < dataModel.NumberOfArguments; argumentIndex++)
			{
				var columnName = dataModel.NumberOfArguments == 1
				           	? InternalResources.HumanArgumentSingleColumnTitle
				           	: string.Format(InternalResources.HumanArgumentMultipleColumnTitle, argumentIndex + 1);
				lineList.Add(columnName);
			}
			for (var functionIndex = 0; functionIndex < dataModel.NumberOfFunctions; functionIndex++)
			{
				var columnName = dataModel.NumberOfFunctions == 1
				           	? InternalResources.HumanFunctiontSingleColumnTitle
				           	: string.Format(InternalResources.HumanFunctionMultipleColumnTitle, functionIndex + 1);
				lineList.Add(columnName);
			}

			dataLineAction(lineList);
		}

		private static void DoBody(DataModel dataModel, Action<List<object>> dataLineAction)
		{
			var lineList = new List<object>();
			for (var dataEntryIndex = 0; dataEntryIndex < dataModel.DataEntriesCount; dataEntryIndex++)
			{
				for (var argumentIndex = 0; argumentIndex < dataModel.NumberOfArguments; argumentIndex++)
				{
					var value = dataModel.GetMachineArgument(argumentIndex, dataEntryIndex);
					lineList.Add(value);
				}
				for (var functionIndex = 0; functionIndex < dataModel.NumberOfFunctions; functionIndex++)
				{
					var value = dataModel.GetMachineFunction(functionIndex, dataEntryIndex);
					lineList.Add(value);
				}
				for (var argumentIndex = 0; argumentIndex < dataModel.NumberOfArguments; argumentIndex++)
				{
					var value = dataModel.GetHumanArgument(argumentIndex, dataEntryIndex);
					lineList.Add(value);
				}
				for (var functionIndex = 0; functionIndex < dataModel.NumberOfFunctions; functionIndex++)
				{
					var value = dataModel.GetHumanFunction(functionIndex, dataEntryIndex);
					lineList.Add(value);
				}
				dataLineAction(lineList);
				lineList.Clear();
			}
		}

		private static object[,] DoDataArray(DataModel dataModel)
		{
			var columnCount = 2 * dataModel.NumberOfArguments + 2 * dataModel.NumberOfFunctions;
			// All data plus header.
			var rowCount = dataModel.DataEntriesCount + 1;
			var data = new object[rowCount, columnCount];
			var currentRowIndex = 0;
			Action<List<object>> dataLineAction =
				lineList =>
				{
					if (lineList.Count != columnCount)
					{
						throw new ArgumentOutOfRangeException(
							string.Format(InternalResources.DataLineItemsCountDoesNotMatchColumnCount, lineList.Count, columnCount));
					}
					if (currentRowIndex >= rowCount)
					{
						throw new ArgumentOutOfRangeException(
							string.Format(InternalResources.CurrentRowIndexIsTooBigForRowCount, currentRowIndex, rowCount));
					}

					for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
					{
						data[currentRowIndex, columnIndex] = lineList[columnIndex];
					}
					currentRowIndex++;
				};

			DoHeader(dataModel, dataLineAction);
			DoBody(dataModel, dataLineAction);

			return data;
		}

		#endregion Helpers
	}
}