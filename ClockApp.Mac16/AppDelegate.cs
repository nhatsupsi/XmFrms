using AppKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

namespace ClockApp.Mac16
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        //NSWindow window;
        private MainWindowController mainWindowController;
        public AppDelegate()
        {
            mainWindowController = new MainWindowController("ClockApp");
            //mainWindowController.Window.MakeKeyAndOrderFront(this);
        }
        public override NSWindow MainWindow
        {
            get { return mainWindowController.Window; }
        }
        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            Core.Forms.App app = new Core.Forms.App(Core.Forms.Data.PlatformType.MacOS);
            LoadApplication(app);

            MenuStatusBar menuStatusBar = new MenuStatusBar(app);
            menuStatusBar.Create(app.TabbedPageContent);

            base.DidFinishLaunching(notification);
        }
    }
}
