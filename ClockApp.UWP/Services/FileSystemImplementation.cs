using ClockApp.Core.Forms.Data;
using ClockApp.Core.Forms.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace ClockApp.UWP
{
    class FileSystemImplementation : IFileSystem
    {
        StorageFolder storageFolder;
        public event Action<FileSystemWatcherEventArgs> Event;

        Windows.Storage.Search.QueryOptions queryOptions = new Windows.Storage.Search.QueryOptions(Windows.Storage.Search.CommonFolderQuery.DefaultQuery);
        Windows.Storage.Search.StorageItemQueryResult query;
        IReadOnlyList<IStorageItem> oldFileList;

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
            query = storageFolder.CreateItemQueryWithOptions(queryOptions);

            query.ContentsChanged -= OnAppDataChanged;
            query.ContentsChanged += OnAppDataChanged;
            oldFileList = await query.GetItemsAsync();
        }

        // https://docs.microsoft.com/en-us/uwp/api/windows.storage.search.istoragequeryresultbase
        // https://docs.microsoft.com/en-us/uwp/api/windows.storage.search.storageitemqueryresult
        // https://docs.microsoft.com/en-us/uwp/api/windows.storage.istorageitem
        private async void OnAppDataChanged(Windows.Storage.Search.IStorageQueryResultBase sender, object args)
        {
            var newFileList = await query.GetItemsAsync();
            DiffSet diffSet = await Diff(oldFileList, newFileList);
            oldFileList = newFileList;
            foreach (IStorageItem file in diffSet.Added)
            {
                System.Diagnostics.Debug.WriteLine((file.IsOfType(StorageItemTypes.Folder) ? TargetType.Folder : TargetType.File));
                FileSystemWatcherObject o = new FileSystemWatcherObject(file.Name, file.Path, (file.IsOfType(StorageItemTypes.Folder) ? TargetType.Folder : TargetType.File));
                Event?.Invoke(FileSystemWatcherEventArgs.CreateCreatedEvent(o));
            }
            foreach (IStorageItem file in diffSet.Deleted)
            {
                System.Diagnostics.Debug.WriteLine((file.IsOfType(StorageItemTypes.Folder) ? TargetType.Folder : TargetType.File));
                FileSystemWatcherObject o = new FileSystemWatcherObject(file.Name, file.Path, (file.IsOfType(StorageItemTypes.Folder) ? TargetType.Folder : TargetType.File));
                Event?.Invoke(FileSystemWatcherEventArgs.CreateDeletedEvent(o));
            }
            foreach (IStorageItem file in diffSet.Changed)
            {
                System.Diagnostics.Debug.WriteLine((file.IsOfType(StorageItemTypes.Folder) ? TargetType.Folder : TargetType.File));
                FileSystemWatcherObject o = new FileSystemWatcherObject(file.Name, file.Path, (file.IsOfType(StorageItemTypes.Folder) ? TargetType.Folder : TargetType.File));
                Event?.Invoke(FileSystemWatcherEventArgs.CreateChangedEvent(o));
            }

        }

        public string GetPath()
        {
            return storageFolder.Path;
        }

        /*
         * Unfortunately we don't get any information about the sort of change or changed file - 
         * args doesn't provide such info, because they are always null. Also unfortunately FileTypeFilters 
         * are not assembled with watcher. What does it mean? For our above query example, we get same 
         * notification when .avi file is added as well as .txt file. Sad conclusion at the end
         */
        // an solution (check manually): https://stackoverflow.com/questions/15575926/identifying-file-changes-in-storagefolder
        private class DiffSet
        {
            public IReadOnlyList<IStorageItem> Added { get; set; }
            public IReadOnlyList<IStorageItem> Deleted { get; set; }
            public IReadOnlyList<IStorageItem> Changed { get; set; }
        }

        private static async Task<DiffSet> Diff(IEnumerable<IStorageItem> oldSet, IEnumerable<IStorageItem> newSet)
        {
            var newAsDict = newSet.ToDictionary(sf => sf.Path);

            var added = new List<IStorageItem>();
            var deleted = new List<IStorageItem>();
            var changed = new List<IStorageItem>();

            var fromOldSet = new HashSet<string>();

            foreach (var oldFile in oldSet)
            {
                if (!newAsDict.ContainsKey(oldFile.Path))
                {
                    deleted.Add(oldFile);
                    continue;
                }

                var oldBasicProperties = await oldFile.GetBasicPropertiesAsync();
                var newBasicProperties = await newAsDict[oldFile.Path].GetBasicPropertiesAsync();

                var oldDateModified = oldBasicProperties.DateModified;
                var newDateModified = newBasicProperties.DateModified;

                if (oldDateModified != newDateModified)
                {
                    changed.Add(oldFile);
                }

                fromOldSet.Add(oldFile.Path);
            }

            foreach (var newFile in newSet)
            {
                if (!fromOldSet.Contains(newFile.Path))
                    added.Add(newFile);
            }

            return new DiffSet
            {
                Added = added,
                Deleted = deleted,
                Changed = changed
            };
        }
    }
}
