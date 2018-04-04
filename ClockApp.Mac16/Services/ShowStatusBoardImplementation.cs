using System;
using AppKit;
using ClockApp.Core.Forms.Services;
using CoreServices;
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
                watchFolder();
            }
        }
        public void watchFolder()
        {
            FSEventStream eventStream;
            TimeSpan eventLatency = TimeSpan.FromSeconds(1);
            eventStream = new FSEventStream(new[] { "/Users/nguyen/Desktop/untitledfolder" }, eventLatency, FSEventStreamCreateFlags.FileEvents);
            eventStream.Events += OnFSEventStreamEvents;
            eventStream.ScheduleWithRunLoop(NSRunLoop.Current);
            eventStream.Start();
            System.Diagnostics.Debug.WriteLine("I am here");
        }
        void OnFSEventStreamEvents(object sender, FSEventStreamEventsArgs e)
        {
            foreach (var evnt in e.Events)
            {
                System.Diagnostics.Debug.WriteLine(evnt);
            }
            //System.Diagnostics.Debug.WriteLine(e.Events);
        }
    }
}
