using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using DataTable.Net.Forms;
using DataTable.Net.Properties;
using DataTable.Net.Services.Common;
using log4net;
using log4net.Config;

namespace DataTable.Net
{
	static class Program
	{
		#region Fields

		private static readonly ILog log = LogManager.GetLogger(typeof(Program));
		private static readonly UnhandledExceptionManager exceptionManager = new UnhandledExceptionManager();

		#endregion Fields

		#region Main

		[STAThread]
		static void Main(string[] args)
		{
			XmlConfigurator.Configure();
			log.Info(InternalResources.ApplicationStarted);

			if (!Debugger.IsAttached)
			{
				InitExceptionHandling();
			}
			RunApplication(args);

			log.Info(InternalResources.ApplicationClosed);
		}

		#endregion Main

		#region Helpers

		private static void InitExceptionHandling()
		{
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += exceptionManager.Application_ThreadException;
			AppDomain.CurrentDomain.UnhandledException += exceptionManager.CurrentDomain_UnhandledException;
		}

		private static void RunApplication(IList<string> args)
		{
			string fileToOpen = null;
			if (args.Count >= 1)
			{
				fileToOpen = args[0];
				log.InfoFormat(InternalResources.GotFileFromCommandLine, fileToOpen);
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(fileToOpen));
		}

		#endregion Helpers
	}
}
