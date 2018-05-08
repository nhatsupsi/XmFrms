using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ClockApp.Core.Forms.Data;
using ClockApp.Core.Forms.Services;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.ViewModel
{
    class FSTrackerModel: INotifyPropertyChanged
    {
        /***************** PropertyChanged config *****************/
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        /***************** Data config *****************/
        private ObservableCollection<FileSystemWatcherEventArgs> _changeList = new ObservableCollection<FileSystemWatcherEventArgs>();
        public ObservableCollection<FileSystemWatcherEventArgs> ChangeList
        {
            get
            {
                return _changeList;
            }
            set
            {
                _changeList = value;
                OnPropertyChanged("ChangeList");
            }
        }

        string _path="null";
        public String PathText
        {
            get
            {
                return _path;
            }
            set
            {
                _path = value;
                OnPropertyChanged("PathText");
            }
        }



        /***************** Costructor *****************/
        Data.PlatformType platformType;

        IFileSystem watcher = DependencyService.Get<IFileSystem>();
        public FSTrackerModel(Data.PlatformType platformType)
        {
            this.platformType = platformType;

            watcher.Event += Watcher_Event;
        }
        private void Watcher_Event(Data.FileSystemWatcherEventArgs e)
        {
            if(platformType== Data.PlatformType.UWP)
                Device.BeginInvokeOnMainThread(() =>
                {
                    ChangeList.Add(e);
                });
            else
                ChangeList.Add(e);

        }



        /***************** Watcher config *****************/

        public void pageOnAppearing()
        {
            if (!watcher.IsStarted)
                startWatching();
            else
                watcher.Resume();
        }
        public void pageOnDisappearing()
        {
            watcher.Stop();
        }
        public void startWatching()
        {
            switch (platformType)
            {
                case Data.PlatformType.MacOS:
                case Data.PlatformType.UWP:
                case Data.PlatformType.WPF:
                    if (watcher.InitWatchFolder())
                    {
                        PathText = watcher.GetPath();
                        watcher.Start();
                    }
                    break;
            }
        }
    }
}
