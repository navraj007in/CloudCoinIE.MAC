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
	[Register ("ExportViewController")]
	partial class ExportViewController
	{
		[Outlet]
		AppKit.NSComboBox cboExportType { get; set; }

		[Outlet]
		AppKit.NSTextField countFives { get; set; }

		[Outlet]
		AppKit.NSTextField countHundreds { get; set; }

		[Outlet]
		AppKit.NSTextField countOnes { get; set; }

		[Outlet]
		AppKit.NSTextField countQtrs { get; set; }

		[Outlet]
		AppKit.NSTextField countTwoFifties { get; set; }

		[Outlet]
		AppKit.NSTextField lblFivesTotal { get; set; }

		[Outlet]
		AppKit.NSTextField lblHeader { get; set; }

		[Outlet]
		AppKit.NSTextField lblHundredsTotal { get; set; }

		[Outlet]
		AppKit.NSTextField lblOnesTotal { get; set; }

		[Outlet]
		AppKit.NSTextField lblQtrsTotal { get; set; }

		[Outlet]
		AppKit.NSTextField lblTwoFiftiesTotal { get; set; }

		[Outlet]
		AppKit.NSButton rdbJpeg { get; set; }

		[Outlet]
		AppKit.NSButton rdbStack { get; set; }

		[Outlet]
		AppKit.NSStepper stepperFives { get; set; }

		[Outlet]
		AppKit.NSStepper stepperHundreds { get; set; }

		[Outlet]
		AppKit.NSStepper stepperOnes { get; set; }

		[Outlet]
		AppKit.NSStepper stepperQtrs { get; set; }

		[Outlet]
		AppKit.NSStepper stepperTwoFifties { get; set; }

		[Outlet]
		AppKit.NSTextField txtTag { get; set; }

		[Action ("cmdExport:")]
		partial void cmdExport (Foundation.NSObject sender);

		[Action ("exportClicked:")]
		partial void exportClicked (Foundation.NSObject sender);

		[Action ("fiveClicked:")]
		partial void fiveClicked (Foundation.NSObject sender);

		[Action ("hundredClicked:")]
		partial void hundredClicked (Foundation.NSObject sender);

		[Action ("jpegClick:")]
		partial void jpegClick (Foundation.NSObject sender);

		[Action ("oneClicked:")]
		partial void oneClicked (Foundation.NSObject sender);

		[Action ("qtrClicked:")]
		partial void qtrClicked (Foundation.NSObject sender);

		[Action ("stackClicked:")]
		partial void stackClicked (Foundation.NSObject sender);

		[Action ("twoFiftyClicked:")]
		partial void twoFiftyClicked (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (countFives != null) {
				countFives.Dispose ();
				countFives = null;
			}

			if (countHundreds != null) {
				countHundreds.Dispose ();
				countHundreds = null;
			}

			if (countOnes != null) {
				countOnes.Dispose ();
				countOnes = null;
			}

			if (countQtrs != null) {
				countQtrs.Dispose ();
				countQtrs = null;
			}

			if (countTwoFifties != null) {
				countTwoFifties.Dispose ();
				countTwoFifties = null;
			}

			if (lblFivesTotal != null) {
				lblFivesTotal.Dispose ();
				lblFivesTotal = null;
			}

			if (lblHeader != null) {
				lblHeader.Dispose ();
				lblHeader = null;
			}

			if (lblHundredsTotal != null) {
				lblHundredsTotal.Dispose ();
				lblHundredsTotal = null;
			}

			if (lblOnesTotal != null) {
				lblOnesTotal.Dispose ();
				lblOnesTotal = null;
			}

			if (lblQtrsTotal != null) {
				lblQtrsTotal.Dispose ();
				lblQtrsTotal = null;
			}

			if (lblTwoFiftiesTotal != null) {
				lblTwoFiftiesTotal.Dispose ();
				lblTwoFiftiesTotal = null;
			}

			if (rdbJpeg != null) {
				rdbJpeg.Dispose ();
				rdbJpeg = null;
			}

			if (rdbStack != null) {
				rdbStack.Dispose ();
				rdbStack = null;
			}

			if (stepperFives != null) {
				stepperFives.Dispose ();
				stepperFives = null;
			}

			if (stepperHundreds != null) {
				stepperHundreds.Dispose ();
				stepperHundreds = null;
			}

			if (stepperOnes != null) {
				stepperOnes.Dispose ();
				stepperOnes = null;
			}

			if (stepperQtrs != null) {
				stepperQtrs.Dispose ();
				stepperQtrs = null;
			}

			if (stepperTwoFifties != null) {
				stepperTwoFifties.Dispose ();
				stepperTwoFifties = null;
			}

			if (cboExportType != null) {
				cboExportType.Dispose ();
				cboExportType = null;
			}

			if (txtTag != null) {
				txtTag.Dispose ();
				txtTag = null;
			}
		}
	}
}
