using System;
using AppKit;
using Xamarin.Forms;

namespace ClockApp.Mac16.Components
{
    public class SystemStatusBarComponent
    {
        public NSStatusBar statusBar;
        public void SetSystemStaticBar(ContentPage[] contentPages)
        {
            statusBar = NSStatusBar.SystemStatusBar;
            var item = statusBar.CreateStatusItem(NSStatusItemLength.Variable);
            //item.Title = "Popup";
            item.HighlightMode = true;
            item.Menu = new NSMenu("Popup");
            item.Image = NSImage.ImageNamed("Icon-29.png");

            for (int i = 0; i < contentPages.Length; i++)
            {
                var popupDialog = new NSMenuItem(contentPages[i].Title);

                popupDialog.Activated += (sender, e) => {
                    int index = getSelectedItemIndex(((NSMenuItem)sender).Title, contentPages);
                    Xamarin.Forms.MessagingCenter.Send<ClockApp.Core.Forms.App, int>(
                        (ClockApp.Core.Forms.App)Xamarin.Forms.Application.Current, 
                        "StatusBarItemChanged", 
                        index
                    );
                };
                item.Menu.AddItem(popupDialog);
            }
        }
        int getSelectedItemIndex(string title, ContentPage[] contentPages)
        {
            for (int i = 0; i < contentPages.Length; i++)
                if (contentPages[i].Title.Equals(title))
                    return i;
            return -1;
        }
    }
}
