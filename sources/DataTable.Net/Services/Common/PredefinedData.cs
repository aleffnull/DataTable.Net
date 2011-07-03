using System.Collections.Generic;
using System.Reflection;
using DataTable.Net.Properties;

namespace DataTable.Net.Services.Common
{
	public static class PredefinedData
	{
		#region Fields

		private static readonly string programExecutable;
		private static readonly List<string> supportedExtensions = new List<string>();

		#endregion Fields

		#region Properties

		public static string ProgramExecutable
		{
			get { return programExecutable; }
		}

		public static IEnumerable<string> SupportedExtensions
		{
			get { return supportedExtensions; }
		}

		#endregion Properties

		#region Constructors

		static PredefinedData()
		{
			programExecutable = Assembly.GetExecutingAssembly().Location;

			supportedExtensions.Add(InternalResources.DatExtension);
			supportedExtensions.Add(InternalResources.HexExtension);
			supportedExtensions.Add(InternalResources.BinExtension);
		}

		#endregion Constructors
	}
}