
using System;
using System.IO;

using Foundation;
using AppKit;
using CoreServices;

namespace ClockApp.Mac16
{
    public partial class MainWindowController : NSWindowController
    {
        public MainWindowController(IntPtr handle) : base(handle)
        {
        }

        [Export("initWithCoder:")]
        public MainWindowController(NSCoder coder) : base(coder)
        {
        }

        public MainWindowController(String title) : base("MainWindowController")
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;
            var rect = new CoreGraphics.CGRect(200, 1000, 1024, 768);
            base.Window = new MainWindow(rect, style, NSBackingStore.Buffered, false);
            base.Window.Title = title;
        }

        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }

        public new MainWindow Window
        {
            get { return (MainWindow)base.Window; }
        }
    }
}
