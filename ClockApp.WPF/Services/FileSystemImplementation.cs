using ClockApp.Core.Forms.Services;
using System;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(ClockApp.WPF.FileSystemImplementation))]
namespace ClockApp.WPF
{
    class FileSystemImplementation : IFileSystem
    {
        static int numDataChanged = 0;
        FileSystemWatcher watcher;

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
            watcher.Created += new FileSystemEventHandler(OnAppDataChanged);
            watcher.Deleted += new FileSystemEventHandler(OnAppDataChanged);
            watcher.Renamed += new RenamedEventHandler(OnAppDataRenamed);
            watcher.EnableRaisingEvents = true;
        }
        public void WatchFolder(string path)
        {
            WatchFolder();
        }

        private void OnAppDataChanged(object source, FileSystemEventArgs e)
        {
            numDataChanged++;
            String message = numDataChanged + "(WPF) File: " + e.FullPath + " " + e.ChangeType;
            //System.Windows.MessageBox.Show("(WPF) File: " + e.FullPath + " " + e.ChangeType);
            Xamarin.Forms.MessagingCenter.Send<ClockApp.Core.Forms.App, string>((ClockApp.Core.Forms.App)Xamarin.Forms.Application.Current, "AppDataChanged", message);
        }
        private void OnAppDataRenamed(object source, RenamedEventArgs e)
        {
            numDataChanged++;
            String message = numDataChanged + String.Format("(WPF) File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            //System.Windows.MessageBox.Show(String.Format("(WPF) File: {0} renamed to {1}", e.OldFullPath, e.FullPath));
            Xamarin.Forms.MessagingCenter.Send<ClockApp.Core.Forms.App, string>((ClockApp.Core.Forms.App)Xamarin.Forms.Application.Current, "AppDataChanged", message);
        }
    }
}
