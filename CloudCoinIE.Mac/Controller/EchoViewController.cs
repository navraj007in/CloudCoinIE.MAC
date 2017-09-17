using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using System.IO;
using CloudCoinCore;

namespace CloudCoinIE.Mac.Controller
{
    public partial class EchoViewController : AppKit.NSViewController
    {
		public static string[] countries = new String[] { "Australia", "Macedonia", "Philippines", "Serbia", "Bulgaria", "Russia", "Switzerland", "United Kingdom", "Punjab", "India", "Croatia", "USA", "India", "Taiwan", "Moscow", "St.Petersburg", "Columbia", "Singapore", "Germany", "Canada", "Venezuela", "Hyperbad", "USA", "Ukraine", "Luxenburg" };
        NSTextField[] raidas = new NSTextField[25];

		public static String rootFolder = AppDomain.CurrentDomain.BaseDirectory;
		public static String importFolder = rootFolder + "Import" + Path.DirectorySeparatorChar;
		public static String importedFolder = rootFolder + "Imported" + Path.DirectorySeparatorChar;
		public static String trashFolder = rootFolder + "Trash" + Path.DirectorySeparatorChar;
		public static String suspectFolder = rootFolder + "Suspect" + Path.DirectorySeparatorChar;
		public static String frackedFolder = rootFolder + "Fracked" + Path.DirectorySeparatorChar;
		public static String bankFolder = rootFolder + "Bank" + Path.DirectorySeparatorChar;
		public static String templateFolder = rootFolder + "Templates" + Path.DirectorySeparatorChar;
		public static String counterfeitFolder = rootFolder + "Counterfeit" + Path.DirectorySeparatorChar;
		public static String directoryFolder = rootFolder + "Directory" + Path.DirectorySeparatorChar;
		public static String exportFolder = rootFolder + "Export" + Path.DirectorySeparatorChar;
		public static String languageFolder = rootFolder + "Language" + Path.DirectorySeparatorChar;
		public static String partialFolder = rootFolder + "Partial" + Path.DirectorySeparatorChar;


        public static FileUtils fileUtils = AppDelegate.fileUtils;
        #region Constructors

        // Called when created from unmanaged code
        public EchoViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EchoViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public EchoViewController() : base("EchoView", NSBundle.MainBundle)
        {
            Initialize();
			raidas[0] = lblAustralia;
			raidas[1] = lblMacedonia;

		}

        partial void echoRAIDA(NSObject sender)
        {
			raidas[0] = lblAustralia;
			raidas[1] = lblMacedonia;
            raidas[2] = lblPhilipines;
			raidas[3] = lblSerbia;
			raidas[4] = lblBulgaria;
			raidas[5] = lblRussia;
			raidas[6] = lblSwitzerland;
            raidas[7] = lblUnitedKingdom;
			raidas[8] = lblPunjab;
			raidas[9] = lblIndia;
			raidas[10] = lblCroatia;
			raidas[11] = lblUSA;
			raidas[12] = lblIndia2;
			raidas[13] = lblTaiwan;
			raidas[14] = lblMoscow;
            raidas[15] = lblStPetersberg;
			raidas[16] = lblColumbia;
			raidas[17] = lblSingapore;
			raidas[18] = lblGermany;
			raidas[19] = lblCanada;
			raidas[20] = lblVenezuela;
			raidas[21] = lblHyderabad;
			raidas[22] = lblUSA2;
			raidas[23] = lblUkraine;
			raidas[24] = lblLuxemberg;
            echoRaida();
        }
        // Shared initialization code
        void Initialize()
        {
        }

