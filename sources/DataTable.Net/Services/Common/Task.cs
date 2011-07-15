using System;
using System.Collections.Generic;

namespace DataTable.Net.Services.Common
{
	internal class Task
	{
		#region Properties

		protected BackgroundAction Action { get; set; }

		#endregion Properties

		#region Methods

		public virtual void Start(ZeroWaitEvent waitEvent)
		{
			//
		}

		#endregion Methods
	}

	internal class Task<T> : Task
	{
		#region Fields

		private readonly List<Task> continuationTasks = new List<Task>();
		private ZeroWaitEvent syncEvent;
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

		public override void Start(ZeroWaitEvent waitEvent)
		{
			syncEvent = waitEvent;
			syncEvent.AddReference();
			Start();
		}

		public Task<T> WithContinuation(Task task)
		{
			continuationTasks.Add(task);
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
			if (continuationTasks.Count != 0)
			{
				ExecuteContinuationTasks();
			}

			if (completedDelegate != null)
			{
				var result = (T)args.Result;
				completedDelegate(result);
			}

			if (syncEvent != null)
			{
				syncEvent.Release();
			}
		}

		private void OnActionErrorOccurred(object sender, ErrorOccurredEventArgs args)
		{
			if (errorDelegate != null)
			{
				errorDelegate(args.Exception);
			}

			if (syncEvent != null)
			{
				syncEvent.Release();
			}
		}

		private void ExecuteContinuationTasks()
		{
			var waitEvent = new ZeroWaitEvent(false);
			foreach (var task in continuationTasks)
			{
				task.Start(waitEvent);
			}
			waitEvent.WaitZeroReferences();
			waitEvent.Close();
		}

		#endregion Helpers
	}
}