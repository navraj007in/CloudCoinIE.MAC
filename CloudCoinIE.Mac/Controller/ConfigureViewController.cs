using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using CloudCoinCore;

namespace CloudCoinIE.Mac.Controller
{
    public partial class ConfigureViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public ConfigureViewController(IntPtr handle) : base(handle)
        {
            Initialize();
	
		}
        

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public ConfigureViewController(NSCoder coder) : base(coder)
        {
            Initialize();
		}
        partial void backupClick(NSObject sender)
        {
			Banker bank = new Banker(AppDelegate.fileUtils);
			int[] bankTotals = bank.countCoins(AppDelegate.fileUtils.bankFolder);
			int[] frackedTotals = bank.countCoins(AppDelegate.fileUtils.frackedFolder);
			int[] partialTotals = bank.countCoins(AppDelegate.fileUtils.partialFolder);

			var dlg = NSOpenPanel.OpenPanel;
			dlg.CanChooseFiles = false;
			dlg.CanChooseDirectories = true;
			dlg.AllowsMultipleSelection = false;
			dlg.CanCreateDirectories = true;


			if (dlg.RunModal() == 1)
			{
				string msg = "Are you sure you want to backup your CloudCoin Directory?";

				var alert = new NSAlert()
				{
					AlertStyle = NSAlertStyle.Warning,
					InformativeText = msg,
					MessageText = "Backup CloudCoins",
				};
				alert.AddButton("OK");
				alert.AddButton("Cancel");

				nint num = alert.RunModal();

				if (num == 1000)
				{
					export(dlg.Urls[0].Path);
					String backupDir = dlg.Urls[0].Path;
					NSWorkspace.SharedWorkspace.SelectFile(backupDir,
														   backupDir);

				}

			}

		}

        public override void ViewDidLoad() {
           
            var defaults = NSUserDefaults.StandardUserDefaults;
		
            string location = defaults.StringForKey("workspace");
            lblWorkspace.StringValue = defaults.StringForKey("workspace");
            lblWorkspaceDescription.StringValue = "By Clicking the Change Directory button, you can change the location of your working directory. If there are no working folders in the new location, new empty ones will be created. Any CloudCoins in your old root will stay in those folders and will not be deleted or moved. You can always change back to those folders to see their contents. This makes it easier for you to store you coins on a USB drive or have multiple accounts on the same computer.";


		}

		public void export(string backupDir)
		{
			FileUtils fileUtils = AppDelegate.fileUtils;


			Banker bank = new Banker(fileUtils);
			int[] bankTotals = bank.countCoins(fileUtils.bankFolder);
			int[] frackedTotals = bank.countCoins(fileUtils.frackedFolder);
			int[] partialTotals = bank.countCoins(fileUtils.partialFolder);

			//updateLog("  Your Bank Inventory:");
			int grandTotal = (bankTotals[0] + frackedTotals[0] + partialTotals[0]);
			// state how many 1, 5, 25, 100 and 250
			int exp_1 = bankTotals[1] + frackedTotals[1] + partialTotals[1];
			int exp_5 = bankTotals[2] + frackedTotals[2] + partialTotals[2];
			int exp_25 = bankTotals[3] + frackedTotals[3] + partialTotals[3];
			int exp_100 = bankTotals[4] + frackedTotals[4] + partialTotals[4];
			int exp_250 = bankTotals[5] + frackedTotals[5] + partialTotals[5];
			//Warn if too many coins

			if (exp_1 + exp_5 + exp_25 + exp_100 + exp_250 == 0)
			{
				Console.WriteLine("Can not export 0 coins");
				return;
			}

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
			Exporter exporter = new Exporter(fileUtils);

			String tag = "backup";// reader.readString();
								  //Console.Out.WriteLine(("Exporting to:" + exportFolder));

			exporter.writeJSONFile(exp_1, exp_5, exp_25, exp_100, exp_250, tag, 1, backupDir);


			// end if type jpge or stack




			//MessageBox.Show("Export completed.", "Cloudcoins", MessageBoxButtons.OK);
		}// end export One

		partial void showFolders(NSObject sender)
        {
           // System.Diagnostics.Process.Start("/Applications/Finder.app");
            NSWorkspace.SharedWorkspace.SelectFile(AppDelegate.fileUtils.bankFolder, 
                                                   AppDelegate.fileUtils.bankFolder);
			var defaults = NSUserDefaults.StandardUserDefaults;
			Console.WriteLine(defaults.StringForKey("workspace"));

        }
        partial void changeFolders(NSObject sender)
        {
			//let defaults = NSUserDefaults.standardUserDefaults()
			//defaults.setObject("Coding Explorer", forKey: "

			var dlg = NSOpenPanel.OpenPanel;
            dlg.CanChooseFiles = false;
			dlg.CanChooseDirectories = true;
            dlg.AllowsMultipleSelection = false;
            dlg.CanCreateDirectories = true;
		

            if (dlg.RunModal() == 1)
            {
				string msg = "Are you sure you want to change your CloudCoin Directory?";

				var alert = new NSAlert()
				{
					AlertStyle = NSAlertStyle.Warning,
					InformativeText = msg,
					MessageText = "Change Workspace",
				};
				alert.AddButton("OK");
				alert.AddButton("Cancel");

				nint num = alert.RunModal();

				if (num == 1000)
				{
					Console.WriteLine(dlg.Urls[0].Path);
					var defaults = NSUserDefaults.StandardUserDefaults;
                    defaults.SetString(dlg.Urls[0].Path + System.IO.Path.DirectorySeparatorChar, "workspace");

                    FileUtils fileUtils = FileUtils.GetInstance(defaults.StringForKey("workspace"));
					fileUtils.CreateDirectoryStructure();
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    AppDelegate.fileUtils.rootFolder = fileUtils.rootFolder;
				}

		
			}
	    }
        // Call to load from the XIB/NIB file
        public ConfigureViewController() : base("ConfigureView", NSBundle.MainBundle)
        {
            Initialize();
			var defaults = NSUserDefaults.StandardUserDefaults;
			Console.WriteLine(defaults.StringForKey("workspace"));
			string location = defaults.StringForKey("workspace");
			lblWorkspaceDescription.StringValue = defaults.StringForKey("workspace");

		}

        // Shared initialization code
        void Initialize()
        {
			var defaults = NSUserDefaults.StandardUserDefaults;
	

		}

       
        #endregion

        //strongly typed view accessor
        public new ConfigureView View
        {
            get
            {
                return (ConfigureView)base.View;
            }
        }
    }
}
