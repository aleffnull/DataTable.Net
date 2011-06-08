using System.IO;
using DataTable.Net.Dtos;
using DataTable.Net.Models;
using DataTable.Net.Services;
using DataTable.Net.Services.Common;
using DataTable.Net.Services.Impl;
using NUnit.Framework;

namespace DataTable.Net.Tests
{
	[TestFixture]
	public class DataServiceFixture
	{
		#region Fields

		private ServiceLocator serviceLocator;
		private IDataService dataService;

		#endregion Fields

		#region TestFixtureSetUp

		[TestFixtureSetUp]
		public void SetUp()
		{
			serviceLocator = new ServiceLocator();
			dataService = new DataService(serviceLocator);
		}

		#endregion TestFixtureSetUp

		#region Tests

		[Test]
		public void LoadData_EmptyStream()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 0, DataType.Byte, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			using (var stream = new MemoryStream())
			{
				dataService.LoadData(stream, model);
			}
		}

		[Test]
		public void LoadData_OneByteArgument_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(1, 0, DataType.Byte, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("42"));
		}

		[Test]
		public void LoadData_OneByteArgument_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(1, 0, DataType.Byte, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x54};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("42"));
			Assert.That(model.GetMachineArgument(0, 1), Is.EqualTo("54"));
		}

		[Test]
		public void LoadData_OneWordArgument_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(1, 0, DataType.Word, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x35};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("3542"));
		}

		[Test]
		public void LoadData_OneWordArgument_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(1, 0, DataType.Word, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x35, 0x12, 0x78};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("3542"));
			Assert.That(model.GetMachineArgument(0, 1), Is.EqualTo("7812"));
		}

		[Test]
		public void LoadData_OneDwordArgument_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(1, 0, DataType.Dword, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x35, 0xAB, 0xCD};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("CDAB3542"));
		}

		[Test]
		public void LoadData_OneDwordArgument_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(1, 0, DataType.Dword, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x35, 0xAB, 0xCD, 0x01, 0x23, 0x45, 0x67};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("CDAB3542"));
			Assert.That(model.GetMachineArgument(0, 1), Is.EqualTo("67452301"));
		}

		[Test]
		public void LoadData_OneByteFunction_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 1, DataType.Byte, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("42"));
		}

		[Test]
		public void LoadData_OneByteFunction_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 1, DataType.Byte, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x54};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("42"));
			Assert.That(model.GetMachineFunction(0, 1), Is.EqualTo("54"));
		}

		[Test]
		public void LoadData_OneWordFunction_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 1, DataType.Byte, DataType.Word, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x35};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("3542"));
		}

		[Test]
		public void LoadData_OneWordFunction_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 1, DataType.Byte, DataType.Word, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x35, 0x12, 0x78};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("3542"));
			Assert.That(model.GetMachineFunction(0, 1), Is.EqualTo("7812"));
		}

		[Test]
		public void LoadData_OneDwordFunction_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 1, DataType.Byte, DataType.Dword, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x35, 0xAB, 0xCD};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("CDAB3542"));
		}

		[Test]
		public void LoadData_OneDwordFunction_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 1, DataType.Byte, DataType.Dword, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x35, 0xAB, 0xCD, 0x01, 0x23, 0x45, 0x67};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("CDAB3542"));
			Assert.That(model.GetMachineFunction(0, 1), Is.EqualTo("67452301"));
		}

		[Test]
		public void LoadData_TwoByteArguments_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(2, 0, DataType.Byte, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x34};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("42"));
			Assert.That(model.GetMachineArgument(1, 0), Is.EqualTo("34"));
		}

		[Test]
		public void LoadData_TwoByteArguments_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(2, 0, DataType.Byte, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x54, 0x12, 0x34};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("42"));
			Assert.That(model.GetMachineArgument(1, 0), Is.EqualTo("54"));
			Assert.That(model.GetMachineArgument(0, 1), Is.EqualTo("12"));
			Assert.That(model.GetMachineArgument(1, 1), Is.EqualTo("34"));
		}

		[Test]
		public void LoadData_TwoWordArguments_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(2, 0, DataType.Word, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x54, 0x12, 0x34};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("5442"));
			Assert.That(model.GetMachineArgument(1, 0), Is.EqualTo("3412"));
		}

		[Test]
		public void LoadData_TwoWordArguments_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(2, 0, DataType.Word, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x54, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("5442"));
			Assert.That(model.GetMachineArgument(1, 0), Is.EqualTo("3412"));
			Assert.That(model.GetMachineArgument(0, 1), Is.EqualTo("7856"));
			Assert.That(model.GetMachineArgument(1, 1), Is.EqualTo("BC9A"));
		}

		[Test]
		public void LoadData_TwoDwordArguments_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(2, 0, DataType.Dword, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x54, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("34125442"));
			Assert.That(model.GetMachineArgument(1, 0), Is.EqualTo("BC9A7856"));
		}

		[Test]
		public void LoadData_TwoDwordArguments_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(2, 0, DataType.Dword, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[]
			           {0x42, 0x54, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFF, 0x00, 0x11, 0x22, 0x33, 0x44, 0x55};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineArgument(0, 0), Is.EqualTo("34125442"));
			Assert.That(model.GetMachineArgument(1, 0), Is.EqualTo("BC9A7856"));
			Assert.That(model.GetMachineArgument(0, 1), Is.EqualTo("1100FFDE"));
			Assert.That(model.GetMachineArgument(1, 1), Is.EqualTo("55443322"));
		}

		[Test]
		public void LoadData_TwoByteFunctions_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 2, DataType.Byte, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x34};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("42"));
			Assert.That(model.GetMachineFunction(1, 0), Is.EqualTo("34"));
		}

		[Test]
		public void LoadData_TwoByteFunctions_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 2, DataType.Byte, DataType.Byte, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x54, 0x12, 0x34};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("42"));
			Assert.That(model.GetMachineFunction(1, 0), Is.EqualTo("54"));
			Assert.That(model.GetMachineFunction(0, 1), Is.EqualTo("12"));
			Assert.That(model.GetMachineFunction(1, 1), Is.EqualTo("34"));
		}

		[Test]
		public void LoadData_TwoWordFunctions_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 2, DataType.Byte, DataType.Word, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x54, 0x12, 0x34};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("5442"));
			Assert.That(model.GetMachineFunction(1, 0), Is.EqualTo("3412"));
		}

		[Test]
		public void LoadData_TwoWordFunctions_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 2, DataType.Byte, DataType.Word, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x54, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("5442"));
			Assert.That(model.GetMachineFunction(1, 0), Is.EqualTo("3412"));
			Assert.That(model.GetMachineFunction(0, 1), Is.EqualTo("7856"));
			Assert.That(model.GetMachineFunction(1, 1), Is.EqualTo("BC9A"));
		}

		[Test]
		public void LoadData_TwoDwordFunction_OneDataEntry()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 2, DataType.Byte, DataType.Dword, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[] {0x42, 0x54, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(1));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("34125442"));
			Assert.That(model.GetMachineFunction(1, 0), Is.EqualTo("BC9A7856"));
		}

		[Test]
		public void LoadData_TwoDwordFunctions_TwoDataEntries()
		{
			var dataPropertiesDto = new DataPropertiesDto(0, 2, DataType.Byte, DataType.Dword, ArithmeticType.Integer);
			var model = new DataModel(string.Empty, dataPropertiesDto, serviceLocator);
			var data = new byte[]
			           {0x42, 0x54, 0x12, 0x34, 0x56, 0x78, 0x9A, 0xBC, 0xDE, 0xFF, 0x00, 0x11, 0x22, 0x33, 0x44, 0x55};
			using (var stream = new MemoryStream(data))
			{
				dataService.LoadData(stream, model);
			}

			Assert.That(model.DataEntriesCount, Is.EqualTo(2));
			Assert.That(model.GetMachineFunction(0, 0), Is.EqualTo("34125442"));
			Assert.That(model.GetMachineFunction(1, 0), Is.EqualTo("BC9A7856"));
			Assert.That(model.GetMachineFunction(0, 1), Is.EqualTo("1100FFDE"));
			Assert.That(model.GetMachineFunction(1, 1), Is.EqualTo("55443322"));
		}

		#endregion Tests
	}
}