using System.Collections.Generic;
using DataTable.Net.Dtos;
using DataTable.Net.Services.Common;

namespace DataTable.Net.Models
{
	public class CachingDataModel : DataModel
	{
		#region Fields

		private readonly List<CacheLine> cache = new List<CacheLine>();

		#endregion Fields

		#region Constructors

		public CachingDataModel(string filePath, FullDataPropertiesDto fullDataPropertiesDto, ServiceLocator serviceLocator)
			: base(filePath, fullDataPropertiesDto, serviceLocator)
		{
			//
		}

		#endregion Constructors

		#region DataModel overrides

		public override void AddEntry(DataEntry dataEntry)
		{
			base.AddEntry(dataEntry);
			var cacheLine = new CacheLine(dataEntry.Arguments.Length, dataEntry.Functions.Length);
			cache.Add(cacheLine);
		}

		public override void SetArgumentScale(int index, int scale)
		{
			base.SetArgumentScale(index, scale);
			foreach (var cacheLine in cache)
			{
				cacheLine.InvalidateHumanArgument(index);
			}
		}

		public override void SetFunctionScale(int index, int scale)
		{
			base.SetFunctionScale(index, scale);
			foreach (var cacheLine in cache)
			{
				cacheLine.InvalidateHumanFunction(index);
			}
		}

		public override string GetMachineArgument(int index, int dataEntryIndex)
		{
			var cacheLine = cache[dataEntryIndex];
			if (cacheLine.HasMachineArgument(index))
			{
				return cacheLine.GetMachineArgument(index);
			}

			var value = base.GetMachineArgument(index, dataEntryIndex);
			cacheLine.SetMachineArgument(index, value);

			return value;
		}

		public override string GetMachineFunction(int index, int dataEntryIndex)
		{
			var cacheLine = cache[dataEntryIndex];
			if (cacheLine.HasMachineFunction(index))
			{
				return cacheLine.GetMachineFunction(index);
			}

			var value = base.GetMachineFunction(index, dataEntryIndex);
			cacheLine.SetMachineFunction(index, value);

			return value;
		}

		public override decimal GetHumanArgument(int index, int dataEntryIndex)
		{
			var cacheLine = cache[dataEntryIndex];
			if (cacheLine.HasHumanArgument(index))
			{
				return cacheLine.GetHumanArgument(index);
			}

			var value = base.GetHumanArgument(index, dataEntryIndex);
			cacheLine.SetHumanArgument(index, value);

			return value;
		}

		public override decimal GetHumanFunction(int index, int dataEntryIndex)
		{
			var cacheLine = cache[dataEntryIndex];
			if (cacheLine.HasHumanFunction(index))
			{
				return cacheLine.GetHumanFunction(index);
			}

			var value = base.GetHumanFunction(index, dataEntryIndex);
			cacheLine.SetHumanFunction(index, value);

			return value;
		}

		#endregion DataModel overrides
	}
}