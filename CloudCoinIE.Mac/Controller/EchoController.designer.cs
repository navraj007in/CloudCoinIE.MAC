// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CloudCoinIE.Mac
{
	[Register ("EchoController")]
	partial class EchoController
	{
		[Outlet]
		AppKit.NSTextField lblEcho { get; set; }

		[Action ("cmdEcho:")]
		partial void cmdEcho (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (lblEcho != null) {
				lblEcho.Dispose ();
				lblEcho = null;
			}
		}
	}
}
