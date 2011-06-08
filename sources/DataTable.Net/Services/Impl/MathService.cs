using System;
using System.Collections.Generic;
using DataTable.Net.Models;
using DataTable.Net.Properties;

namespace DataTable.Net.Services.Impl
{
	public class MathService : IMathService
	{
		#region Fields

		private readonly Dictionary<int, decimal> powerTable = new Dictionary<int, decimal>();

		#endregion Fields

		#region IMathService implementation

		public void PrecalculatePowerTable(int maxAbsolutePower)
		{
			for (var power = -maxAbsolutePower; power <= maxAbsolutePower; power++)
			{
				powerTable[power] = (decimal)Math.Pow(2, power);
			}
		}

		public decimal GetValue(byte[] rawValue, ArithmeticType arithmeticType, int scalePowerIndex)
		{
			bool wasNegative;
			var absoluteRawValue = ConvertToPositiveIfNeeded(rawValue, out wasNegative);

			var result = 0.0m;
			for (var byteIndex = 0; byteIndex < rawValue.Length; byteIndex++)
			{
				var @byte = absoluteRawValue[byteIndex];
				var lastByte = byteIndex == rawValue.Length - 1;

				var lastBitIndex = lastByte ? 6 : 7;
				for (var bitIndex = 0; bitIndex <= lastBitIndex; bitIndex++)
				{
					var bit = @byte & 0x01;
					if (bit == 1)
					{
						var powerIndex = GetPowerIndex(byteIndex, bitIndex, arithmeticType, rawValue.Length);
						var scaledPowerIndex = powerIndex - scalePowerIndex;
						var digitValue = GetPower(scaledPowerIndex);

						result += digitValue;
					}
					@byte = (byte)(@byte >> 1);
				}
			}

			if (wasNegative)
			{
				result *= -1;
			}

			return result;
		}

		public byte[] ConvertToPositiveIfNeeded(byte[] rawValues, out bool wasNegative)
		{
			var result = new byte[rawValues.Length];

			var upperByte = rawValues[rawValues.Length - 1];
			var shiftedUpperByte = (byte)(upperByte >> 7);
			var one = shiftedUpperByte & 0x1;
			if (one == 0x0)
			{
				wasNegative = false;
				rawValues.CopyTo(result, 0);

				return result;
			}

			wasNegative = true;
			for (var byteIndex = 0; byteIndex < rawValues.Length; byteIndex++)
			{
				result[byteIndex] = (byte)(~rawValues[byteIndex]);
			}
			for (var byteIndex = 0; byteIndex < rawValues.Length; byteIndex++)
			{
				var complement = result[byteIndex] + 1;
				if (complement > 0xFF)
				{
					result[byteIndex] = (byte)(complement & 0xFF);
				}
				else
				{
					result[byteIndex] = (byte)complement;
					break;
				}
			}

			return result;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="byteIndex"></param>
		/// <param name="bitIndex">index of bit in byte. Starts from the right</param>
		/// <param name="arithmeticType"></param>
		/// <param name="bytesCount"></param>
		/// <returns></returns>
		public int GetPowerIndex(int byteIndex, int bitIndex, ArithmeticType arithmeticType, int bytesCount = -1)
		{
			int index;
			switch (arithmeticType)
			{
				case ArithmeticType.Integer:
					index = bitIndex + 8 * byteIndex;
					return index;
				case ArithmeticType.Fractional:
					if (bytesCount == -1)
					{
						throw new ArgumentException(InternalResources.BytesCountNotSpecified);
					}
					index = bitIndex - 7 - 8*(bytesCount - 1 - byteIndex);
					return index;
				default:
					throw new ArgumentException(string.Format(InternalResources.ArithmeticTypeUnknownMember, arithmeticType));
			}
		}

		#endregion IMathService implementation

		#region Helpers

		private decimal GetPower(int powerIndex)
		{
			if (powerTable.ContainsKey(powerIndex))
			{
				return powerTable[powerIndex];
			}

			var power = (decimal)Math.Pow(2, powerIndex);
			powerTable[powerIndex] = power;

			return power;
		}

		#endregion Helpers
	}
}