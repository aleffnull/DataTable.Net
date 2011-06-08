namespace DataTable.Net.Models
{
	public class CacheLine
	{
		#region Fields

		private readonly string[] machineArguments;
		private readonly string[] machineFunctions;
		private readonly decimal?[] humanArguments;
		private readonly decimal?[] humanFunctions;

		#endregion Fields

		#region Constructors

		public CacheLine(int numberOfArguments, int numberOfFunctions)
		{
			machineArguments = new string[numberOfArguments];
			machineFunctions = new string[numberOfFunctions];
			humanArguments = new decimal?[numberOfArguments];
			humanFunctions = new decimal?[numberOfFunctions];
		}

		#endregion Constructors

		#region Methods

		public void InvalidateHumanArgument(int index)
		{
			humanArguments[index] = null;
		}

		public void InvalidateHumanFunction(int index)
		{
			humanFunctions[index] = null;
		}

		public bool HasMachineArgument(int index)
		{
			return !string.IsNullOrEmpty(machineArguments[index]);
		}

		public string GetMachineArgument(int index)
		{
			return machineArguments[index];
		}

		public void SetMachineArgument(int index, string value)
		{
			machineArguments[index] = value;
		}

		public bool HasMachineFunction(int index)
		{
			return !string.IsNullOrEmpty(machineFunctions[index]);
		}

		public string GetMachineFunction(int index)
		{
			return machineFunctions[index];
		}

		public void SetMachineFunction(int index, string value)
		{
			machineFunctions[index] = value;
		}

		public bool HasHumanArgument(int index)
		{
			return humanArguments[index] != null;
		}

		// ReSharper disable PossibleInvalidOperationException
		public decimal GetHumanArgument(int index)
		{
			return humanArguments[index].Value;
		}

		public void SetHumanArgument(int index, decimal value)
		{
			humanArguments[index] = value;
		}

		public bool HasHumanFunction(int index)
		{
			return humanFunctions[index] != null;
		}

		public decimal GetHumanFunction(int index)
		{
			return humanFunctions[index].Value;
		}

		public void SetHumanFunction(int index, decimal value)
		{
			humanFunctions[index] = value;
		}

		#endregion Methods
	}
}