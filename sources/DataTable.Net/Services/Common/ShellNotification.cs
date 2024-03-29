/*
* Copyright (c) 2006, Brendan Grant (grantb@dahat.com)
* All rights reserved.
* Redistribution and use in source and binary forms, with or without
* modification, are permitted provided that the following conditions are met:
*
*     * All original and modified versions of this source code must include the
*       above copyright notice, this list of conditions and the following
*       disclaimer.
*     * This code may not be used with or within any modules or code that is 
*       licensed in any way that that compels or requires users or modifiers
*       to release their source code or changes as a requirement for
*       the use, modification or distribution of binary, object or source code
*       based on the licensed source code. (ex: Cannot be used with GPL code.)
*     * The name of Brendan Grant may be used to endorse or promote products
*       derived from this software without specific prior written permission.
*
* THIS SOFTWARE IS PROVIDED BY BRENDAN GRANT ``AS IS'' AND ANY EXPRESS OR
* IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
* OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO
* EVENT SHALL BRENDAN GRANT BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
* SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
* PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; 
* OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
* WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
* OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
* ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Runtime.InteropServices;

namespace DataTable.Net.Services.Common
{
	public class ShellNotification
	{
		#region Extern

		/// <summary>
		/// Notifies the system of an event that an application has performed. An application should use
		/// this function if it performs an action that may affect the Shell. 
		/// </summary>
		/// <param name="wEventId">Describes the event that has occurred. The ShellChangeNotificationEvents
		/// enum contains a list of options.</param>
		/// <param name="uFlags">Flags that indicate the meaning of the dwItem1 and dwItem2 parameters.</param>
		/// <param name="dwItem1">First event-dependent value.</param>
		/// <param name="dwItem2">Second event-dependent value.</param>
		[DllImport("shell32.dll")]
		private static extern void SHChangeNotify(UInt32 wEventId, UInt32 uFlags, IntPtr dwItem1, IntPtr dwItem2);

		#endregion Extern

		#region Methods

		/// <summary>
		/// Notify shell of change of file associations.
		/// </summary>
		public static void NotifyOfChange()
		{
			SHChangeNotify(
				(uint)ShellChangeNotificationEvents.ShcneAssocChanged,
				(uint)(ShellChangeNotificationFlags.ShcnfIdList | ShellChangeNotificationFlags.ShcnfFlushNoWait),
				IntPtr.Zero, IntPtr.Zero);
		}

		#endregion Methods
	}
}