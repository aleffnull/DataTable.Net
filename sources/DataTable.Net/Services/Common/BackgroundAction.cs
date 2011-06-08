using System;
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
				Post(state => OnCompleted(args.Result));
			}
			catch (Exception e)
			{
				Post(state => OnErrorOccurred(e));
			}
		}

		private void Post(SendOrPostCallback callback)
		{
			if (syncContext != null && SyncContextIsValid())
			{
				syncContext.Post(callback, null);
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