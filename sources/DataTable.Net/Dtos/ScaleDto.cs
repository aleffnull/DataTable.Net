using DataTable.Net.Properties;

namespace DataTable.Net.Dtos
{
	public class ScaleDto
	{
		#region Properties

		public int Scale { get; private set; }

		public string ScaleString
		{
			get { return string.Format(InternalResources.ScaleDtoScaleStringFormat, Scale); }
		}

		#endregion Properties

		#region Constructors

		public ScaleDto(int scale)
		{
			Scale = scale;
		}

		#endregion Constructors
	}
}