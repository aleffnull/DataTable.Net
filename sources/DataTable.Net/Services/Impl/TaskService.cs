using DataTable.Net.Services.Common;

namespace DataTable.Net.Services.Impl
{
	// ReSharper disable ClassNeverInstantiated.Global
	internal class TaskService : ITaskService
	{
		#region Fields

		private readonly ISettingsService settingsService;

		#endregion Fields

		#region Constructors

		public TaskService(ISettingsService settingsService)
		{
			this.settingsService = settingsService;
		}

		#endregion Constructors

		#region ITaskService implementation

		public Task CreateTask(Action action)
		{
			return new Task(action, settingsService);
		}

		public Task<T> CreateTask<T>(Func<T> func)
		{
			return new Task<T>(func, settingsService);
		}

		#endregion ITaskService implementation
	}
	// ReSharper restore ClassNeverInstantiated.Global
}