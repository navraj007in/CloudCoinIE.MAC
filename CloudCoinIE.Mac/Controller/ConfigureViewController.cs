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

        }

        public override void ViewDidLoad() {
           
            var defaults = NSUserDefaults.StandardUserDefaults;
		
            string location = defaults.StringForKey("workspace");
            lblWorkspace.StringValue = defaults.StringForKey("workspace");
            lblWorkspaceDescription.StringValue = "By Clicking the Change Directory button, you can change the location of your working directory. If there are no working folders in the new location, new empty ones will be created. Any CloudCoins in your old root will stay in those folders and will not be deleted or moved. You can always change back to those folders to see their contents. This makes it easier for you to store you coins on a USB drive or have multiple accounts on the same computer.";


		}
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
