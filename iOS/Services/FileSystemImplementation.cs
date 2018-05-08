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
        Boolean isStarted = false;

        public bool IsStarted
        {
            get { return isStarted; }
        }
        public string GetPath()
        {
            return "";
        }

        public void Resume()
        {
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public bool InitWatchFolder()
        {
            return InitWatchFolder("");
        }

        public bool InitWatchFolder(string path)
        {
            return false;
        }
    }
}
