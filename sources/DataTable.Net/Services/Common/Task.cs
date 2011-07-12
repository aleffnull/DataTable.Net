using System;

namespace DataTable.Net.Services.Common
{
	public class Task<T>
	{
		#region Constructors

		public static Task<T> Create(Func<T> func)
		{
			return new Task<T>();
		}

		private Task()
		{
			//
		}

		#endregion Constructors

		#region Methods

		public void Start()
		{
			//
		}

		public Task<T> WithContinuation<TInner>(Task<TInner> task)
		{
			return this;
		}

		public Task<T> RunOnSuccess(Action<T> successAction)
		{
			return this;
		}

		public Task<T> RunOnError(Action<Exception> errorAction)
		{
			return this;
		}

		#endregion Methods
	}
}