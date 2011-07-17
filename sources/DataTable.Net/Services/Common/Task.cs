using System;

namespace DataTable.Net.Services.Common
{
	internal class Task
	{
		#region Fields

		private Action completedDelegate;
		private Action<Exception> errorDelegate;

		#endregion Fields

		#region Properties

		public BackgroundAction Action { get; protected set; }

		#endregion Properties

		#region Constructors

		public static Task Create(Action action)
		{
			return new Task(action);
		}

		private Task(Action action)
		{
			Action = new BackgroundAction(args => action());
			Action.Completed += OnActionCompleted;
			Action.ErrorOccurred += OnActionErrorOccurred;
		}

		protected Task()
		{
			//
		}

		#endregion Constructors

		#region Methods

		public virtual void Start()
		{
			Action.Perform();
		}

		public Task RunOnSuccess(Action successAction)
		{
			completedDelegate += successAction;
			return this;
		}

		public Task RunOnError(Action<Exception> errorAction)
		{
			errorDelegate += errorAction;
			return this;
		}

		#endregion Methods

		#region Helpers

		private void OnActionCompleted(object sender, CompletedEventArgs args)
		{
			if (completedDelegate != null)
			{
				completedDelegate();
			}
		}

		protected void OnActionErrorOccurred(object sender, ErrorOccurredEventArgs args)
		{
			if (errorDelegate != null)
			{
				errorDelegate(args.Exception);
			}
		}

		#endregion Helpers

		public Task WithContinuation(Task task)
		{
			Action.AddContinuation(task.Action);
			return this;
		}
	}

	internal class Task<T> : Task
	{
		#region Fields

		private Action<T> completedDelegate;

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

		public override void Start()
		{
			Action.Perform();
		}

		public new Task<T> WithContinuation(Task task)
		{
			Action.AddContinuation(task.Action);
			return this;
		}

		public Task<T> RunOnSuccess(Action<T> successAction)
		{
			completedDelegate += successAction;
			return this;
		}

		public new Task<T> RunOnError(Action<Exception> errorAction)
		{
			base.RunOnError(errorAction);
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

		#endregion Helpers
	}
}