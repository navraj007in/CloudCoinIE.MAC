﻿using System;

using AppKit;
using Foundation;

namespace CloudCoinIE.Mac
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }
        bool isDisclaimerShown = false;
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.Title = "CloudCoin IE";

			// Do any additional setup after loading the view.
		}

       
        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }
    }
}
