using System;
using System.Threading;
using DataTable.Net.Properties;

namespace DataTable.Net.Services.Common
{
	public class ZeroWaitEvent
	{
		#region Fields

		private readonly ManualResetEvent resetEvent;
		private long counter;

		#endregion Fields

		#region Constructors

		public ZeroWaitEvent(bool initialState)
		{
			resetEvent = new ManualResetEvent(initialState);
		}

		#endregion Constructors

		#region Methods

		public void AddReference()
		{
			Interlocked.Increment(ref counter);
		}

		public void Release()
		{
			if (counter == 0)
			{
				throw new InvalidOperationException(Resources.NoReferencesToRelease);
			}

			Interlocked.Decrement(ref counter);
			if (counter == 0)
			{
				resetEvent.Set();
			}
		}

		public void WaitZeroReferences()
		{
			if (counter <= 0)
			{
				return;
			}

			resetEvent.WaitOne();
		}

		public void Close()
		{
			resetEvent.Close();
		}

		#endregion Methods
	}
}