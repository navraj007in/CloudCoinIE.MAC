using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace CloudCoinIE.Mac.Controller
{
    public partial class ImportViewController : AppKit.NSViewController
    {
        #region Constructors

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

        // Call to load from the XIB/NIB file
        public ImportViewController() : base("ImportView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
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
