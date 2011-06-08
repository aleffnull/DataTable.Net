using DataTable.Net.Services.Common;

namespace DataTable.Net.Services.Impl
{
	public class InitializationService : AbstractAsyncService, IInitializationService
	{
		#region IInitializationService implementation

		public void BeginInitializing(
			Action action, ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback)
		{
			DoRequest(() => action(), successCallback, errorCallback);
		}

		#endregion IInitializationService implementation
	}
}