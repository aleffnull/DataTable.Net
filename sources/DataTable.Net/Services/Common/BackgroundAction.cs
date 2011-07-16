using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using DataTable.Net.Properties;

namespace DataTable.Net.Services.Common
{
	internal class BackgroundAction
	{
		#region Fields

		private readonly SynchronizationContext syncContext;
		private readonly Thread thread;
		private readonly List<BackgroundAction> continuationActions = new List<BackgroundAction>();
		private ZeroWaitEvent syncEvent;

		#endregion Fields

		#region Events

		public event EventHandler<CompletedEventArgs> Completed;
		public event EventHandler<ErrorOccurredEventArgs> ErrorOccurred;

		#endregion Events

		#region Constructors

		public BackgroundAction(ActionPerformer actionPerformer)
		{
			syncContext = SynchronizationContext.Current;
			thread = new Thread(state => RunWorker(actionPerformer)) {IsBackground = true};
		}

		#endregion Constructors

		#region Methods

		public void AddContinuation(BackgroundAction action)
		{
			continuationActions.Add(action);
		}

		public void Perform()
		{
			thread.Start();
		}

		#endregion Methods

		#region Helpers

		private void RunWorker(ActionPerformer actionPerformer)
		{
			try
			{
				var args = new ActionArgs();
				actionPerformer(args);
				RunContinuations();
				Send(state => OnCompleted(args.Result));
			}
			catch (Exception e)
			{
				Send(state => OnErrorOccurred(e));
			}
			finally
			{
				if (syncEvent != null)
				{
					syncEvent.Release();
				}
			}
		}

		private void RunContinuations()
		{
			if (continuationActions.Count == 0)
			{
				return;
			}

			var waitEvent = new ZeroWaitEvent(false);
			foreach (var action in continuationActions)
			{
				action.Perform(waitEvent);
			}
			waitEvent.WaitZeroReferences();
			waitEvent.Close();
		}

		private void Perform(ZeroWaitEvent waitEvent)
		{
			syncEvent = waitEvent;
			syncEvent.AddReference();
			Perform();
		}

		private void Send(SendOrPostCallback callback)
		{
			if (syncContext != null && SyncContextIsValid())
			{
				syncContext.Send(callback, null);
			}
			else
			{
				callback(null);
			}
		}

		private bool SyncContextIsValid()
		{
			if (syncContext is WindowsFormsSynchronizationContext)
			{
				var info = syncContext.GetType().GetField(
					InternalResources.SyncContextControlToSendToField, BindingFlags.NonPublic | BindingFlags.Instance);
				if (info != null)
				{
					var controlToSendTo = (Control)info.GetValue(syncContext);
					if (controlToSendTo != null)
					{
						if (controlToSendTo.IsDisposed || controlToSendTo.Disposing)
						{
							return false;
						}
					}
				}
			}

			return true;
		}

		private void OnCompleted(object result)
		{
			var eventHandler = Completed;
			if (eventHandler != null)
			{
				var eventArgs = new CompletedEventArgs(result);
				eventHandler(this, eventArgs);
			}
		}

		private void OnErrorOccurred(Exception exception)
		{
			var eventHandler = ErrorOccurred;
			if (eventHandler != null)
			{
				var eventArgs = new ErrorOccurredEventArgs(exception);
				eventHandler(this, eventArgs);
			}
		}

		#endregion Helpers
	}
}