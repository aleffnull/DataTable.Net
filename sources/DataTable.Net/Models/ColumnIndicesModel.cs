using System;
using System.Collections.Generic;

namespace DataTable.Net.Models
{
	public class ColumnIndicesModel
	{
		#region Fields

		private readonly List<int> machineArgumentIndices = new List<int>();
		private readonly List<int> machineFunctionIndices = new List<int>();
		private readonly List<int> humanArgumentIndices = new List<int>();
		private readonly List<int> humanFunctionIndices = new List<int>();

		#endregion Fields

		#region Methods

		public void Clear()
		{
			machineArgumentIndices.Clear();
			machineFunctionIndices.Clear();
			humanArgumentIndices.Clear();
			humanFunctionIndices.Clear();
		}

		public void AddMachineArgumentIndex(int index)
		{
			machineArgumentIndices.Add(index);
		}

		public void AddMachineFunctionIndex(int index)
		{
			machineFunctionIndices.Add(index);
		}

		public void AddHumanArgumentIndex(int index)
		{
			humanArgumentIndices.Add(index);
		}

		public void AddHumanFunctionIndex(int index)
		{
			humanFunctionIndices.Add(index);
		}

		public bool IsMachineArgumentIndex(int index)
		{
			return machineArgumentIndices.Contains(index);
		}

		public bool IsMachineFunctionIndex(int index)
		{
			return machineFunctionIndices.Contains(index);
		}

		public bool IsHumanArgumentIndex(int index)
		{
			return humanArgumentIndices.Contains(index);
		}

		public bool IsHumanFunctionIndex(int index)
		{
			return humanFunctionIndices.Contains(index);
		}

		public int GetMachineArgumentIndex(int columnIndex)
		{
			if (machineArgumentIndices.Contains(columnIndex))
			{
				return machineArgumentIndices.FindIndex(obj => obj == columnIndex);
			}

			throw new ArgumentException(string.Format("{0} is not a column index of machine value of argument", columnIndex));
		}

		public int GetMachineFunctionIndex(int columnIndex)
		{
			if (machineFunctionIndices.Contains(columnIndex))
			{
				return machineFunctionIndices.FindIndex(obj => obj == columnIndex);
			}

			throw new ArgumentException(string.Format("{0} is not a column index of machine value of function", columnIndex));
		}

		public int GetHumanArgumentIndex(int columnIndex)
		{
			if (humanArgumentIndices.Contains(columnIndex))
			{
				return humanArgumentIndices.FindIndex(obj => obj == columnIndex);
			}

			throw new ArgumentException(string.Format("{0} is not a column index of human value of argument", columnIndex));
		}

		public int GetHumanFunctionIndex(int columnIndex)
		{
			if (humanFunctionIndices.Contains(columnIndex))
			{
				return humanFunctionIndices.FindIndex(obj => obj == columnIndex);
			}

			throw new ArgumentException(string.Format("{0} is not a column index of human value of function", columnIndex));
		}

		#endregion Methods
	}
}