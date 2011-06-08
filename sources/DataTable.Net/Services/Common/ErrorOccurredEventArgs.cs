using System;

namespace DataTable.Net.Services.Common
{
	internal class ErrorOccurredEventArgs : EventArgs
	{
		#region Properties

		public Exception Exception { get; private set; }

		#endregion Properties

		#region Constructors

		public ErrorOccurredEventArgs(Exception exception)
		{
			Exception = exception;
		}

		#endregion Constructors
	}
}