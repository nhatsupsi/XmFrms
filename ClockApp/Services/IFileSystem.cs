using ClockApp.Core.Forms.Data;
using System;
namespace ClockApp.Core.Forms.Services
{
    public interface IFileSystem
    {
        event Action<FileSystemWatcherEventArgs> Event;
        void WatchFolder();
        void WatchFolder(String path);
        String GetPath();
    }
}
