namespace DataTable.Net.Presenters
{
	public interface IAboutPresenter
	{
		void OnLoad();
		void OnMailLinkClicked(string mailLink);
		void OnCopyVersionInfo();
	}
}