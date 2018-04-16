using ClockApp.Core.Forms.Services;
using System;
using Xamarin.Forms;
using System.IO;
using ClockApp.Core.Forms.Data;

[assembly: Dependency(typeof(ClockApp.WPF.FileSystemImplementation))]
namespace ClockApp.WPF
{
    class FileSystemImplementation : IFileSystem
    {
        FileSystemWatcher watcher;

        public event Action<FileSystemWatcherEventArgs> Event;

        public string GetPath()
        {
            return watcher.Path;
        }

        public void WatchFolder()
        {
            watcher = new FileSystemWatcher("C:\\Users\\TOSHIBA LAP\\Desktop\\untitledfolder", "*.*");
            watcher.IncludeSubdirectories = true;
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                    | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Changed += new FileSystemEventHandler(OnAppDataChanged);
            watcher.Created += new FileSystemEventHandler(OnAppDataCreated);
            watcher.Deleted += new FileSystemEventHandler(OnAppDataDeleted);
            watcher.Renamed += new RenamedEventHandler(OnAppDataRenamed);
            watcher.EnableRaisingEvents = true;
        }
        public void WatchFolder(string path)
        {
            WatchFolder();
        }

        private void OnAppDataChanged(object source, FileSystemEventArgs e)
        {
            FileSystemWatcherObject o = new FileSystemWatcherObject(e.Name, e.FullPath, (Directory.Exists(e.FullPath)) ? TargetType.Folder : TargetType.File);
            Event?.Invoke(FileSystemWatcherEventArgs.CreateChangedEvent(o));
        }
        private void OnAppDataCreated(object source, FileSystemEventArgs e)
        {
            FileSystemWatcherObject o = new FileSystemWatcherObject(e.Name, e.FullPath, (Directory.Exists(e.FullPath)) ? TargetType.Folder : TargetType.File);
            Event?.Invoke(FileSystemWatcherEventArgs.CreateCreatedEvent(o));
        }
        private void OnAppDataDeleted(object source, FileSystemEventArgs e)
        {
            FileSystemWatcherObject o = new FileSystemWatcherObject(e.Name, e.FullPath, (Directory.Exists(e.FullPath)) ? TargetType.Folder : TargetType.File);
            Event?.Invoke(FileSystemWatcherEventArgs.CreateDeletedEvent(o));
        }
        private void OnAppDataRenamed(object source, RenamedEventArgs e)
        {
            FileSystemWatcherObject newObject = new FileSystemWatcherObject(e.Name, e.FullPath, (Directory.Exists(e.FullPath)) ? TargetType.Folder : TargetType.File);
            FileSystemWatcherObject oldObject = new FileSystemWatcherObject(e.OldName, e.OldFullPath, (Directory.Exists(e.FullPath)) ? TargetType.Folder : TargetType.File);
            Event?.Invoke(FileSystemWatcherEventArgs.CreateRenamedEvent(newObject, oldObject));
        }
    }
}
