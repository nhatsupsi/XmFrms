using System;
using AppKit;
using ClockApp.Core.Forms.Data;
using ClockApp.Core.Forms.Services;
using CoreServices;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.Mac16.ShowStatusBoardImplementation))]
namespace ClockApp.Mac16
{
    public class ShowStatusBoardImplementation
    {
        public NSStatusBar statusBar;
        public NSStatusItem item;
        public ShowStatusBoardImplementation()
        {
            statusBar = NSStatusBar.SystemStatusBar;
            item = statusBar.CreateStatusItem(NSStatusItemLength.Variable);
        }

        public void Create(ContentPage[] contentPages)
        {
            //item.Title = "Popup";
            item.HighlightMode = true;
            item.Menu = new NSMenu("Popup");
            item.Image = NSImage.ImageNamed("Icon-29.png");

            for (int i = 0; i < contentPages.Length; i++)
            {
                var popupDialog = new NSMenuItem(contentPages[i].Title);

                popupDialog.Activated += (sender, e) => {
                    int index = getSelectedItemIndex(((NSMenuItem)sender).Title, contentPages);
                    //int index = getSelectedItemIndex(((NSMenuItem)sender), contentPages);
                    System.Diagnostics.Debug.WriteLine("Index "+index);
                    Xamarin.Forms.MessagingCenter.Send<ClockApp.Core.Forms.App, int>(
                        (ClockApp.Core.Forms.App)Xamarin.Forms.Application.Current,
                        "StatusBarItemChanged",
                        index
                    );
                    /*
                    Event?.Invoke(new ShowStatusEventArgs(index));
                    if(Event==null)
                        System.Diagnostics.Debug.WriteLine("Event is null");
                    System.Diagnostics.Debug.WriteLine("menu clicnked with index " + index);
                    */
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
        int getSelectedItemIndex(NSMenuItem sender, ContentPage[] contentPages)
        {
            return System.Int32.Parse(item.Menu.IndexOfItem(sender).ToString());
        }
    }
}
