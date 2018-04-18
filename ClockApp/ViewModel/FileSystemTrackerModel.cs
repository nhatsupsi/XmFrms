using ClockApp.Core.Forms.Services;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.ViewModel
{
    class FileSystemTrackerModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public String pathText = "";
        public String changesText = "";
        Data.PlatformType platformType;

        IFileSystem watcher = DependencyService.Get<IFileSystem>();

        public FileSystemTrackerModel(Data.PlatformType platformType)
        {
            this.platformType = platformType;

            watcher.Event += Watcher_Event;
        }

        private void Watcher_Event(Data.FileSystemWatcherEventArgs e)
        {
            ChangesText += e.ToString() + "\n";
        }

        public String PathText
        {
            get { return pathText; }
            set
            {
                if (value != pathText)
                {
                    pathText = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PathText"));
                }
            }
        }
        public String ChangesText
        {
            get { return changesText; }
            set
            {
                if (value != changesText)
                {
                    changesText = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("ChangesText"));
                }
            }
        }
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
