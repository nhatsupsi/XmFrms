using ClockApp.Core.Forms.Services;
using System;
using Windows.Storage;

namespace ClockApp.UWP
{
    class FileSystemImplementation : IFileSystem
    {
        static int numDataChanged = 0;
        StorageFolder storageFolder;
        Windows.Storage.Search.QueryOptions queryOptions = new Windows.Storage.Search.QueryOptions(Windows.Storage.Search.CommonFolderQuery.DefaultQuery);
        
        public void WatchFolder()
        {
            startWatching();
        }

        public void WatchFolder(string path)
        {
            WatchFolder();
        }
        private async void startWatching()
        {
            storageFolder = ApplicationData.Current.LocalFolder;

            queryOptions.FolderDepth = Windows.Storage.Search.FolderDepth.Deep;
            var success = await Windows.System.Launcher.LaunchFolderAsync(storageFolder);
            var query = storageFolder.CreateFileQueryWithOptions(queryOptions);

            query.ContentsChanged += OnAppDataChanged;
            var files = await query.GetFilesAsync();
        }
        
        private void OnAppDataChanged(Windows.Storage.Search.IStorageQueryResultBase sender, object args)
        //object source, FileSystemEventArgs e
        {
            /*
             * Unfortunately we don't get any information about the sort of change or changed file - 
             * args doesn't provide such info, because they are always null. Also unfortunately FileTypeFilters 
             * are not assembled with watcher. What does it mean? For our above query example, we get same 
             * notification when .avi file is added as well as .txt file. Sad conclusion at the end
             */
            // args has no info about what changed. check manually
            // maybe an solution (manually): https://stackoverflow.com/questions/15575926/identifying-file-changes-in-storagefolder
            numDataChanged++;
            String message = numDataChanged + " Data changed";
            Xamarin.Forms.MessagingCenter.Send<ClockApp.Core.Forms.App, string>((ClockApp.Core.Forms.App)Xamarin.Forms.Application.Current, "AppDataChanged", message);
        }

        public string GetPath()
        {
            return storageFolder.Path;
        }
    }
}
