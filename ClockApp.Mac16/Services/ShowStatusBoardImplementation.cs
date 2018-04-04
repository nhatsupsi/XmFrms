using System;
using AppKit;
using ClockApp.Core.Forms.Services;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.Mac16.ShowStatusBoardImplementation))]
namespace ClockApp.Mac16
{
    public class ShowStatusBoardImplementation : ClockApp.Core.Forms.Services.IShowStatusBoard
    {
        static int num = 0;
        public ShowStatusBoardImplementation()
        {
        }
        private void OnChanged(object source, System.IO.FileSystemEventArgs e)
        {
            var alert = new NSAlert()
            {
                AlertStyle = NSAlertStyle.Informational,
                InformativeText = "content changed ...",
                MessageText = "FileSystemWatcher"
            };
            alert.RunModal();
        }
        public void Show()
        {
            if(num==0){
                //----------------- Status Bar ------------------//
                NSStatusBar statusBar = NSStatusBar.SystemStatusBar;
                var item = statusBar.CreateStatusItem(NSStatusItemLength.Variable);
                //item.Title = "Popup";
                item.HighlightMode = true;
                item.Menu = new NSMenu("Popup");
                item.Image=NSImage.ImageNamed("Icon-29.png");

                var popupDialog = new NSMenuItem("Show");
                popupDialog.Activated += (sender, e) => {
                    var alert = new NSAlert()
                    {
                        AlertStyle = NSAlertStyle.Informational,
                        InformativeText = "Popup showed ...",
                        MessageText = "PopUP"
                    };
                    alert.RunModal();
                };
                item.Menu.AddItem(popupDialog);
                num++;
            }
        }
    }
}
