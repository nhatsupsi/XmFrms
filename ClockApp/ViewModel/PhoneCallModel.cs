using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.ViewModel
{
    public class PhoneCallModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Command defaultCallCommand;
        private Data.PlatformType platformType;
        public string defaultCallNumber = "0763213311";
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
            get
            {
                return new Command(() => {

                    Device.OpenUri(new Uri(("tel:" + DefaultCallNumber)));
                    //makeCall(DefaultCallNumber);
                });
            }
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
            if (platformType == Data.PlatformType.MacOS)
            {
                Device.OpenUri(new Uri(("tel:" + number)));
            }
            else if(platformType == Data.PlatformType.iOS || platformType == Data.PlatformType.Android)
            {
                // DependencyService
                // https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/#Overview
                // ios 
                // https://developer.xamarin.com/recipes/ios/shared_resources/phone/dial-phone-uri/
            }
            else
            {
                Device.OpenUri(new Uri(("tel:" + number)));
            }
        }
    }

}
