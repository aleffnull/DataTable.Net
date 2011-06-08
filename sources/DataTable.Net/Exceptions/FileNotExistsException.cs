using System;
using DataTable.Net.Properties;

namespace DataTable.Net.Exceptions
{
	public class FileNotExistsException : Exception
	{
		#region Properties

		public string FilePath { get; private set; }

		#endregion Properties

		#region Constructors

		public FileNotExistsException(string filePath)
		{
			FilePath = filePath;
		}

		#endregion Constructors

		#region Exception overrides

		public override string Message
		{
			get { return string.Format(Resources.FileNotExistsExceptionMessage, FilePath); }
		}

		#endregion Exception overrides
	}
}