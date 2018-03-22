using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.ViewModel
{
    public class ClockSaveBindingModel : INotifyPropertyChanged
    {
        private DateTime dateTime;
        public Command AClickedCommand { get; }
        public Command BClickedCommand { get; }
        //private StackLayout loggerLayout;
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
            AClickedCommand = new Command(() => {
                this.ButtonText = "button A clicked";
            });
            BClickedCommand = new Command(() => {
                this.ButtonText = "button B clicked";
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
                    buttonText = String.Format("{0} ({1}) at {2}", value, numClicked, this.DateTime.ToString("h:mm:ss tt"));
                    //buttonText = value +" " +numClicked + " at " + this.DateTime.ToString("h:mm:ss tt");
                    if(PropertyChanged!=null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ButtonText"));
                    }
                }
            }
        }

    }
}
