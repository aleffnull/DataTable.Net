using DataTable.Net.Services.Common;

namespace DataTable.Net.Services
{
	internal interface ITaskService
	{
		Task CreateTask(Action action);
		Task<T> CreateTask<T>(Func<T> func);
	}
}