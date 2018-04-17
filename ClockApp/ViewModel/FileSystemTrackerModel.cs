using ClockApp.Core.Forms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        FileSystemWatcherStatus fswStatus = FileSystemWatcherStatus.Stop;

        public FileSystemTrackerModel(Data.PlatformType platformType)
        {
            this.platformType = platformType;

            watcher.Event += Watcher_Event;
        }

        private void Watcher_Event(Data.FileSystemWatcherEventArgs e)
        {
            if(fswStatus== FileSystemWatcherStatus.Start)
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
            if (fswStatus == FileSystemWatcherStatus.Stop)
                startWatching();

            fswStatus = FileSystemWatcherStatus.Start;
        }
        public void pageOnDisappearing()
        {
            fswStatus = FileSystemWatcherStatus.Pause;
        }
        public void startWatching()
        {
            switch (platformType)
            {
                case Data.PlatformType.MacOS:
                case Data.PlatformType.UWP:
                case Data.PlatformType.WPF:
                    if ( fswStatus == FileSystemWatcherStatus.Stop)
                    {
                        watcher.WatchFolder();
                        PathText = watcher.GetPath();
                    }
                    break;
            }
        }
    }
}
