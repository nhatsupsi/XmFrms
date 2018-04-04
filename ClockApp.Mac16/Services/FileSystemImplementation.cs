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
        public FileSystemImplementation()
        {
        }
        public void WatchFolder()
        {
            WatchFolder("/Users/nguyen/Desktop/untitledfolder");
        }
        public void WatchFolder(String path)
        {
            FSEventStream eventStream;
            TimeSpan eventLatency = TimeSpan.FromSeconds(1);
            eventStream = new FSEventStream(new[] { path }, eventLatency, FSEventStreamCreateFlags.FileEvents);
            eventStream.Events += OnFSEventStreamEvents;
            eventStream.ScheduleWithRunLoop(NSRunLoop.Current);
            eventStream.Start();
        }
        void OnFSEventStreamEvents(object sender, FSEventStreamEventsArgs e)
        {
            foreach (var evnt in e.Events)
            {
                System.Diagnostics.Debug.WriteLine(evnt);
            }
        }
    }
}
