using CoreServices;
using System;
using AppKit;
using ClockApp.Core.Forms.Services;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.Mac16.FileSystemImplementation))]
namespace ClockApp.Mac16
{
    public class FileSystemImplementation : IFileSystem
    {
        static int numDataChanged = 0;
        FSEventStream eventStream;
        public FileSystemImplementation()
        {
        }

        public string GetPath()
        {
            return eventStream.PathsBeingWatched.GetValue(0).ToString();
        }

        public void WatchFolder()
        {
            WatchFolder("/Users/nguyen/Desktop/untitledfolder");
        }
        public void WatchFolder(String path)
        {
            TimeSpan eventLatency = TimeSpan.FromSeconds(1);
            //https://developer.apple.com/documentation/coreservices/file_system_events/1455376-fseventstreamcreateflags
            eventStream = new FSEventStream(new[] { path }, eventLatency, FSEventStreamCreateFlags.FileEvents);
            eventStream.Events += OnAppDataChanged;
            eventStream.ScheduleWithRunLoop(NSRunLoop.Current);
            eventStream.Start();
        }
        void OnAppDataChanged(object sender, FSEventStreamEventsArgs e)
        {
            foreach (var evnt in e.Events)
            {
                numDataChanged++;
                String message = numDataChanged + " " + evnt;
                Xamarin.Forms.MessagingCenter.Send<ClockApp.Core.Forms.App, string>((ClockApp.Core.Forms.App)Xamarin.Forms.Application.Current, "AppDataChanged", message);
                //System.Diagnostics.Debug.WriteLine(evnt);
            }
        }
    }
}
