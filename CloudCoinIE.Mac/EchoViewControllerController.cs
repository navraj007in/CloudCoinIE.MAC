using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace CloudCoinIE.Mac
{
    public partial class EchoViewControllerController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public EchoViewControllerController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EchoViewControllerController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public EchoViewControllerController() : base("EchoViewController", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new EchoViewController View
        {
            get
            {
                return (EchoViewController)base.View;
            }
        }
    }
}
