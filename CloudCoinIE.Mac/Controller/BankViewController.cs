using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using CloudCoinCore;

namespace CloudCoinIE.Mac.Controller
{
    public partial class BankViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public BankViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public BankViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public BankViewController() : base("BankView", NSBundle.MainBundle)
        {
            Initialize();
           // showCoins();
        }

        // Shared initialization code
        void Initialize()
        {
           // showCoins();
        }
		public bool echoRaida()
		{

			RAIDA_Status.resetEcho();
			RAIDA raida1 = new RAIDA(5000);
			Response[] results = raida1.echoAll(5000);
			int totalReady = 0;
			Console.Out.WriteLine("");
			//For every RAIDA check its results

			Console.Out.WriteLine();

			totalReady = RAIDA_Status.failsEcho.Where(c => c).Count();


			Console.ForegroundColor = ConsoleColor.White;
			Console.Out.WriteLine("");
			Console.Out.WriteLine("");
			Console.Out.Write("  RAIDA Health: " + totalReady + " / 25: ");//"RAIDA Health: " + totalReady );
																		   //lblHealth.Text = "  RAIDA Health: " + totalReady + " / 25: ";

			// Running on the UI thread

			//Check if enough are good 
			if (totalReady < 16)//
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Out.WriteLine("  Not enough RAIDA servers can be contacted to import new coins.");// );
				Console.Out.WriteLine("  Is your device connected to the Internet?");// );
				Console.Out.WriteLine("  Is a router blocking your connection?");// );
				Console.ForegroundColor = ConsoleColor.White;

				return false;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Out.WriteLine("The RAIDA is ready for counterfeit detection.");// );
				Console.ForegroundColor = ConsoleColor.White;
				return true;
			}//end if enough RAIDA
		}//End echo

        public override void ViewDidAppear() {
            showCoins();
        }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.Title = "CloudCoin IE";

            showCoins();
            echoRaida();
			// Do any additional setup after loading the view.
		}
		public void showCoins()
		{
			Console.Out.WriteLine("");
			// This is for consol apps.
            Banker bank = new Banker(AppDelegate.fileUtils);
            int[] bankTotals = bank.countCoins(AppDelegate.fileUtils.bankFolder);
            int[] frackedTotals = bank.countCoins(AppDelegate.fileUtils.frackedFolder);
            int[] partialTotals = bank.countCoins(AppDelegate.fileUtils.partialFolder);

            lblOnesCount.StringValue = Convert.ToString(bankTotals[1] + frackedTotals[1] + partialTotals[1]);
            lblFivesCount.StringValue = Convert.ToString(bankTotals[2] + frackedTotals[2] + partialTotals[2]);
            lblQtrsCount.StringValue = Convert.ToString(bankTotals[3] + frackedTotals[3] + partialTotals[3]);
            lblHundredsCount.StringValue = Convert.ToString(bankTotals[4] + frackedTotals[4] + partialTotals[4]);
            lblTwoFiftiesCount.StringValue = Convert.ToString(bankTotals[5] + frackedTotals[5] + partialTotals[5]);

            lblOnesTotal.StringValue = Convert.ToString(bankTotals[1] + frackedTotals[1] + partialTotals[1]);
            lblFivesTotal.StringValue = Convert.ToString((bankTotals[2] + frackedTotals[2] + partialTotals[2]) * 5);
            lblQtrsTotal.StringValue =  Convert.ToString((bankTotals[3] + frackedTotals[3] + partialTotals[3]) * 25);
            lblHundredsTotal.StringValue= Convert.ToString((bankTotals[4] + frackedTotals[4] + partialTotals[4]) * 100);
            lblTwoFiftiesTotal.StringValue = Convert.ToString((bankTotals[5] + frackedTotals[5] + partialTotals[5]) * 250);

            lblTotalCoins.StringValue = "Total Coins in Bank : " + Convert.ToString(bankTotals[0] + frackedTotals[0] + partialTotals[0]);
            lblValueTotal.StringValue = Convert.ToString(bankTotals[1] + bankTotals[2] + bankTotals[3] +bankTotals[4] +
                                                         frackedTotals[1] +frackedTotals[2]+frackedTotals[3]+frackedTotals[4] +
                                                         partialTotals[1] + partialTotals[2] + partialTotals[3] + partialTotals[4]);
            lblValueTotal.StringValue = Convert.ToString(lblOnesTotal.IntValue
                                                         + lblFivesTotal.IntValue
                                                         + lblQtrsTotal.IntValue
                                                         + lblHundredsTotal.IntValue
                                                         + lblTwoFiftiesTotal.IntValue);
            
            lblCountTotal.StringValue = Convert.ToString(lblOnesCount.IntValue +
                                                         lblFivesCount.IntValue + 
                                                         lblHundredsCount.IntValue+
                                                         lblQtrsCount.IntValue + 
                                                         lblTwoFiftiesCount.IntValue);

        }// end show
		#endregion

		//strongly typed view accessor
		public new BankView View
        {
            get
            {
                return (BankView)base.View;
            }
        }
    }
}
