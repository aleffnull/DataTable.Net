using System;
using DataTable.Net.Models;
using DataTable.Net.Services;
using DataTable.Net.Services.Impl;
using NUnit.Framework;

namespace DataTable.Net.Tests
{
	[TestFixture]
	public class MathServiceFixture
	{
		#region Fields

		private IMathService mathService;

		#endregion Fields

		#region SetUp

		[SetUp]
		public void SetUp()
		{
			mathService = new MathService();
		}

		#endregion SetUp

		#region Tests

		#region GetValue

		[Test]
		public void GetValue_Zero_ZeroScale_Integer()
		{
			byte[] rawValue = {0x00};
			var value = mathService.GetValue(rawValue, ArithmeticType.Integer, 0);

			Assert.That(value, Is.EqualTo(0.0));
		}

		[Test]
		public void GetValue_Zero_NonZeroScale_Integer()
		{
			byte[] rawValue = {0x00};
			var value = mathService.GetValue(rawValue, ArithmeticType.Integer, 1);

			Assert.That(value, Is.EqualTo(0.0));
		}

		[Test]
		public void GetValue_Zero_ZeroScale_Fractional()
		{
			byte[] rawValue = {0x00};
			var value = mathService.GetValue(rawValue, ArithmeticType.Fractional, 0);

			Assert.That(value, Is.EqualTo(0.0));
		}

		[Test]
		public void GetValue_Zero_NonZeroScale_Fractional()
		{
			byte[] rawValue = {0x00};
			var value = mathService.GetValue(rawValue, ArithmeticType.Fractional, 1);

			Assert.That(value, Is.EqualTo(0.0));
		}

		[Test]
		public void GetValue_One_ZeroScale_Integer_Byte()
		{
			byte[] rawValue = {0x01};
			var value = mathService.GetValue(rawValue, ArithmeticType.Integer, 0);

			Assert.That(value, Is.EqualTo(1.0));
		}

		[Test]
		public void GetValue_MinusOne_ZeroScale_Integer_Byte()
		{
			byte[] rawValue = {0xFF};
			var value = mathService.GetValue(rawValue, ArithmeticType.Integer, 0);

			Assert.That(value, Is.EqualTo(-1.0));
		}

		[Test]
		public void GetValue_One_ZeroScale_Integer_Word()
		{
			byte[] rawValue = {0x01, 0x00};
			var value = mathService.GetValue(rawValue, ArithmeticType.Integer, 0);

			Assert.That(value, Is.EqualTo(1.0));
		}

		[Test]
		public void GetValue_MinusOne_ZeroScale_Integer_Word()
		{
			byte[] rawValue = {0xFF, 0xFF};
			var value = mathService.GetValue(rawValue, ArithmeticType.Integer, 0);

			Assert.That(value, Is.EqualTo(-1.0));
		}

		[Test]
		public void GetValue_One_ZeroScale_Integer_Dword()
		{
			byte[] rawValue = {0x01, 0x00, 0x00, 0x00};
			var value = mathService.GetValue(rawValue, ArithmeticType.Integer, 0);

			Assert.That(value, Is.EqualTo(1.0));
		}

		[Test]
		public void GetValue_MinusOne_ZeroScale_Integer_Dword()
		{
			byte[] rawValue = {0xFF, 0xFF, 0xFF, 0xFF};
			var value = mathService.GetValue(rawValue, ArithmeticType.Integer, 0);

			Assert.That(value, Is.EqualTo(-1.0));
		}

		[Test]
		public void GetValue_One_ZeroScale_Fractional_Byte()
		{
			byte[] rawValue = {0x01};
			var value = mathService.GetValue(rawValue, ArithmeticType.Fractional, 0);

			Assert.That(value, Is.EqualTo(Math.Pow(2, -7)));
		}

		[Test]
		public void GetValue_MinusOne_ZeroScale_Fractional_Byte()
		{
			byte[] rawValue = {0xFF};
			var value = mathService.GetValue(rawValue, ArithmeticType.Fractional, 0);

			Assert.That(value, Is.EqualTo(-Math.Pow(2, -7)));
		}

