using System;

namespace DataTable.Net.Services.Common
{
	[Flags]
	public enum ShellChangeNotificationFlags
	{
		/// <summary>
		/// dwItem1 and dwItem2 are the addresses of ITEMIDLIST structures that represent
		/// the item(s) affected by the change. Each ITEMIDLIST must be relative to the desktop folder.
		/// </summary>
		ShcnfIdList = 0x0000,

		/// <summary>
		/// dwItem1 and dwItem2 are the addresses of null-terminated strings of maximum length MAX_PATH
		/// that contain the full path names of the items affected by the change.
		/// </summary>
		ShcnfPathA = 0x0001,

		/// <summary>
		/// dwItem1 and dwItem2 are the addresses of null-terminated strings that represent the friendly
		/// names of the printer(s) affected by the change.
		/// </summary>
		ShcnfPrinterA = 0x0002,

		/// <summary>
		/// The dwItem1 and dwItem2 parameters are DWORD values.
		/// </summary>
		ShcnfDword = 0x0003,

		/// <summary>
		/// like ShcnfPathA but unicode string
		/// </summary>
		ShcnfPathW = 0x0005,

		/// <summary>
		/// like ShcnfPrinterA but unicode string
		/// </summary>
		ShcnfPrinterw = 0x0006,

		ShcnfType = 0x00FF,

		/// <summary>
		/// The function should not return until the notification has been delivered to all affected components.
		/// As this flag modifies other data-type flags, it cannot by used by itself.
		/// </summary>
		ShcnfFlush = 0x1000,

		/// <summary>
		/// The function should begin delivering notifications to all affected components but should return
		/// as soon as the notification process has begun. As this flag modifies other data-type flags, it cannot by used  by itself.
		/// </summary>
		ShcnfFlushNoWait = 0x2000
	}
}