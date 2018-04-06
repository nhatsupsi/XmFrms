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
        public FileSystemTrackerModel(Data.PlatformType platformType)
        {
            this.platformType = platformType;
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
        public Command StartCommand
        {
            get
            {
                return new Command(() => {
                    startWatching();
                });
            }
        }
        public void pageOnAppearing()
        {
            MessagingCenter.Subscribe<App, string>((App)Application.Current, "AppDataChanged", (sender, arg) => {
                ChangesText += String.Format("\n{0} --> {1}", DateTime.Now.ToString("h:mm:ss tt"), arg);
            });
        }
        public void pageOnDisappearing()
        {
            MessagingCenter.Unsubscribe<App, string>(this, "AppDataChanged");
        }
        public void startWatching()
        {
            switch (platformType)
            {
                case Data.PlatformType.MacOS:
                case Data.PlatformType.UWP:
                case Data.PlatformType.WPF:
                    DependencyService.Get<IFileSystem>().WatchFolder();
                    PathText = DependencyService.Get<IFileSystem>().GetPath();
                    break;
            }
        }
    }
}