		[Test]
		public void GetValue_One_ZeroScale_Fractional_Word()
		{
			byte[] rawValue = {0x01, 0x00};
			var value = mathService.GetValue(rawValue, ArithmeticType.Fractional, 0);

			Assert.That(value, Is.EqualTo(Math.Pow(2, -15)));
		}

		[Test]
		public void GetValue_MinusOne_ZeroScale_Fractional_Word()
		{
			byte[] rawValue = {0xFF, 0xFF};
			var value = mathService.GetValue(rawValue, ArithmeticType.Fractional, 0);

			Assert.That(value, Is.EqualTo(-Math.Pow(2, -15)));
		}

		[Test]
		public void GetValue_One_ZeroScale_Fractional_Dword()
		{
			byte[] rawValue = {0x01, 0x00, 0x00, 0x00};
			var value = mathService.GetValue(rawValue, ArithmeticType.Fractional, 0);

			Assert.That(value, Is.EqualTo((decimal)Math.Pow(2, -31)));
		}

		[Test]
		public void GetValue_MinusOne_ZeroScale_Fractional_Dword()
		{
			byte[] rawValue = {0xFF, 0xFF, 0xFF, 0xFF};
			var value = mathService.GetValue(rawValue, ArithmeticType.Fractional, 0);

			Assert.That(value, Is.EqualTo(-((decimal)Math.Pow(2, -31))));
		}

		[Test]
		public void GetValue_Somevalue_1_Integer_Byte()
		{
			byte[] rawValue = {0x5F};
			var value = mathService.GetValue(rawValue, ArithmeticType.Integer, 4);

			Assert.That(value, Is.EqualTo(5.9375));
		}

		[Test]
		public void GetValue_Somevalue_1_Integer_Word()
		{
			byte[] rawValue = {0x33, 0x5F};
			var value = mathService.GetValue(rawValue, ArithmeticType.Integer, 12);

			Assert.That(value, Is.EqualTo(5.949951171875));
		}

		[Test]
		public void GetValue_Somevalue_1_Integer_Dword()
		{
			byte[] rawValue = {0x58, 0x4A, 0x33, 0x5F};
			var value = mathService.GetValue(rawValue, ArithmeticType.Integer, 28);

			Assert.That(value, Is.EqualTo(5.95002207159996));
		}

		[Test]
		public void GetValue_Somevalue_1_Fractional_Word()
		{
			byte[] rawValue = {0x33, 0x5F};
			var value = mathService.GetValue(rawValue, ArithmeticType.Fractional, -3);

			Assert.That(value, Is.EqualTo(5.949951171875));
		}

		[Test]
		public void GetValue_Somevalue_1_Fractional_Dword()
		{
			byte[] rawValue = {0x58, 0x4A, 0x33, 0x5F};
			var value = mathService.GetValue(rawValue, ArithmeticType.Fractional, -3);

			Assert.That(value, Is.EqualTo(5.95002207159996));
		}

		[Test]
		public void GetValue_Somevalue_1_Fractional_Byte()
		{
			byte[] rawValue = { 0x5F };
			var value = mathService.GetValue(rawValue, ArithmeticType.Fractional, -3);

			Assert.That(value, Is.EqualTo(5.9375));
		}

		#endregion GetValue

		#region ConvertToPositiveIfNeeded

