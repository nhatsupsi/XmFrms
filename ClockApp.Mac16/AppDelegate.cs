using AppKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace ClockApp.Mac16
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow window;
        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;
            var rect = new CoreGraphics.CGRect(200, 1000, 1024, 768);
            window = new NSWindow(rect, style, NSBackingStore.Buffered, false);
        }
        public override NSWindow MainWindow
        {
            get { return window; }
        }


        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            LoadApplication(new Core.Forms.App(Core.Forms.Data.PlatformType.MacOS));
            base.DidFinishLaunching(notification);
        }
    }
}
