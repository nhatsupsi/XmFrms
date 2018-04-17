using System;
using ClockApp.Core.Forms.Data;
using ClockApp.Core.Forms.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClockApp.iOS.FileSystemImplementation))]
namespace ClockApp.iOS
{
    public class FileSystemImplementation : IFileSystem
    {
        public event Action<FileSystemWatcherEventArgs> Event;

        public string GetPath()
        {
            return "";
        }

        public void WatchFolder()
        {
        }

        public void WatchFolder(string path)
        {
            WatchFolder();
        }
    }
}
