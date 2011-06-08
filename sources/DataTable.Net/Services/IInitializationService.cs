using DataTable.Net.Services.Common;

namespace DataTable.Net.Services
{
	public interface IInitializationService
	{
		void BeginInitializing(
			Action action, ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback);
	}
}