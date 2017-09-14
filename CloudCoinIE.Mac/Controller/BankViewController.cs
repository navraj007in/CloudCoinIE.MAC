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
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.Title = "CloudCoin IE";

            showCoins();
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
			//lblTotalCoins, "Total Coins in Bank : " + Convert.ToString(bankTotals[0] + frackedTotals[0] + partialTotals[0]));

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
