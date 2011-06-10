using DataTable.Net.Services.Common;

namespace DataTable.Net.Services
{
	public interface IGenericService
	{
		void BeginDoingAction(
			Action action, ServiceSuccessCallback successCallback, ServiceErrorCallback errorCallback);
	}
}