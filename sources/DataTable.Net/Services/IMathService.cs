using DataTable.Net.Models;

namespace DataTable.Net.Services
{
	public interface IMathService
	{
		/// <summary>
		/// Little-endian is used in sake of performance, cause we receive data from file in this form.
		/// </summary>
		/// <param name="rawValue"></param>
		/// <param name="arithmeticType"></param>
		/// <param name="scalePowerIndex"></param>
		/// <returns></returns>
		decimal GetValue(byte[] rawValue, ArithmeticType arithmeticType, int scalePowerIndex);

		byte[] ConvertToPositiveIfNeeded(byte[] rawValues, out bool wasNegative);
		int GetPowerIndex(int byteIndex, int bitIndex, ArithmeticType arithmeticType, int bytesCount = -1);
	}
}