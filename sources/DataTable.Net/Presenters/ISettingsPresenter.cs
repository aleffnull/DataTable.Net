using DataTable.Net.Dtos;

namespace DataTable.Net.Presenters
{
	internal interface ISettingsPresenter
	{
		void OnLoad(SettingsDto settings);
		SettingsDto GetSettings();
	}
}