using AppKit;
using Foundation;
using CloudCoinCore;
using System.Diagnostics;
using System.IO;

namespace CloudCoinIE.Mac
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public static FileUtils fileUtils;
        string defaultPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal) +
                                   Path.DirectorySeparatorChar + Config.HomeFolder + Path.DirectorySeparatorChar;

        public AppDelegate()
        {
            fileUtils = FileUtils.GetInstance(defaultPath);
            fileUtils.CreateDirectoryStructure();
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
