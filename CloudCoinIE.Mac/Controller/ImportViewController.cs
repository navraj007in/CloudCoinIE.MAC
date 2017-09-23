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

		private void resumeImport()
		{

            int count = Directory.GetFiles(AppDelegate.fileUtils.suspectFolder).Length;
			if (count > 0)
			{
                disableButtons();
				new Thread(() =>
				{

					Thread.CurrentThread.IsBackground = true;

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

						insufficientRAIDA();
                        enableButtons();
						return;
					}
					else
						import();

					/* run your code here */
				}).Start();

			}
		}
        partial void importClicked(NSObject sender)
        {
            DirectoryInfo di = new DirectoryInfo(AppDelegate.fileUtils.importFolder);

            int numStack = di.GetFiles("*.stack", SearchOption.TopDirectoryOnly).Length;
            int numJpg = di.GetFiles("*.jpg", SearchOption.TopDirectoryOnly).Length;
            int numJpeg = di.GetFiles("*.jpeg", SearchOption.TopDirectoryOnly).Length;
            int totalImportCount = numJpg + numJpeg + numStack;

            if (totalImportCount == 0)
            {
				var dlg = NSOpenPanel.OpenPanel;
				dlg.CanChooseFiles = true;
				dlg.CanChooseDirectories = false;
				dlg.AllowsMultipleSelection = true;

				dlg.AllowedFileTypes = new string[] { "stack", "jpg", "chest" };

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
							alert.AddButton("OK");
							alert.AddButton("Cancel");

							nint num = alert.RunModal();

							if (num == 1000)
							{
								File.Copy(filename, fileUtils.importFolder + Path.GetFileName(filename), true);
							}

						}
						updateLog("Copied " + filename + "to " +
								  fileUtils.importFolder + Path.GetFileName(filename));

					}


				}
			}


			//Check RAIDA Status

			int totalRAIDABad = 0;
			
            totalRAIDABad = RAIDA_Status.failsEcho.Where(c => c).Count();

			if (totalRAIDABad > 8)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.Out.WriteLine("You do not have enough RAIDA to perform an import operation.");
				Console.Out.WriteLine("Check to make sure your internet is working.");
				Console.Out.WriteLine("Make sure no routers at your work are blocking access to the RAIDA.");
				Console.Out.WriteLine("Try to Echo RAIDA and see if the status has changed.");
				Console.ForegroundColor = ConsoleColor.White;

                updateLog("You do not have enough RAIDA to perform an import operation.");
                updateLog("Check to make sure your internet is working.");
                updateLog("Make sure no routers at your work are blocking access to the RAIDA.");
                updateLog("Try to Echo RAIDA and see if the status has changed.");

                //txtImportLog.InsertText(new NSString());
                enableButtons();
                //cmdRestore.IsEnabled = true;

				return;
			}

            disableButtons();
            //cmdRestore.IsEnabled = false;
			//progressBar.Visibility = Visibility.Visible;
			new Thread(() =>
			{
				Thread.CurrentThread.IsBackground = true;
				import();

			}).Start();
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            resumeImport();
        }
        private void enableButtons() {
			BeginInvokeOnMainThread(() =>
			{
                try
                {
                    import_Click.Enabled = true;
                }
                catch(Exception e){
                    
                }
			});

		}
        private void disableButtons() {
			BeginInvokeOnMainThread(() =>
			{
                try
                {
                    import_Click.Enabled = false;
                }
                catch(Exception e) {
                    
                }
			});

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
            updateLog("Time to import " + detectionResults[0] + " Coins: " + stopwatch.Elapsed.ToCustomString() + "");
			BeginInvokeOnMainThread(() =>
			{
				import_Click.Enabled = true;
			});

			//RefreshCoins?.Invoke(this, new EventArgs());


            //cmdRestore.IsEnabled = true;
			//	cmdImport.IsEnabled = true;
			//	progressBar.Value = 100;
			
		}//end detect
		
		private void Detector_OnUpdateStatus(object sender, ProgressEventArgs e)
        {
            updateLog(e.Status);
            BeginInvokeOnMainThread(() =>
            {
                if (e.percentage > 0)
                {
                    importProgressBar.DoubleValue = e.percentage;
                    lblProgress.StringValue = Convert.ToString(e.percentage) + " % completed.";
                }


            });
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

		private void insufficientRAIDA()
		{

		}
		public void import()
		{


            //CHECK TO SEE IF THERE ARE UN DETECTED COINS IN THE SUSPECT FOLDER
            DirectoryInfo dirJPegs = new DirectoryInfo(fileUtils.suspectFolder);

            String[] suspectFileNames = new DirectoryInfo(fileUtils.suspectFolder).GetFiles("*.stack")
                                                                                  .Union(dirJPegs.GetFiles("jpeg"))
                                                                                  .Select(o => o.Name)
                                                                                  .ToArray();//Get all files in suspect folder
			if (suspectFileNames.Length > 0)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Out.WriteLine("  Finishing importing coins from last time...");//
				updateLog("  Finishing importing coins from last time...");

				Console.ForegroundColor = ConsoleColor.White;
				detect();
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
            enableButtons();
		}   // end import

        private void updateLog(String message) {
            BeginInvokeOnMainThread(() =>
            {
                NSString str = new NSString(message+ System.Environment.NewLine);
               // txtLogs.StringValue += message + System.Environment.NewLine;
                txtImportLog.InsertText(str);
                
            });

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
	public static class MyExtensions
	{
		public static string ToCustomString(this TimeSpan span)
		{
			return string.Format("{0:00}:{1:00}:{2:00}", span.Hours, span.Minutes, span.Seconds);
		}
	}
}
