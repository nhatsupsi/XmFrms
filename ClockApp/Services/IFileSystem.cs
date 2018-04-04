using System;
namespace ClockApp.Core.Forms.Services
{
    public interface IFileSystem
    {
        void WatchFolder();
        void WatchFolder(String path);
    }
}
