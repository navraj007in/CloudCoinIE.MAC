using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using CloudCoinCore;

namespace CloudCoinIE.Mac.Controller
{
    public partial class ExportViewController : AppKit.NSViewController
    {
		#region Constructors
		int onesTotal = 0;
		int fivesTotal = 0;
		int qtrsTotal = 0;
		int hundredsTotal = 0;
		int TwoFiftiesTotal = 0;

		public static int exportOnes = 0;
		public static int exportFives = 0;
		public static int exportTens = 0;
		public static int exportQtrs = 0;
		public static int exportHundreds = 0;
		public static int exportTwoFifties = 0;
		public static int exportJpegStack = 2;
		public static string exportTag = "";

		
        public EventHandler RefreshCoins;

		// Called when created from unmanaged code
		public ExportViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

		public void showCoins()
		{
            FileUtils fileUtils = AppDelegate.fileUtils;
			

            Banker bank = new Banker(fileUtils);
            int[] bankTotals = bank.countCoins(fileUtils.bankFolder);
			int[] frackedTotals = bank.countCoins(fileUtils.frackedFolder);
			int[] partialTotals = bank.countCoins(fileUtils.partialFolder);

			onesTotal = bankTotals[1] + frackedTotals[1] + partialTotals[1];
			fivesTotal = bankTotals[2] + frackedTotals[2] + partialTotals[2];
			qtrsTotal = bankTotals[3] + frackedTotals[3] + partialTotals[3];
			hundredsTotal = bankTotals[4] + frackedTotals[4] + partialTotals[4];
			TwoFiftiesTotal = bankTotals[5] + frackedTotals[5] + partialTotals[5];

			BeginInvokeOnMainThread(() =>
			{

                stepperOnes.MaxValue = onesTotal;
                stepperFives.MaxValue = fivesTotal;
                stepperQtrs.MaxValue = qtrsTotal;
                stepperHundreds.MaxValue = hundredsTotal;
                stepperTwoFifties.MaxValue = TwoFiftiesTotal;
				stepperFives.MaxValue = 5;
				stepperQtrs.MaxValue = 25;
				stepperHundreds.MaxValue = 100;
				stepperTwoFifties.MaxValue = 250;

				countOnes.StringValue = Convert.ToString( 0);
                countFives.StringValue = Convert.ToString(0);
                countQtrs.StringValue = Convert.ToString(0);
                countHundreds.StringValue = Convert.ToString(0);
                countTwoFifties.StringValue = Convert.ToString(0);
			});
		}
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            showCoins();
      
        }
		public void export()
		{
            FileUtils fileUtils = AppDelegate.fileUtils;
            if (rdbStack.IntValue == 1)
				exportJpegStack = 1;
			else
				exportJpegStack = 2;

            exportJpegStack = 2;
			Banker bank = new Banker(fileUtils);
			int[] bankTotals = bank.countCoins(fileUtils.bankFolder);
			int[] frackedTotals = bank.countCoins(fileUtils.frackedFolder);
			int[] partialTotals = bank.countCoins(fileUtils.partialFolder);

			//updateLog("  Your Bank Inventory:");
			int grandTotal = (bankTotals[0] + frackedTotals[0] + partialTotals[0]);
			// state how many 1, 5, 25, 100 and 250
            int exp_1 = Convert.ToInt16(countOnes.IntValue);
            int exp_5 = Convert.ToInt16(countFives.IntValue);
            int exp_25 = Convert.ToInt16(countQtrs.IntValue);
            int exp_100 = Convert.ToInt16(countHundreds.IntValue);
            int exp_250 = Convert.ToInt16(countTwoFifties.IntValue);
			//Warn if too many coins

			if (exp_1 + exp_5 + exp_25 + exp_100 + exp_250 == 0)
			{
				Console.WriteLine("Can not export 0 coins");
				return;
			}

			//updateLog(Convert.ToString(bankTotals[1] + frackedTotals[1] + bankTotals[2] + frackedTotals[2] + bankTotals[3] + frackedTotals[3] + bankTotals[4] + frackedTotals[4] + bankTotals[5] + frackedTotals[5] + partialTotals[1] + partialTotals[2] + partialTotals[3] + partialTotals[4] + partialTotals[5]));

			if (((bankTotals[1] + frackedTotals[1]) + (bankTotals[2] + frackedTotals[2]) + (bankTotals[3] + frackedTotals[3]) + (bankTotals[4] + frackedTotals[4]) + (bankTotals[5] + frackedTotals[5]) + partialTotals[1] + partialTotals[2] + partialTotals[3] + partialTotals[4] + partialTotals[5]) > 1000)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Out.WriteLine("Warning: You have more than 1000 Notes in your bank. Stack files should not have more than 1000 Notes in them.");
				Console.Out.WriteLine("Do not export stack files with more than 1000 notes. .");
				//updateLog("Warning: You have more than 1000 Notes in your bank. Stack files should not have more than 1000 Notes in them.");
				//updateLog("Do not export stack files with more than 1000 notes. .");

				Console.ForegroundColor = ConsoleColor.White;
			}//end if they have more than 1000 coins

