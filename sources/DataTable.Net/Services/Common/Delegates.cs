using System;

namespace DataTable.Net.Services.Common
{
	internal delegate void ActionPerformer(ActionArgs args);

	public delegate void Action();
	public delegate void ServiceWorker();
	public delegate T ServiceWorker<out T>();
	public delegate void ServiceSuccessCallback();
	public delegate void ServiceSuccessCallback<in T>(T result);
	public delegate void ServiceErrorCallback(Exception e);
}