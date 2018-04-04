using System;
using System.IO;

using Foundation;
using AppKit;
using CoreServices;

namespace ClockApp.Mac16
{
    public partial class MainWindowControllerController : NSWindowController
    {
        public MainWindowControllerController(IntPtr handle) : base(handle)
        {
        }

        [Export("initWithCoder:")]
        public MainWindowControllerController(NSCoder coder) : base(coder)
        {
        }

        public MainWindowControllerController() : base("MainWindowController")
        {
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }

        public new MainWindowController Window
        {
            get { return (MainWindowController)base.Window; }
        }
    }
}