		public bool echoRaida()
		{
            cmdEcho.Enabled = false;
			raidas[0] = lblAustralia;
			raidas[1] = lblMacedonia;

			cmdEcho.Enabled = false;

			RAIDA_Status.resetEcho();
			RAIDA raida1 = new RAIDA(5000);
			Response[] results = raida1.echoAll(5000);
			int totalReady = 0;
			Console.Out.WriteLine("");
			//For every RAIDA check its results
			int longestCountryName = 15;

			Console.Out.WriteLine();
			for (int i = 0; i < 25; i++)
			{
				int padding = longestCountryName - countries[i].Length;
				string strPad = "";
				for (int j = 0; j < padding; j++)
				{
					strPad += " ";
				}//end for padding
				 // Console.Out.Write(RAIDA_Status.failsEcho[i]);
				if (RAIDA_Status.failsEcho[i])
				{
					Console.BackgroundColor = ConsoleColor.Red;
					Console.Out.Write(strPad + countries[i]);
				}
				else
				{
					Console.BackgroundColor = ConsoleColor.Green;
					Console.Out.Write(strPad + countries[i]);
					totalReady++;
				}

	

				if (i == 4 || i == 9 || i == 14 || i == 19) { Console.WriteLine(); }
			}//end for

            totalReady = RAIDA_Status.failsEcho.Where(c => c).Count();
            lblAustralia.TextColor = RAIDA_Status.failsEcho[0] ? NSColor.Green : NSColor.Red;
            lblMacedonia.TextColor = RAIDA_Status.failsEcho[1] ? NSColor.Green : NSColor.Red;
            lblPhilipines.TextColor = RAIDA_Status.failsEcho[2] ? NSColor.Green : NSColor.Red;
            lblSerbia.TextColor = RAIDA_Status.failsEcho[3] ? NSColor.Green : NSColor.Red;
            lblBulgaria.TextColor = RAIDA_Status.failsEcho[4] ? NSColor.Green : NSColor.Red;
			lblRussia.TextColor = RAIDA_Status.failsEcho[5] ? NSColor.Green : NSColor.Red;


			lblSwitzerland.TextColor = RAIDA_Status.failsEcho[6] ? NSColor.Green : NSColor.Red;
            lblUnitedKingdom.TextColor = RAIDA_Status.failsEcho[7] ? NSColor.Green : NSColor.Red;
			lblPunjab.TextColor = RAIDA_Status.failsEcho[8] ? NSColor.Green : NSColor.Red;
			lblIndia.TextColor = RAIDA_Status.failsEcho[9] ? NSColor.Green : NSColor.Red;
			lblCroatia.TextColor = RAIDA_Status.failsEcho[10] ? NSColor.Green : NSColor.Red;
			lblUSA.TextColor = RAIDA_Status.failsEcho[11] ? NSColor.Green : NSColor.Red;
			lblIndia2.TextColor = RAIDA_Status.failsEcho[12] ? NSColor.Green : NSColor.Red;
			lblTaiwan.TextColor = RAIDA_Status.failsEcho[13] ? NSColor.Green : NSColor.Red;
			lblMoscow.TextColor = RAIDA_Status.failsEcho[14] ? NSColor.Green : NSColor.Red;
            lblStPetersberg.TextColor = RAIDA_Status.failsEcho[15] ? NSColor.Green : NSColor.Red;
			lblColumbia.TextColor = RAIDA_Status.failsEcho[16] ? NSColor.Green : NSColor.Red;
			lblSingapore.TextColor = RAIDA_Status.failsEcho[17] ? NSColor.Green : NSColor.Red;
			lblGermany.TextColor = RAIDA_Status.failsEcho[18] ? NSColor.Green : NSColor.Red;
			lblCanada.TextColor = RAIDA_Status.failsEcho[19] ? NSColor.Green : NSColor.Red;
			lblVenezuela.TextColor = RAIDA_Status.failsEcho[20] ? NSColor.Green : NSColor.Red;
			lblHyderabad.TextColor = RAIDA_Status.failsEcho[21] ? NSColor.Green : NSColor.Red;
			lblUSA2.TextColor = RAIDA_Status.failsEcho[22] ? NSColor.Green : NSColor.Red;
			lblUkraine.TextColor = RAIDA_Status.failsEcho[23] ? NSColor.Green : NSColor.Red;
			lblLuxemberg.TextColor = RAIDA_Status.failsEcho[24] ? NSColor.Green : NSColor.Red;
			

			//lblAustralia.TextColor = NSColor.Red;
			Console.ForegroundColor = ConsoleColor.White;
			Console.Out.WriteLine("");
			Console.Out.WriteLine("");
			Console.Out.Write("  RAIDA Health: " + totalReady + " / 25: ");//"RAIDA Health: " + totalReady );
																		   //lblHealth.Text = "  RAIDA Health: " + totalReady + " / 25: ";

			// Running on the UI thread
			//lblHealth.Content = "  RAIDA Health: " + totalReady + " / 25: "; ;
            cmdEcho.Enabled = true;
            lblHealth.StringValue = "  RAIDA Health: " + totalReady + " / 25: ";
            cmdEcho.Enabled = true;

			//Check if enough are good 
			if (totalReady < 16)//
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Out.WriteLine("  Not enough RAIDA servers can be contacted to import new coins.");// );
				Console.Out.WriteLine("  Is your device connected to the Internet?");// );
				Console.Out.WriteLine("  Is a router blocking your connection?");// );
				Console.ForegroundColor = ConsoleColor.White;
                lblHealth.TextColor = NSColor.Red;
				return false;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Out.WriteLine("The RAIDA is ready for counterfeit detection.");// );
                lblHealth.TextColor = NSColor.Green;
				Console.ForegroundColor = ConsoleColor.White;
				return true;
			}//end if enough RAIDA
		}//End echo
		#endregion

		//strongly typed view accessor
		public new EchoView View
        {
            get
            {
                return (EchoView)base.View;
            }
        }
    }
}
