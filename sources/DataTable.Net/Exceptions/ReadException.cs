using System;
using DataTable.Net.Properties;

namespace DataTable.Net.Exceptions
{
	public class ReadException : Exception
	{
		#region Properties

		public int ExpectedBytes { get; private set; }
		public int ReadBytes { get; private set; }

		#endregion Properties

		#region Constructors

		public ReadException(int expectedBytes, int readBytes)
		{
			ExpectedBytes = expectedBytes;
			ReadBytes = readBytes;
		}

		#endregion Constructors

		#region Exception overrides

		public override string Message
		{
			get { return string.Format(Resources.ReadFromFileExceptionMessage, ReadBytes, ExpectedBytes); }
		}

		#endregion Exception overrides
	}
}