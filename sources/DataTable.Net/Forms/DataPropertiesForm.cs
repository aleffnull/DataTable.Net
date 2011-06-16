using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataTable.Net.Dtos;
using DataTable.Net.Models;
using DataTable.Net.Presenters;
using DataTable.Net.Presenters.Impl;
using DataTable.Net.Views;

namespace DataTable.Net.Forms
{
	public partial class DataPropertiesForm : Form, IDataPropertiesView
	{
		#region Fields

		private readonly IDataPropertiesPresenter presenter;

		#endregion Fields

		#region Constructors

		public DataPropertiesForm(CoreDataPropertiesDto coreDataPropertiesDto)
		{
			InitializeComponent();
			presenter = new DataPropertiesPresenter(this, coreDataPropertiesDto);
		}

		#endregion Constructors

		#region IDataPropertiesView implementation

		int IDataPropertiesView.NumberOfArguments
		{
			get { return ((NumberOfItemsDto)NumberOfArgumentsComboBox.SelectedItem).Count; }
			set
			{
				foreach (var item in NumberOfArgumentsComboBox.Items)
				{
					var dto = (NumberOfItemsDto)item;
					if (dto.Count == value)
					{
						NumberOfArgumentsComboBox.SelectedItem = item;
						break;
					}
				}
			}
		}

		int IDataPropertiesView.NumberOfFunctions
		{
			get { return ((NumberOfItemsDto)NumberOfFuntionsComboBox.SelectedItem).Count; }
			set
			{
				foreach (var item in NumberOfFuntionsComboBox.Items)
				{
					var dto = (NumberOfItemsDto)item;
					if (dto.Count == value)
					{
						NumberOfFuntionsComboBox.SelectedItem = item;
						break;
					}
				}
			}
		}

		DataType IDataPropertiesView.ArgumentsType
		{
			get { return ((DataTypeDto)ArgumentsTypeComboBox.SelectedItem).DataType; }
			set
			{
				foreach (var item in ArgumentsTypeComboBox.Items)
				{
					var dto = (DataTypeDto)item;
					if (dto.DataType == value)
					{
						ArgumentsTypeComboBox.SelectedItem = item;
						break;
					}
				}
			}
		}

		DataType IDataPropertiesView.FunctionsType
		{
			get { return ((DataTypeDto)FunctionsTypeComboBox.SelectedItem).DataType; }
			set
			{
				foreach (var item in FunctionsTypeComboBox.Items)
				{
					var dto = (DataTypeDto)item;
					if (dto.DataType == value)
					{
						FunctionsTypeComboBox.SelectedItem = item;
						break;
					}
				}
			}
		}

		ArithmeticType IDataPropertiesView.ArithmeticType
		{
			get { return ((ArithmeticTypeDto)ArithmeticTypeComboBox.SelectedItem).ArithmeticType; }
			set
			{
				foreach (var item in ArithmeticTypeComboBox.Items)
				{
					var dto = (ArithmeticTypeDto)item;
					if (dto.ArithmeticType == value)
					{
						ArithmeticTypeComboBox.SelectedItem = item;
						break;
					}
				}
			}
		}

		void IDataPropertiesView.SetNumberOfArgumentsList(IEnumerable<NumberOfItemsDto> argumentNumbers)
		{
			FillComboBox(NumberOfArgumentsComboBox, argumentNumbers);
		}

		void IDataPropertiesView.SetNumberOfFunctionsList(IEnumerable<NumberOfItemsDto> functionNumbers)
		{
			FillComboBox(NumberOfFuntionsComboBox, functionNumbers);
		}

		void IDataPropertiesView.SetArgumentsTypeList(IEnumerable<DataTypeDto> argumentTypes)
		{
			FillComboBox(ArgumentsTypeComboBox, argumentTypes);
		}

		void IDataPropertiesView.SetFunctionsTypeList(IEnumerable<DataTypeDto> functionTypes)
		{
			FillComboBox(FunctionsTypeComboBox, functionTypes);
		}

		void IDataPropertiesView.SetArithmeticTypeList(IEnumerable<ArithmeticTypeDto> arithmeticTypes)
		{
			FillComboBox(ArithmeticTypeComboBox, arithmeticTypes);
		}

		#endregion IDataPropertiesView implementation

		#region Methods

		public CoreDataPropertiesDto GetCoreDataPropertiesDto()
		{
			return presenter.GetDto();
		}

		#endregion Methods

		#region Event handlers

		private void DataPropertiesForm_Load(object sender, EventArgs e)
		{
			presenter.OnLoad();
		}

		#endregion Event handlers

		#region Helpers

		private static void FillComboBox<T>(ComboBox comboBox, IEnumerable<T> items)
		{
			comboBox.BeginUpdate();
			comboBox.Items.Clear();

			foreach (var dto in items)
			{
				comboBox.Items.Add(dto);
			}

			comboBox.SelectedIndex = 0;
			comboBox.EndUpdate();
		}

		#endregion Helpers
	}
}
