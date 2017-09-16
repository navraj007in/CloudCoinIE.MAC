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
    [Register ("ImportViewController")]
    partial class ImportViewController
    {
        [Outlet]
        AppKit.NSButton import_Click { get; set; }

        [Outlet]
        AppKit.NSProgressIndicator importProgressBar { get; set; }

        [Outlet]
        AppKit.NSTextField lblProgress { get; set; }

        [Outlet]
        AppKit.NSTextView txtImportLog { get; set; }

        [Outlet]
        AppKit.NSTextField txtLogs { get; set; }

        [Action ("importClicked:")]
        partial void importClicked (Foundation.NSObject sender);
        
        void ReleaseDesignerOutlets ()
        {
            if (txtImportLog != null) {
                txtImportLog.Dispose ();
                txtImportLog = null;
            }

            if (importProgressBar != null) {
                importProgressBar.Dispose ();
                importProgressBar = null;
            }

            if (lblProgress != null) {
                lblProgress.Dispose ();
                lblProgress = null;
            }

            if (import_Click != null) {
                import_Click.Dispose ();
                import_Click = null;
            }

            if (txtLogs != null) {
                txtLogs.Dispose ();
                txtLogs = null;
            }
        }
    }
}
