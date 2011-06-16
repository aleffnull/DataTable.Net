using System;
using System.Collections.Generic;
using DataTable.Net.Dtos;
using DataTable.Net.Models;
using DataTable.Net.Views;

namespace DataTable.Net.Presenters.Impl
{
	public class DataPropertiesPresenter : IDataPropertiesPresenter
	{
		#region Fields

		private readonly IDataPropertiesView view;
		private readonly CoreDataPropertiesDto dtoToLoad;

		#endregion Fields

		#region Constructors

		public DataPropertiesPresenter(IDataPropertiesView view, CoreDataPropertiesDto dtoToLoad)
		{
			this.view = view;
			this.dtoToLoad = dtoToLoad;
		}

		#endregion Constructors

		#region IDataPropertiesPresenter implementation

		public CoreDataPropertiesDto GetDto()
		{
			var dto = new CoreDataPropertiesDto(
				view.NumberOfArguments, view.NumberOfFunctions,
				view.ArgumentsType, view.FunctionsType, view.ArithmeticType);
			return dto;
		}

		public void OnLoad()
		{
			FillNumberOfItemsLists();
			FillTypeLists();
			FillArithmeticTypeList();

			if (dtoToLoad != null)
			{
				LoadDto(dtoToLoad);
			}
		}

		#endregion IDataPropertiesPresenter implementation

		#region Helpers

		private void FillTypeLists()
		{
			var dataTypes = Enum.GetValues(typeof(DataType));
			var dataTypeDtos = new List<DataTypeDto>();
			foreach (var dataType in dataTypes)
			{
				dataTypeDtos.Add(new DataTypeDto {DataType = (DataType)dataType});
			}

			view.SetArgumentsTypeList(dataTypeDtos);
			view.SetFunctionsTypeList(dataTypeDtos);
		}

		private void FillNumberOfItemsLists()
		{
			var itemNumbers = new[] {1, 2, 3, 4};
			var numberOfItemsDtos = new List<NumberOfItemsDto>();
			foreach (var itemsNumber in itemNumbers)
			{
				numberOfItemsDtos.Add(new NumberOfItemsDto {Count = itemsNumber});
			}

			view.SetNumberOfArgumentsList(numberOfItemsDtos);
			view.SetNumberOfFunctionsList(numberOfItemsDtos);
		}

		private void FillArithmeticTypeList()
		{
			var arithmeticTypes = new[] {ArithmeticType.Integer, ArithmeticType.Fractional};
			var arithmeticTypeDtos = new List<ArithmeticTypeDto>();
			foreach (var arithmeticType in arithmeticTypes)
			{
				arithmeticTypeDtos.Add(new ArithmeticTypeDto {ArithmeticType = arithmeticType});
			}

			view.SetArithmeticTypeList(arithmeticTypeDtos);
		}
		
		private void LoadDto(CoreDataPropertiesDto dto)
		{
			view.NumberOfArguments = dto.NumberOfArguments;
			view.NumberOfFunctions = dto.NumberOfFunctions;
			view.ArgumentsType = dto.ArgumentsType;
			view.FunctionsType = dto.FunctionsType;
			view.ArithmeticType = dto.ArithmeticType;
		}

		#endregion Helpers
	}
}