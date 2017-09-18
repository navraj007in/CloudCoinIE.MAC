using AppKit;
using Foundation;
using CloudCoinCore;
using System.Diagnostics;
using System.IO;
using System;
namespace CloudCoinIE.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public static FileUtils fileUtils;
        string defaultPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) + Path.DirectorySeparatorChar
                                    + Config.HomeFolder + Path.DirectorySeparatorChar;

        public AppDelegate()
        {
		
            var defaults = NSUserDefaults.StandardUserDefaults;
            if (defaults.StringForKey("workspace").Length == 0)
                fileUtils = FileUtils.GetInstance(defaultPath);
            else
                fileUtils = FileUtils.GetInstance(defaults.StringForKey("workspace"));
            fileUtils.CreateDirectoryStructure();

			
            bool isDisclaimerShown = defaults.BoolForKey("isDisclaimerShown");
			if (!isDisclaimerShown)
			{
				string msg = "CloudCoin Investor's Edition. V 9/11/2017. This software is provided as is with " +
                    "all faults, defects and errors, and without and warranty of any kind. Free from the CloudCoin Consortium." +
                    "Click Agree to Proceed";

				var alert = new NSAlert()
				{
					AlertStyle = NSAlertStyle.Warning,
					InformativeText = msg,
					MessageText = "Disclaimer",
				};
				alert.AddButton("Agree");
				alert.AddButton("Disagree");

                nint num = alert.RunModal();

				if (num == 1000)
				{
                    defaults.SetBool(true,"isDisclaimerShown");
				}
                else {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
			}

		}

        public override void DidFinishLaunching(NSNotification notification)
        {
            
            // Insert code here to initialize your application
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application
        }

    }
}
