using CoreServices;
using System;
using AppKit;
using ClockApp.Core.Forms.Services;
using Foundation;
using Xamarin.Forms;
using ClockApp.Core.Forms.Data;

[assembly: Dependency(typeof(ClockApp.Mac16.FileSystemImplementation))]
namespace ClockApp.Mac16
{
    public class FileSystemImplementation : IFileSystem
    {
        static int numDataChanged = 0;
        FSEventStream eventStream;

        public event Action<FileSystemWatcherEventArgs> Event;

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
            eventStream = new FSEventStream(new[] { path }, eventLatency, FSEventStreamCreateFlags.FileEvents | FSEventStreamCreateFlags.NoDefer);
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
                System.Diagnostics.Debug.WriteLine(evnt);
                FileSystemWatcherObject o = new FileSystemWatcherObject(evnt.Path, evnt.Path, (evnt.Flags.HasFlag(FSEventStreamEventFlags.ItemIsDir) ? TargetType.Folder : TargetType.File));
                if(evnt.Flags.HasFlag(FSEventStreamEventFlags.ItemRenamed))
                {
                    Event?.Invoke(FileSystemWatcherEventArgs.CreateRenamedEvent(o));
                }
                else if (evnt.Flags.HasFlag(FSEventStreamEventFlags.ItemCreated))
                {
                    Event?.Invoke(FileSystemWatcherEventArgs.CreateCreatedEvent(o));
                }
                else if (evnt.Flags.HasFlag(FSEventStreamEventFlags.ItemRemoved))
                {
                    Event?.Invoke(FileSystemWatcherEventArgs.CreateDeletedEvent(o));
                }
                else if (evnt.Flags.HasFlag(FSEventStreamEventFlags.ItemModified))
                {
                    Event?.Invoke(FileSystemWatcherEventArgs.CreateChangedEvent(o));
                }
            }
        }
    }
}
