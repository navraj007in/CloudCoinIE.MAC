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
	[Register ("BankViewController")]
	partial class BankViewController
	{
		[Outlet]
		AppKit.NSTextField lblFivesCount { get; set; }

		[Outlet]
		AppKit.NSTextField lblFivesTotal { get; set; }

		[Outlet]
		AppKit.NSTextField lblHundredsCount { get; set; }

		[Outlet]
		AppKit.NSTextField lblHundredsTotal { get; set; }

		[Outlet]
		AppKit.NSTextField lblOnesCount { get; set; }

		[Outlet]
		AppKit.NSTextField lblOnesTotal { get; set; }

		[Outlet]
		AppKit.NSTextField lblQtrsCount { get; set; }

		[Outlet]
		AppKit.NSTextField lblQtrsTotal { get; set; }

		[Outlet]
		AppKit.NSTextField lblTwoFiftiesCount { get; set; }

		[Outlet]
		AppKit.NSTextField lblTwoFiftiesTotal { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lblOnesCount != null) {
				lblOnesCount.Dispose ();
				lblOnesCount = null;
			}

			if (lblFivesCount != null) {
				lblFivesCount.Dispose ();
				lblFivesCount = null;
			}

			if (lblQtrsCount != null) {
				lblQtrsCount.Dispose ();
				lblQtrsCount = null;
			}

			if (lblHundredsCount != null) {
				lblHundredsCount.Dispose ();
				lblHundredsCount = null;
			}

			if (lblTwoFiftiesCount != null) {
				lblTwoFiftiesCount.Dispose ();
				lblTwoFiftiesCount = null;
			}

			if (lblOnesTotal != null) {
				lblOnesTotal.Dispose ();
				lblOnesTotal = null;
			}

			if (lblFivesTotal != null) {
				lblFivesTotal.Dispose ();
				lblFivesTotal = null;
			}

			if (lblQtrsTotal != null) {
				lblQtrsTotal.Dispose ();
				lblQtrsTotal = null;
			}

			if (lblHundredsTotal != null) {
				lblHundredsTotal.Dispose ();
				lblHundredsTotal = null;
			}

			if (lblTwoFiftiesTotal != null) {
				lblTwoFiftiesTotal.Dispose ();
				lblTwoFiftiesTotal = null;
			}
		}
	}
}