		[Test]
		public void ConvertToPositiveIfNeeded_Zero_Byte()
		{
			var rawValues = new byte[] {0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.False);
			CollectionAssert.AreEqual(rawValues, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Positive_Byte()
		{
			var rawValues = new byte[] {0x77};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.False);
			CollectionAssert.AreEqual(rawValues, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Negative_Byte()
		{
			var rawValues = new byte[] {0x89};
			var expectedResult = new byte[] {0x77};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.True);
			CollectionAssert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_ZeroOne_Byte()
		{
			var rawValues = new byte[] {0xFF};
			var expectedResult = new byte[] {0x01};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.True);
			CollectionAssert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Zero_Word()
		{
			var rawValues = new byte[] {0x00, 0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.False);
			CollectionAssert.AreEqual(rawValues, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Positive_Word()
		{
			var rawValues = new byte[] {0x77, 0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.False);
			CollectionAssert.AreEqual(rawValues, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Negative_Word_NoCarry()
		{
			var rawValues = new byte[] {0x89, 0xFF};
			var expectedResult = new byte[] {0x77, 0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.True);
			CollectionAssert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Negative_Word_Carry()
		{
			var rawValues = new byte[] {0x00, 0xFF};
			var expectedResult = new byte[] {0x00, 0x01};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.True);
			CollectionAssert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Negative_Word_Carry_1()
		{
			var rawValues = new byte[] {0x00, 0xFE};
			var expectedResult = new byte[] {0x00, 0x02};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.True);
			CollectionAssert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_ZeroOne_Word()
		{
			var rawValues = new byte[] {0xFF, 0xFF};
			var expectedResult = new byte[] {0x01, 0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.True);
			CollectionAssert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Zero_Dword()
		{
			var rawValues = new byte[] {0x00, 0x00, 0x00, 0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.False);
			CollectionAssert.AreEqual(rawValues, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Positive_Dword()
		{
			var rawValues = new byte[] {0x77, 0x00, 0x00, 0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.False);
			CollectionAssert.AreEqual(rawValues, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Negative_Dword_NoCarry()
		{
			var rawValues = new byte[] {0x89, 0xFF, 0xFF, 0xFF};
			var expectedResult = new byte[] {0x77, 0x00, 0x00, 0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.True);
			CollectionAssert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Negative_Dword_Carry()
		{
			var rawValues = new byte[] {0x00, 0xFF, 0xFF, 0xFF};
			var expectedResult = new byte[] {0x00, 0x01, 0x00, 0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.True);
			CollectionAssert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Negative_Dword_Carry_1()
		{
			var rawValues = new byte[] {0x00, 0xFE, 0xFF, 0xFF};
			var expectedResult = new byte[] {0x00, 0x02, 0x00, 0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.True);
			CollectionAssert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_Negative_Dword_Carry_2()
		{
			var rawValues = new byte[] {0x00, 0x00, 0xFE, 0xFF};
			var expectedResult = new byte[] {0x00, 0x00, 0x02, 0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.True);
			CollectionAssert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ConvertToPositiveIfNeeded_ZeroOne_Dword()
		{
			var rawValues = new byte[] {0xFF, 0xFF, 0xFF, 0xFF};
			var expectedResult = new byte[] {0x01, 0x00, 0x00, 0x00};
			bool wasNegative;
			var result = mathService.ConvertToPositiveIfNeeded(rawValues, out wasNegative);

			Assert.That(wasNegative, Is.True);
			CollectionAssert.AreEqual(expectedResult, result);
		}

		#endregion ConvertToPositiveIfNeeded

		#region GetPowerIndex

		[Test]
		public void GetPowerIndex_Integer()
		{
			Assert.That(mathService.GetPowerIndex(0, 0, ArithmeticType.Integer), Is.EqualTo(0));
			Assert.That(mathService.GetPowerIndex(0, 3, ArithmeticType.Integer), Is.EqualTo(3));
			Assert.That(mathService.GetPowerIndex(0, 7, ArithmeticType.Integer), Is.EqualTo(7));
			Assert.That(mathService.GetPowerIndex(1, 0, ArithmeticType.Integer), Is.EqualTo(8));
			Assert.That(mathService.GetPowerIndex(1, 3, ArithmeticType.Integer), Is.EqualTo(11));
			Assert.That(mathService.GetPowerIndex(1, 7, ArithmeticType.Integer), Is.EqualTo(15));
			Assert.That(mathService.GetPowerIndex(2, 0, ArithmeticType.Integer), Is.EqualTo(16));
			Assert.That(mathService.GetPowerIndex(2, 3, ArithmeticType.Integer), Is.EqualTo(19));
			Assert.That(mathService.GetPowerIndex(2, 7, ArithmeticType.Integer), Is.EqualTo(23));
			Assert.That(mathService.GetPowerIndex(3, 0, ArithmeticType.Integer), Is.EqualTo(24));
			Assert.That(mathService.GetPowerIndex(3, 3, ArithmeticType.Integer), Is.EqualTo(27));
			Assert.That(mathService.GetPowerIndex(3, 6, ArithmeticType.Integer), Is.EqualTo(30));
		}

		[Test]
		public void GetPowerIndex_Fractional_Byte()
		{
			Assert.That(mathService.GetPowerIndex(0, 0, ArithmeticType.Fractional, 1), Is.EqualTo(-7));
			Assert.That(mathService.GetPowerIndex(0, 3, ArithmeticType.Fractional, 1), Is.EqualTo(-4));
			Assert.That(mathService.GetPowerIndex(0, 6, ArithmeticType.Fractional, 1), Is.EqualTo(-1));
		}

		[Test]
		public void GetPowerIndex_Fractional_Word()
		{
			Assert.That(mathService.GetPowerIndex(0, 0, ArithmeticType.Fractional, 2), Is.EqualTo(-15));
			Assert.That(mathService.GetPowerIndex(0, 3, ArithmeticType.Fractional, 2), Is.EqualTo(-12));
			Assert.That(mathService.GetPowerIndex(0, 7, ArithmeticType.Fractional, 2), Is.EqualTo(-8));
			Assert.That(mathService.GetPowerIndex(1, 0, ArithmeticType.Fractional, 2), Is.EqualTo(-7));
			Assert.That(mathService.GetPowerIndex(1, 3, ArithmeticType.Fractional, 2), Is.EqualTo(-4));
			Assert.That(mathService.GetPowerIndex(1, 6, ArithmeticType.Fractional, 2), Is.EqualTo(-1));
		}

		[Test]
		public void GetPowerIndex_Fractional_Dword()
		{
			Assert.That(mathService.GetPowerIndex(0, 0, ArithmeticType.Fractional, 4), Is.EqualTo(-31));
			Assert.That(mathService.GetPowerIndex(0, 3, ArithmeticType.Fractional, 4), Is.EqualTo(-28));
			Assert.That(mathService.GetPowerIndex(0, 7, ArithmeticType.Fractional, 4), Is.EqualTo(-24));
			Assert.That(mathService.GetPowerIndex(1, 0, ArithmeticType.Fractional, 4), Is.EqualTo(-23));
			Assert.That(mathService.GetPowerIndex(1, 3, ArithmeticType.Fractional, 4), Is.EqualTo(-20));
			Assert.That(mathService.GetPowerIndex(1, 7, ArithmeticType.Fractional, 4), Is.EqualTo(-16));
			Assert.That(mathService.GetPowerIndex(2, 0, ArithmeticType.Fractional, 4), Is.EqualTo(-15));
			Assert.That(mathService.GetPowerIndex(2, 3, ArithmeticType.Fractional, 4), Is.EqualTo(-12));
			Assert.That(mathService.GetPowerIndex(2, 7, ArithmeticType.Fractional, 4), Is.EqualTo(-8));
			Assert.That(mathService.GetPowerIndex(3, 0, ArithmeticType.Fractional, 4), Is.EqualTo(-7));
			Assert.That(mathService.GetPowerIndex(3, 3, ArithmeticType.Fractional, 4), Is.EqualTo(-4));
			Assert.That(mathService.GetPowerIndex(3, 6, ArithmeticType.Fractional, 4), Is.EqualTo(-1));
		}

		[Test]
		public void GetPowerIndex_Fractional_NoOptionalParameters()
		{
			Assert.That(() => mathService.GetPowerIndex(0, 0, ArithmeticType.Fractional), Throws.ArgumentException);
		}

		#endregion GetPowerIndex

		#endregion Tests
	}
}
