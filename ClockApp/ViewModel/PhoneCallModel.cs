using System;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.ViewModel
{
    public class PhoneCallModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command defaultCallCommand;
        private Data.PlatformType platformType;
        public string defaultCallNumber = "0761111111";
        public string inputCallNumber = "";

        public PhoneCallModel()
        {
        }
        public PhoneCallModel(Data.PlatformType platformType)
        {
            this.platformType = platformType;
        }

        public Command InputCallCommand
        {
            get
            {
                return new Command(() => {
                    if (InputCallNumber != null && !(InputCallNumber.Equals("")) )
                        makeCall(InputCallNumber);
                    else
                        Device.BeginInvokeOnMainThread(async () => { await Application.Current.MainPage.DisplayAlert("Alert", "Input number is empty", "Ok"); });
                });
            }
        }
        public String InputCallNumber
        {
            get { return inputCallNumber; }
            set
            {
                if (value != inputCallNumber)
                {
                    inputCallNumber = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("InputCallNumberText"));
                }
            }
        }

        public String InputCallNumberText
        {
            get { return "Call: "+inputCallNumber; }
        }


        public Command DefaultCallCommand
        {
            get { return new Command(() => { makeCall(DefaultCallNumber); }); }
        }
        public String DefaultCallNumber
        {
            get
            {
                return defaultCallNumber;
            }
        }
        public String DefaultCallNumberText
        {
            get
            {
                return "Call: " + defaultCallNumber;
            }
        }

        private void makeCall(String number)
        {
            Debug.WriteLine("try to make a call from {0}", Device.RuntimePlatform);
            switch (platformType)
            {
                case Data.PlatformType.MacOS:
                case Data.PlatformType.iOS:
                case Data.PlatformType.Android:
                case Data.PlatformType.UWP:
                    Device.OpenUri(new Uri(("tel:" + number)));
                    break;
                case Data.PlatformType.WPF:
                    Device.OpenUri(new Uri(("tel:" + number)));
                    break;
            }
        }
    }

}
