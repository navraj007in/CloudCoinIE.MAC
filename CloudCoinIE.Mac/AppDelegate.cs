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
			bool isDisclaimerShown = false;
			var defaults = NSUserDefaults.StandardUserDefaults;
            try
            {
                isDisclaimerShown = defaults.BoolForKey(Config.DisclaimerKey);
            }
            catch(Exception exe) {
                isDisclaimerShown = false;
                Console.WriteLine(exe.Message);
            }


			try
            {
                if (defaults.StringForKey(Config.WorkSpaceKey).Length == 0)
                    fileUtils = FileUtils.GetInstance(defaultPath);
                else
                    fileUtils = FileUtils.GetInstance(defaults.StringForKey(Config.WorkSpaceKey));
                fileUtils.CreateDirectoryStructure();


                if (!isDisclaimerShown)
                {
                    string msg = "CloudCoin Investor's Edition. V 9/22/2017. This software is provided as is with " +
                        "all faults, defects and errors, and without warranty of any kind. Free from the CloudCoin Consortium." +
                        "Click Agree to Proceed.";

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
                        defaults.SetBool(true, Config.DisclaimerKey);
                    }
                    else
                    {
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                }
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
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
