
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Input;
using ClockApp.Core.Forms.Data;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.ViewModel
{
    class UsersManagerModel : INotifyPropertyChanged
    {
        private ObservableCollection<User> _userList = new ObservableCollection<User>();
        public ObservableCollection<User> UserList
        {
            get
            {
                return _userList;
            }
            set
            {
                _userList = value;
                OnPropertyChanged("UserList");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public UsersManagerModel()
        {
            MessagingCenter.Subscribe<App, String>((App)Application.Current, "ClipBoardOnCopy", (sender, textFromClipBoard) => {
                Device.BeginInvokeOnMainThread(async () => { await Application.Current.MainPage.DisplayAlert("Message", "Copy: " + textFromClipBoard, "Ok"); });
            });
            for (int i = 1; i < 20; i++)
            {
                UserList.Add(new User { DisplayName = "User "+i.ToString("00"), Password = String.Format("{0}{0}{0}{0}", i) });
            }
        }
    }
}
