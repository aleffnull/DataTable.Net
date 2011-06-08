namespace DataTable.Net.Views
{
	public interface IAboutView
	{
		string VersionInfo { get; set; }
		void SetMailLink(string link);
		void SetMailLinkVisited();
	}
}