			Console.Out.WriteLine("  Do you want to export your CloudCoin to (1)jpgs or (2) stack (JSON) file?");
			int file_type = 0; //reader.readInt(1, 2);





            Exporter exporter = new Exporter(AppDelegate.fileUtils);
			//exporter.OnUpdateStatus +=  ;
			file_type = exportJpegStack;

            String tag = txtTag.StringValue;// reader.readString();
									 //Console.Out.WriteLine(("Exporting to:" + exportFolder));

			if (file_type == 1)
			{
				exporter.writeJPEGFiles(exp_1, exp_5, exp_25, exp_100, exp_250, tag);
				// stringToFile( json, "test.txt");
			}
			else
			{
				exporter.writeJSONFile(exp_1, exp_5, exp_25, exp_100, exp_250, tag);
			}


			// end if type jpge or stack
			Console.Out.WriteLine("  Exporting CloudCoins Completed.");

            NSWorkspace.SharedWorkspace.SelectFile(AppDelegate.fileUtils.exportFolder,
                                                   AppDelegate.fileUtils.exportFolder);

			RefreshCoins?.Invoke(this, new EventArgs());
			//updateLog("Exporting CloudCoins Completed.");
			showCoins();
			//Process.Start(fileUtils.exportFolder);
			//MessageBox.Show("Export completed.", "Cloudcoins", MessageBoxButtons.OK);
		}// end export One
		partial void exportClicked(NSObject sender)
        {
            export();
        }
        partial void oneClicked(NSObject sender)
        {
            countOnes.StringValue = stepperOnes.StringValue;
            updateTotal();
        }
        partial void fiveClicked(NSObject sender)
        {
            countFives.StringValue = stepperFives.StringValue;
            updateTotal();
        }
        partial void qtrClicked(NSObject sender)
        {
            countQtrs.StringValue = stepperQtrs.StringValue;
            updateTotal();
        }
        partial void hundredClicked(NSObject sender)
        {
            countHundreds.StringValue = stepperHundreds.StringValue;
            updateTotal();
        }
        partial void twoFiftyClicked(NSObject sender)
        {
            countTwoFifties.StringValue = stepperTwoFifties.StringValue;
            updateTotal();
        }
		int total = 0;
        partial void jpegClick(NSObject sender)
        {
            rdbJpeg.State =  NSCellStateValue.On;
            rdbStack.State = NSCellStateValue.Off;
        }
        partial void stackClicked(NSObject sender)
        {
            rdbJpeg.State = NSCellStateValue.Off;
			rdbStack.State = NSCellStateValue.On;
		}
		private void updateTotal()
		{
			try
			{
                total = (countOnes.IntValue) + 
                        (countFives.IntValue) * 5 +
                        (countQtrs.IntValue) * 25 + 
                        (countHundreds.IntValue) * 100 + 
                        (countTwoFifties.IntValue) * 250;
				lblOnesTotal.IntValue = (countOnes.IntValue);
				lblFivesTotal.IntValue = stepperFives.IntValue * 5;
				lblQtrsTotal.IntValue = stepperQtrs.IntValue * 25;
				lblHundredsTotal.IntValue = stepperHundreds.IntValue * 100;
				lblTwoFiftiesTotal.IntValue = stepperTwoFifties.IntValue * 250;

				if (total > 0)
                    lblHeader.StringValue = "Export Your Coins - " + total;
				else
                    lblHeader.StringValue = "Export Your Coins ";

			}
			catch (Exception e)
			{
                Console.WriteLine(e.Message);
			}
     
		}
		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
        public ExportViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public ExportViewController() : base("ExportView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

		private void Exporter_OnUpdateStatus(object sender, ProgressEventArgs e)
		{

		}

		#endregion

		//strongly typed view accessor
		public new ExportView View
        {
            get
            {
                return (ExportView)base.View;
            }
        }
    }
}
