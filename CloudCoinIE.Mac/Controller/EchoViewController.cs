using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace CloudCoinIE.Mac.Controller
{
    public partial class EchoViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public EchoViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EchoViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public EchoViewController() : base("EchoView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new EchoView View
        {
            get
            {
                return (EchoView)base.View;
            }
        }
    }
}
