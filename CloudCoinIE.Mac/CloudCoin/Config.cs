using System;
using System.IO;

namespace CloudCoinCore
{
    public class Config
    {
        public static string HomeFolder = "CloudCoin";
        public static String DefaultHomeLocation = "";
		public static String importFolder =  "Import" + Path.DirectorySeparatorChar;
		public static String importedFolder = "Imported" + Path.DirectorySeparatorChar;
		public static String trashFolder =  "Trash" + Path.DirectorySeparatorChar;
		public static String suspectFolder = "Suspect" + Path.DirectorySeparatorChar;
		public static String frackedFolder = "Fracked" + Path.DirectorySeparatorChar;
		public static String bankFolder = "Bank" + Path.DirectorySeparatorChar;
		public static String templateFolder = "Templates" + Path.DirectorySeparatorChar;
		public static String counterfeitFolder = "Counterfeit" + Path.DirectorySeparatorChar;
		public static String directoryFolder = "Directory" + Path.DirectorySeparatorChar;
		public static String exportFolder = "Export" + Path.DirectorySeparatorChar;
		public static String languageFolder = "Language" + Path.DirectorySeparatorChar;
		public static String partialFolder = "Partial" + Path.DirectorySeparatorChar;

        public static String WorkSpaceKey = "workspace";
        public static String DisclaimerKey = "isDisclaimerShown";
        public Config()
        {
        }
    }
}
