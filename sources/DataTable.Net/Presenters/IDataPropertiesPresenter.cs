using DataTable.Net.Dtos;

namespace DataTable.Net.Presenters
{
	public interface IDataPropertiesPresenter
	{
		CoreDataPropertiesDto GetDto();
		void OnLoad();
	}
}