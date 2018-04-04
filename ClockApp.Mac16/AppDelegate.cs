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
            //----------------- Status Bar ------------------//
            NSStatusBar statusBar = NSStatusBar.SystemStatusBar;

            var item = statusBar.CreateStatusItem(NSStatusItemLength.Variable);
            item.Image = NSImage.ImageNamed("Icon-29.png");
            item.HighlightMode = false;
            item.Menu = new NSMenu("Popup");

            var popupDialog = new NSMenuItem("Show");
            popupDialog.Activated += (sender, e) => {
                var alert = new NSAlert()
                {
                    AlertStyle = NSAlertStyle.Informational,
                    InformativeText = "Popup showed ...",
                    MessageText = "PopUP"
                };
                alert.RunModal();
                return;
            };
            item.Menu.AddItem(popupDialog);
            //-----------------------------------------------//



            Forms.Init();
            LoadApplication(new Core.Forms.App(Core.Forms.Data.PlatformType.MacOS));
            base.DidFinishLaunching(notification);
        }
    }
}
