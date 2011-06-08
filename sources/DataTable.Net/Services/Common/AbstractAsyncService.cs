namespace DataTable.Net.Services.Common
{
	public abstract class AbstractAsyncService
	{
		#region Methods

		public void DoRequest(ServiceWorker worker, ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback)
		{
			var action = CreateAction(worker);
			AttachCompletedEventHandler(action, successCallback);
			AttachErrorOccurredEventHandler(action, errorCallback);

			action.Perform();
		}

		public void DoRequest<T>(ServiceWorker<T> worker, ServiceSuccessCallback<T> successCallback, ServiceErrorCallback errorCallback)
		{
			var action = CreateAction(worker);
			AttachCompletedEventHandler(action, successCallback);
			AttachErrorOccurredEventHandler(action, errorCallback);

			action.Perform();
		}

		#endregion Methods

		#region Helpers

		private static BackgroundAction CreateAction(ServiceWorker worker)
		{
			ActionPerformer actionPerformer = args => worker();
			var action = new BackgroundAction(actionPerformer);

			return action;
		}

		private static BackgroundAction CreateAction<T>(ServiceWorker<T> worker)
		{
			ActionPerformer actionPerformer = args => { args.Result = worker(); };
			var action = new BackgroundAction(actionPerformer);

			return action;
		}

		private static void AttachCompletedEventHandler(BackgroundAction action, ServiceSuccessCallback successCallback)
		{
			if (successCallback != null)
			{
				action.Completed += (sender, e) => successCallback();
			}
		}

		private static void AttachCompletedEventHandler<T>(BackgroundAction action, ServiceSuccessCallback<T> successCallback)
		{
			if (successCallback != null)
			{
				action.Completed +=
					(sender, e) =>
						{
							var result = (T)e.Result;
							successCallback(result);
						};
			}
		}

		private static void AttachErrorOccurredEventHandler(BackgroundAction action, ServiceErrorCallback errorCallback)
		{
			if (errorCallback != null)
			{
				action.ErrorOccurred += (sender, e) => errorCallback(e.Exception);
			}
		}

		#endregion Helpers
	}
}