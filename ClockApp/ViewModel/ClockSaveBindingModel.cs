using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.ViewModel
{
    public class ClockSaveBindingModel : INotifyPropertyChanged
    {
        private DateTime dateTime;
        //private StackLayout loggerLayout;
        public Command SaveCommand { get; }
        public Command RemoveCommand { get; }
        //private List<View> stackLayoutSaveClockChildren;
        private String buttonText = "Not clicked";
        int numClicked = 0;
        public event PropertyChangedEventHandler PropertyChanged;

        public ClockSaveBindingModel()
        {
            this.DateTime = DateTime.Now;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                this.DateTime = DateTime.Now;
                return true;
            });
            SaveCommand = new Command(() => {
                this.ButtonText = "button Add clicked";
            });
            RemoveCommand = new Command(() => {
                this.ButtonText = "button Remove clicked";
            });
        }

        public DateTime DateTime
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
                    }
                }
            }
            get
            {
                return dateTime;
            }
        }
        /*
        public List<View> StackLayoutSaveClockChildren
        {
            get { return stackLayoutSaveClockChildren; }
            set
            {
                if (stackLayoutSaveClockChildren != value)
                {
                    stackLayoutSaveClockChildren = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("StackLayoutSaveClockChildren"));
                    }
                }
            }
        }
        */
        public String ButtonText{
            get { return buttonText; }
            set{
                if(buttonText!= value)
                {
                    numClicked++;
                    buttonText = value +" " +numClicked + " at " + this.DateTime.ToString("h:mm:ss tt");
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ButtonText"));
                    }
                }
            }
        }

    }
}
