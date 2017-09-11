using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace CloudCoinIE.Mac.Controller
{
    public partial class ConfigureViewController : AppKit.NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public ConfigureViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public ConfigureViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public ConfigureViewController() : base("ConfigureView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        //strongly typed view accessor
        public new ConfigureView View
        {
            get
            {
                return (ConfigureView)base.View;
            }
        }
    }
}
