using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

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
                Console.WriteLine(dlg.Urls[0].Path);
				var defaults = NSUserDefaults.StandardUserDefaults;
                defaults.SetString(dlg.Urls[0].Path, "workspace");

			}
	    }
        // Call to load from the XIB/NIB file
        public ConfigureViewController() : base("ConfigureView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
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
