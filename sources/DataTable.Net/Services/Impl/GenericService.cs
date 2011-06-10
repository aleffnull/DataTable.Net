using DataTable.Net.Services.Common;

namespace DataTable.Net.Services.Impl
{
	public class GenericService : AbstractAsyncService, IGenericService
	{
		#region IInitializationService implementation

		public void BeginDoingAction(
			Action action, ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback)
		{
			DoRequest(() => action(), successCallback, errorCallback);
		}

		#endregion IInitializationService implementation
	}
}