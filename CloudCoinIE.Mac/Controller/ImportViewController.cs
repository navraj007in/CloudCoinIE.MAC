using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using CloudCoinCore;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace CloudCoinIE.Mac.Controller
{
    public partial class ImportViewController : AppKit.NSViewController
    {
		#region Constructors
		public static int timeout = 10000; // Milliseconds to wait until the request is ended. 


		public static int exportOnes = 0;
		public static int exportFives = 0;
		public static int exportTens = 0;
		public static int exportQtrs = 0;
		public static int exportHundreds = 0;
		public static int exportTwoFifties = 0;
		public static int exportJpegStack = 2;
		public static string exportTag = "";

        public static FileUtils fileUtils = AppDelegate.fileUtils;
		public EventHandler RefreshCoins;

        // Called when created from unmanaged code
        public ImportViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public ImportViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        partial void importClicked(NSObject sender)
        {
			var dlg = NSOpenPanel.OpenPanel;
			dlg.CanChooseFiles = true;
			dlg.CanChooseDirectories = false;
            dlg.AllowsMultipleSelection = true;

			dlg.AllowedFileTypes = new string[] { "stack", "jpg", "chest" };
            updateLog("Showing Dialog");
			if (dlg.RunModal() == 1)
			{
				// Nab the first file
				var url = dlg.Urls[0];
                for (int i = 0; i < dlg.Urls.Length; i++)
                {
                    Console.WriteLine(dlg.Urls[i].Path);
                    updateLog(dlg.Urls[i].Path);


                    var filename = dlg.Urls[i].Path;
					


					//var filename = Path.GetFileName(path);
					if (!File.Exists(fileUtils.importFolder + Path.DirectorySeparatorChar + Path.GetFileName(filename)))
                        File.Copy(filename, fileUtils.importFolder + Path.GetFileName(filename));
                    else
                    {
                        string msg = "File " + Path.GetFileName(filename) + " already exists. Do you want to overwrite it?";

                        var alert = new NSAlert()
                        {
                            AlertStyle = NSAlertStyle.Warning,
                            InformativeText = msg,
                                MessageText = "Import File",
						};
						alert.AddButton("Ok");
						alert.AddButton("Cancel");

						nint num = alert.RunModal();

                        if (num == 1000) {
							File.Copy(filename, fileUtils.importFolder + Path.GetFileName(filename), true);
						}
               
                    }
                    updateLog("Copied " + filename  + "to " + 
                              fileUtils.importFolder  + Path.GetFileName(filename));
                    
                }
		
				
			}

			int totalRAIDABad = 0;
			for (int i = 0; i < 25; i++)
			{
				if (RAIDA_Status.failsEcho[i])
				{
					totalRAIDABad += 1;
				}
			}
			if (totalRAIDABad > 8)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Out.WriteLine("You do not have enough RAIDA to perform an import operation.");
				Console.Out.WriteLine("Check to make sure your internet is working.");
				Console.Out.WriteLine("Make sure no routers at your work are blocking access to the RAIDA.");
				Console.Out.WriteLine("Try to Echo RAIDA and see if the status has changed.");
				Console.ForegroundColor = ConsoleColor.White;

                txtLogs.StringValue += ("You do not have enough RAIDA to perform an import operation.");
                txtLogs.StringValue += ("Check to make sure your internet is working.");
                txtLogs.StringValue += ("Make sure no routers at your work are blocking access to the RAIDA.");
                txtLogs.StringValue += ("Try to Echo RAIDA and see if the status has changed.");

                import_Click.Enabled = true;
				//cmdRestore.IsEnabled = true;

				return;
			}
            import_Click.Enabled = false;
			//cmdRestore.IsEnabled = false;
			//progressBar.Visibility = Visibility.Visible;
			new Thread(() =>
			{
				Thread.CurrentThread.IsBackground = true;
				import();

				/* run your code here */
				Console.WriteLine("Hello, world");
			}).Start();
        }

		public void detect()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Console.Out.WriteLine("");
			updateLog("  Detecting Authentication of Suspect Coins");

			Console.Out.WriteLine("  Detecting Authentication of Suspect Coins");// "Detecting Authentication of Suspect Coins");
			Detector detector = new Detector(fileUtils, timeout);

			detector.OnUpdateStatus +=  Detector_OnUpdateStatus;
			detector.txtLogs = txtLogs;
			int[] detectionResults = detector.detectAll();
			Console.Out.WriteLine("  Total imported to bank: " + detectionResults[0]);//"Total imported to bank: "
																					  //Console.Out.WriteLine("  Total imported to fracked: " + detectionResults[2]);//"Total imported to fracked: "
			updateLog("  Total imported to bank: " + detectionResults[0]);
			//updateLog("  Total imported to fracked: " + detectionResults[2]);
			// And the bank and the fractured for total
			Console.Out.WriteLine("  Total Counterfeit: " + detectionResults[1]);//"Total Counterfeit: "
			Console.Out.WriteLine("  Total Kept in suspect folder: " + detectionResults[3]);//"Total Kept in suspect folder: " 
			updateLog("  Total Counterfeit: " + detectionResults[1]);
			updateLog("  Total Kept in suspect folder: " + detectionResults[3]);
			updateLog("  Total Notes imported to Bank: " + detector.totalImported);

			//            showCoins();
			stopwatch.Stop();
			Console.Out.WriteLine(stopwatch.Elapsed + " ms");
			updateLog("Time to import " + detectionResults[0] + " Coins: " + stopwatch.Elapsed + "");

			RefreshCoins?.Invoke(this, new EventArgs());


            //cmdRestore.IsEnabled = true;
			//	cmdImport.IsEnabled = true;
			//	progressBar.Value = 100;
			
		}//end detect

        private void Detector_OnUpdateStatus(object sender, ProgressEventArgs e)
        {

        }
		 // Call to load from the XIB/NIB file
		public ImportViewController() : base("ImportView", NSBundle.MainBundle)
        {
            Initialize();

        }

        // Shared initialization code
        void Initialize()
        {
        }

		public void import()
		{

			//Check RAIDA Status

			//CHECK TO SEE IF THERE ARE UN DETECTED COINS IN THE SUSPECT FOLDER
            String[] suspectFileNames = new DirectoryInfo(fileUtils.suspectFolder).GetFiles().Select(o => o.Name).ToArray();//Get all files in suspect folder
			if (suspectFileNames.Length > 0)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Out.WriteLine("  Finishing importing coins from last time...");//
				updateLog("  Finishing importing coins from last time...");

				Console.ForegroundColor = ConsoleColor.White;
				//detect();
				Console.Out.WriteLine("  Now looking in import folder for new coins...");// "Now looking in import folder for new coins...");
				updateLog("  Now looking in import folder for new coins...");
			} //end if there are files in the suspect folder that need to be imported


			Console.Out.WriteLine("");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.Out.WriteLine("  Loading all CloudCoins in your import folder: ");// "Loading all CloudCoins in your import folder: " );
			Console.Out.WriteLine(fileUtils.importFolder);
			updateLog("  Loading all CloudCoins in your import folder: ");
			updateLog(fileUtils.importFolder);

			Console.ForegroundColor = ConsoleColor.White;
			Importer importer = new Importer(fileUtils);
			if (!importer.importAll())//Moves all CloudCoins from the Import folder into the Suspect folder. 
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Out.WriteLine("  No coins in import folder.");// "No coins in import folder.");
				updateLog("No coins in import Folder");

				Console.ForegroundColor = ConsoleColor.White;
				
			}
			else
			{
				detect();
			}//end if coins to import
		}   // end import

        private void updateLog(String message) {
            BeginInvokeOnMainThread(() =>
                                    txtLogs.StringValue += message + System.Environment.NewLine);
        }
		#endregion

		//strongly typed view accessor
		public new ImportView View
        {
            get
            {
                return (ImportView)base.View;
            }
        }
    }
}
