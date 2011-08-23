using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using DataTable.Net.Forms;
using DataTable.Net.Properties;
using DataTable.Net.Services;
using DataTable.Net.Services.Common;
using DataTable.Net.Services.Impl;
using log4net;
using log4net.Config;

namespace DataTable.Net
{
	static class Program
	{
		#region Fields

		private static readonly ILog log = LogManager.GetLogger(typeof(Program));
		private static readonly UnhandledExceptionManager exceptionManager = new UnhandledExceptionManager();
		private static readonly ServiceLocator serviceLocator;

		#endregion Fields

		#region Properties

		private static ISettingsService SettingsService
		{
			get { return serviceLocator.Resolve<ISettingsService>(); }
		}

		#endregion Properties

		#region Constructors

		static Program()
		{
			serviceLocator = CreateServiceLocator();
		}

		#endregion Constructors

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

		private static ServiceLocator CreateServiceLocator()
		{
			var locator = new ServiceLocator();
			locator.RegisterService<ISettingsService>(new SettingsService());
			locator.RegisterService<IRecentFilesService>(new RecentFilesService());
			locator.RegisterService<IMathService>(new MathService());
			locator.RegisterService<IDataService>(new DataService(locator));

			return locator;
		}

		private static void RunApplication(IList<string> args)
		{
			string fileToOpen = null;
			if (args.Count >= 1)
			{
				fileToOpen = args[0];
				log.InfoFormat(InternalResources.GotFileFromCommandLine, fileToOpen);
			}

			log.Info(InternalResources.LoadingSettings);
			SettingsService.LoadSettings();
			log.Info(InternalResources.SettingsLoadingFinished);

			var culture = SettingsService.CurrentSettings.Language.Culture;
			log.DebugFormat(InternalResources.SettingMainThreadCulture, culture);
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture = culture;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(fileToOpen, serviceLocator));
		}

		#endregion Helpers
	}
}
