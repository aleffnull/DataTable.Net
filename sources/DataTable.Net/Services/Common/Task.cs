using System;

namespace DataTable.Net.Services.Common
{
	internal class Task
	{
		#region Fields

		private Action readyDelegate;
		private Action completedDelegate;
		private Action<Exception> errorDelegate;
		private Action doneDelegate;

		#endregion Fields

		#region Properties

		public BackgroundAction Action { get; protected set; }

		#endregion Properties

		#region Constructors

		public Task(Action action, ISettingsService settingsService)
		{
			Action = new BackgroundAction(args => action(), settingsService);
			Action.Ready += OnActionReady;
			Action.Completed += OnActionCompleted;
			Action.ErrorOccurred += OnActionErrorOccurred;
			Action.Done += OnActionDone;
		}

		protected Task()
		{
			//
		}

		#endregion Constructors

		#region Methods

		public Task WithContinuation(Task task)
		{
			Action.AddContinuation(task.Action);
			return this;
		}

		public virtual void Start()
		{
			Action.Perform();
		}

		public Task RunBefore(Action readyAction)
		{
			readyDelegate += readyAction;
			return this;
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

		public Task RunOnDone(Action doneAction)
		{
			doneDelegate += doneAction;
			return this;
		}

		#endregion Methods

		#region Event handlers

		protected void OnActionReady(object sender, EventArgs e)
		{
			if (readyDelegate != null)
			{
				readyDelegate();
			}
		}

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

		protected void OnActionDone(object sender, EventArgs eventArgs)
		{
			if (doneDelegate != null)
			{
				doneDelegate();
			}
		}

		#endregion Event handlers
	}

	internal class Task<T> : Task
	{
		#region Fields

		private Action<T> completedDelegate;

		#endregion Fields

		#region Constructors

		public Task(Func<T> func, ISettingsService settingsService)
		{
			Action = new BackgroundAction(args => { args.Result = func(); }, settingsService);
			Action.Ready += OnActionReady;
			Action.Completed += OnActionCompleted;
			Action.ErrorOccurred += OnActionErrorOccurred;
			Action.Done += OnActionDone;
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

		public new Task<T> RunBefore(Action readyAction)
		{
			base.RunBefore(readyAction);
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

		#region Event handlers

		private void OnActionCompleted(object sender, CompletedEventArgs args)
		{
			if (completedDelegate == null)
			{
				return;
			}

			var result = (T)args.Result;
			completedDelegate(result);
		}

		#endregion Event handlers
	}
}