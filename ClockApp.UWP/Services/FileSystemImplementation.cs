using ClockApp.Core.Forms.Services;
using System;
using Windows.Storage;

namespace ClockApp.UWP
{
    class FileSystemImplementation : IFileSystem
    {
        static int numDataChanged = 0;
        StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
        Windows.Storage.Search.QueryOptions queryOptions = new Windows.Storage.Search.QueryOptions(Windows.Storage.Search.CommonFolderQuery.DefaultQuery);
        
        public void WatchFolder()
        {
            //throw new NotImplementedException();
            System.Diagnostics.Debug.WriteLine("I am here");
            startWatching();
        }

        public void WatchFolder(string path)
        {
            WatchFolder();
        }
        private async void startWatching()
        {
            System.Diagnostics.Debug.WriteLine("Folder Path: " + storageFolder.Path);

            queryOptions.FolderDepth = Windows.Storage.Search.FolderDepth.Deep;
            var success = await Windows.System.Launcher.LaunchFolderAsync(storageFolder);
            var query = storageFolder.CreateFileQueryWithOptions(queryOptions);

            query.ContentsChanged += OnAppDataChanged;
            var files = await query.GetFilesAsync();
        }

        public System.Collections.ObjectModel.ObservableCollection<string> Greetings { get; set; }
        private void OnAppDataChanged(Windows.Storage.Search.IStorageQueryResultBase sender, object args)
        {
            numDataChanged++;
            //System.Diagnostics.Debug.WriteLine("{0} Data changed", numDataChanged);
            //System.Diagnostics.Debug.WriteLine(sender);
            String message = numDataChanged + " Data changed";
            //Xamarin.Forms.MessagingCenter.Send<FileSystemImplementation>(this, "Hi");
            Xamarin.Forms.MessagingCenter.Send<ClockApp.Core.Forms.App, string>((ClockApp.Core.Forms.App)Xamarin.Forms.Application.Current, "AppDataChanged", message);
        }
    }
}
