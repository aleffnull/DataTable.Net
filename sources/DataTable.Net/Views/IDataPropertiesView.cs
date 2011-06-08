using System.Collections.Generic;
using DataTable.Net.Dtos;
using DataTable.Net.Models;

namespace DataTable.Net.Views
{
	public interface IDataPropertiesView
	{
		int NumberOfArguments { get; set; }
		int NumberOfFunctions { get; set; }
		DataType ArgumentsType { get; set; }
		DataType FunctionsType { get; set; }
		ArithmeticType ArithmeticType { get; set; }

		void SetNumberOfArgumentsList(IEnumerable<NumberOfItemsDto> argumentNumbers);
		void SetNumberOfFunctionsList(IEnumerable<NumberOfItemsDto> functionNumbers);
		void SetArgumentsTypeList(IEnumerable<DataTypeDto> argumentTypes);
		void SetFunctionsTypeList(IEnumerable<DataTypeDto> functionTypes);
		void SetArithmeticTypeList(IEnumerable<ArithmeticTypeDto> arithmeticTypes);
	}
}