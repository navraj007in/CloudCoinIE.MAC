// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace CloudCoinIE.Mac.Controller
{
	[Register ("ConfigureViewController")]
	partial class ConfigureViewController
	{
		[Outlet]
		AppKit.NSTextField lblWorkspace { get; set; }

		[Outlet]
		AppKit.NSTextField lblWorkspaceDescription { get; set; }

		[Action ("backupClick:")]
		partial void backupClick (Foundation.NSObject sender);

		[Action ("changeFolders:")]
		partial void changeFolders (Foundation.NSObject sender);

		[Action ("showFolders:")]
		partial void showFolders (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (lblWorkspace != null) {
				lblWorkspace.Dispose ();
				lblWorkspace = null;
			}

			if (lblWorkspaceDescription != null) {
				lblWorkspaceDescription.Dispose ();
				lblWorkspaceDescription = null;
			}
		}
	}
}
