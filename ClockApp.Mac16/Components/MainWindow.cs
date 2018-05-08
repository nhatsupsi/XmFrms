using System;

using Foundation;
using AppKit;
using CoreGraphics;

namespace ClockApp.Mac16
{
    public partial class MainWindow : NSWindow
    {
        public MainWindow(IntPtr handle) : base(handle)
        {
        }

        [Export("initWithCoder:")]
        public MainWindow(NSCoder coder) : base(coder)
        {
        }
        public MainWindow(CGRect contentRect, NSWindowStyle aStyle, NSBackingStore bufferingType, bool deferCreation) : base(contentRect, aStyle, bufferingType, deferCreation)
        {
            // Create the content view for the window and make it fill the window
            ContentView = new NSView(Frame);

        }
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();
        }
    }
}