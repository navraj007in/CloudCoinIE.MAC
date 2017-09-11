using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace CloudCoinIE.Mac
{
    public partial class EchoController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public EchoController(IntPtr handle) : base(handle)
        {
            Initialize();
        }
        partial void cmdEcho(NSObject sender)
        {
            lblEcho.StringValue = "Echoing";
        }
        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public EchoController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public EchoController() : base("Echo", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new Echo View
        {
            get
            {
                return (Echo)base.View;
            }
        }
    }
}
