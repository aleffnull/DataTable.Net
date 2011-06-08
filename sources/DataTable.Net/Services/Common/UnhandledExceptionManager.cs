using System;
using System.Threading;
using DataTable.Net.Forms;
using DataTable.Net.Properties;
using log4net;

namespace DataTable.Net.Services.Common
{
	internal class UnhandledExceptionManager
	{
		#region Fields

		private readonly ILog log = LogManager.GetLogger(typeof(UnhandledExceptionManager));

		#endregion Fields

		#region Event handlers

		public void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			HandleException(e.Exception);
		}

		public void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			HandleException(e.ExceptionObject as Exception);
		}

		#endregion Event handlers

		#region Helpers

		private void HandleException(Exception e)
		{
			TryLogError(e);
			TryShowException(e);

			TryLogDebug(InternalResources.ApplicationTerminated);
			Environment.Exit(0);
		}

		// ReSharper disable EmptyGeneralCatchClause
		private void TryLogDebug(string message)
		{
			try
			{
				log.Debug(message);
			}
			catch
			{
				//
			}
		}
		// ReSharper restore EmptyGeneralCatchClause

		// ReSharper disable EmptyGeneralCatchClause
		private void TryLogError(Exception e)
		{
			try
			{
				log.Error(e);
			}
			catch
			{
				//
			}
		}
		// ReSharper restore EmptyGeneralCatchClause

		// ReSharper disable EmptyGeneralCatchClause
		private void TryLogError(string message, Exception e)
		{
			try
			{
				log.Error(message, e);
			}
			catch
			{
				//
			}
		}
		// ReSharper restore EmptyGeneralCatchClause

		private void TryShowException(Exception exception)
		{
			try
			{
				var exceptionForm = new ExceptionForm(exception);
				exceptionForm.ShowDialog();
			}
			catch (Exception e)
			{
				TryLogError(InternalResources.FailedToShowExceptionWindow, e);
			}
		}

		#endregion Helpers
	}
}