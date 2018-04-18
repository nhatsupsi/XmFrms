using ClockApp.Core.Forms.Data;
using System;
namespace ClockApp.Core.Forms.Services
{
    public interface IFileSystem
    {
        event Action<FileSystemWatcherEventArgs> Event;
        bool WatchFolder();
        bool WatchFolder(String path);
        void Start();
        void Stop();
        void Resume();
        String GetPath();
    }
}
