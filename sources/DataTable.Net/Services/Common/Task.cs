using System;

namespace DataTable.Net.Services.Common
{
	internal class Task
	{
		#region Properties

		public BackgroundAction Action { get; protected set; }

		#endregion Properties
	}

	internal class Task<T> : Task
	{
		#region Fields

		private Action<T> completedDelegate;
		private Action<Exception> errorDelegate;

		#endregion Fields

		#region Constructors

		public static Task<T> Create(Func<T> func)
		{
			return new Task<T>(func);
		}

		private Task(Func<T> func)
		{
			Action = new BackgroundAction(args => { args.Result = func(); });
			Action.Completed += OnActionCompleted;
			Action.ErrorOccurred += OnActionErrorOccurred;
		}

		#endregion Constructors

		#region Methods

		public void Start()
		{
			Action.Perform();
		}

		public Task<T> WithContinuation(Task task)
		{
			Action.AddContinuation(task.Action);
			return this;
		}

		public Task<T> RunOnSuccess(Action<T> successAction)
		{
			completedDelegate += successAction;
			return this;
		}

		public Task<T> RunOnError(Action<Exception> errorAction)
		{
			errorDelegate += errorAction;
			return this;
		}

		#endregion Methods

		#region Helpers

		private void OnActionCompleted(object sender, CompletedEventArgs args)
		{
			if (completedDelegate == null)
			{
				return;
			}

			var result = (T)args.Result;
			completedDelegate(result);
		}

		private void OnActionErrorOccurred(object sender, ErrorOccurredEventArgs args)
		{
			if (errorDelegate != null)
			{
				errorDelegate(args.Exception);
			}
		}

		#endregion Helpers
	}
}