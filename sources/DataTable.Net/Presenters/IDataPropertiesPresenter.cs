using DataTable.Net.Dtos;

namespace DataTable.Net.Presenters
{
	public interface IDataPropertiesPresenter
	{
		DataPropertiesDto GetDataPropertiesDto();
		void OnLoad();
	}
}