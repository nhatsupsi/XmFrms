using System;
using System.ComponentModel;
using ClockApp.Core.Forms.Services;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.ViewModel
{
    public class PasswordSaveModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public String passwordText="";

        public PasswordSaveModel()
        {
            MessagingCenter.Subscribe<App, String>((App)Application.Current, "ClipBoardOnCopy", (sender, textFromClipBoard) => {
                Device.BeginInvokeOnMainThread(async () => { await Application.Current.MainPage.DisplayAlert("Message", "Copy: " + textFromClipBoard, "Ok"); });
            });
        }
        public String PasswordText
        {
            get { return passwordText; }
            set
            {
                if (value != passwordText)
                {
                    passwordText = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("PasswordText"));
                }
            }
        }
        public Command CopyCommand
        {
            get
            {
                return new Command(() => {
                    DependencyService.Get<IClipboard>().OnCopy(passwordText);
                });
            }
        }

    }
}
