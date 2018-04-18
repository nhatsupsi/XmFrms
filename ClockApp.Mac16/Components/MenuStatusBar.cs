using System;
using AppKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.Mac16.ShowStatusBoardImplementation))]
namespace ClockApp.Mac16
{
    public class ShowStatusBoardImplementation
    {
        public NSStatusBar statusBar;
        Core.Forms.App app;

        public ShowStatusBoardImplementation(Core.Forms.App app)
        {
            statusBar = NSStatusBar.SystemStatusBar;
            this.app = app;
        }

        public void Create(ContentPage[] contentPages)
        {
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
                    System.Diagnostics.Debug.WriteLine("Index "+index);
                    app.AppTabbedPage.CurrentPage = app.AppTabbedPage.Children[index];
                };
                item.Menu.AddItem(popupDialog);
            }
        }
        int getSelectedItemIndex(String title, ContentPage[] contentPages)
        {
            for (int i = 0; i < contentPages.Length; i++)
                if (contentPages[i].Title.Equals(title))
                    return i;
            return -1;
        }
    }
}
