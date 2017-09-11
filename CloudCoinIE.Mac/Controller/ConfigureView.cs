using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace CloudCoinIE.Mac.Controller
{
    public partial class ConfigureView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public ConfigureView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public ConfigureView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion
    }
}
