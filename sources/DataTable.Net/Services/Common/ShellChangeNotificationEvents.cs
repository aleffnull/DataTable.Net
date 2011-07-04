using System;

namespace DataTable.Net.Services.Common
{
	[Flags]
	public enum ShellChangeNotificationEvents : uint
	{
		/// <summary>
		/// The name of a nonfolder item has changed. ShcnfIdList or  ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the  previous PIDL or name of the item. dwItem2 contains the new PIDL or name of the item.
		/// </summary>
		ShcneRenameItem = 0x00000001,

		/// <summary>
		/// A nonfolder item has been created. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the item that was created. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneCreate = 0x00000002,

		/// <summary>
		/// A nonfolder item has been deleted. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the item that was deleted. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneDelete = 0x00000004,

		/// <summary>
		/// A folder has been created. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the folder that was created. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneMkdir = 0x00000008,

		/// <summary>
		/// A folder has been removed. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the folder that was removed. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneRmdir = 0x00000010,

		/// <summary>
		/// Storage media has been inserted into a drive. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the root of the drive that contains the new media. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneMediaInserted = 0x00000020,

		/// <summary>
		/// Storage media has been removed from a drive. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the root of the drive from which the media was removed. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneMediaRemoved = 0x00000040,

		/// <summary>
		/// A drive has been removed. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the root of the drive that was removed. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneDriveRemoved = 0x00000080,

		/// <summary>
		/// A drive has been added. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the root of the drive that was added. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneDriveAdd = 0x00000100,

		/// <summary>
		/// A folder on the local computer is being shared via the network.
		/// ShcnfIdList or ShcnfPath must be specified in uFlags. dwItem1 contains the folder that is being shared.
		/// dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneNetShare = 0x00000200,

		/// <summary>
		/// A folder on the local computer is no longer being shared via the network.
		/// ShcnfIdList or ShcnfPath must be specified in uFlags. dwItem1 contains the folder that is no longer being shared.
		/// dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneNetUnshare = 0x00000400,

		/// <summary>
		/// The attributes of an item or folder have changed. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the item or folder that has changed. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneAttributes = 0x00000800,

		/// <summary>
		/// The contents of an existing folder have changed, but the folder still exists and has not been renamed.
		/// ShcnfIdList or ShcnfPath must be specified in uFlags. dwItem1 contains the folder that has changed.
		/// dwItem2 is not used and should be NULL. If a folder has been created, deleted, or renamed,
		/// use ShcneMkdir, ShcneRmdir, or ShcneRenameFolder, respectively, instead.
		/// </summary>
		ShcneUpdateDir = 0x00001000,

		/// <summary>
		/// An existing nonfolder item has changed, but the item still exists and has not been renamed.
		/// ShcnfIdList or ShcnfPath must be specified in uFlags. dwItem1 contains the item that has changed.
		/// dwItem2 is not used and should be NULL. If a nonfolder item has been created, deleted, or renamed,
		/// use ShcneCreate, ShcneDelete, or ShcneRenameItem, respectively, instead.
		/// </summary>
		ShcneUpdateItem = 0x00002000,

		/// <summary>
		/// The computer has disconnected from a server. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the server from which the computer was disconnected. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneServerDisconnect = 0x00004000,

		/// <summary>
		/// An image in the system image list has changed. ShcnfDword must be specified in uFlags.
		/// dwItem1 contains the index in the system image list that has changed. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneUpdateImage = 0x00008000,

		/// <summary>
		/// A drive has been added and the Shell should create a new window for the drive.
		/// ShcnfIdList or ShcnfPath must be specified in uFlags. dwItem1 contains the root of the drive that was added.
		/// dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneDriveAddGui = 0x00010000,

		/// <summary>
		/// The name of a folder has changed. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the previous pointer to an item identifier list (PIDL) or name of the folder.
		/// dwItem2 contains the new PIDL or name of the folder.
		/// </summary>
		ShcneRenameFolder = 0x00020000,

		/// <summary>
		/// The amount of free space on a drive has changed. ShcnfIdList or ShcnfPath must be specified in uFlags.
		/// dwItem1 contains the root of the drive on which the free space changed. dwItem2 is not used and should be NULL.
		/// </summary>
		ShcneFreeSpace = 0x00040000,

		/// <summary>
		/// Not currently used.
		/// </summary>
		ShcneExtendedEvent = 0x04000000,

		/// <summary>
		/// A file type association has changed. ShcnfIdList must be specified in the uFlags parameter.
		/// dwItem1 and dwItem2 are not used and must be NULL.
		/// </summary>
		ShcneAssocChanged = 0x08000000,

		/// <summary>
		/// Specifies a combination of all of the disk event identifiers.
		/// </summary>
		ShcneDiskEvents = 0x0002381F,

		/// <summary>
		/// Specifies a combination of all of the global event identifiers. 
		/// </summary>
		ShcneGlobalEvents = 0x0C0581E0,

		/// <summary>
		/// All events have occurred.
		/// </summary>
		ShcneAllEvents = 0x7FFFFFFF,

		/// <summary>
		/// The specified event occurred as a result of a system interrupt.
		/// As this value modifies other event values, it cannot be used alone.
		/// </summary>
		ShcneInterrupt = 0x80000000
	}
}