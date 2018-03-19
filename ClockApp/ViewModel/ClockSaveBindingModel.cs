using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace ClockApp.ViewModel
{
    public class ClockSaveBindingModel : INotifyPropertyChanged
    {
        private DateTime dateTime;
        private StackLayout loggerLayout;
        public Command SaveCommand { get; }
        public Command RemoveCommand { get; }
        private List<View> stackLayoutSaveClockChildren;
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
                /*
                String textTime = DateTime.Now.ToString("h:mm:ss tt");
                loggerLayout.Children.Add(new Label
                {
                    Text = "Button clicked at " + textTime
                });
                    */
                this.ButtonText = "button Add clicked";
            });
            RemoveCommand = new Command(() => {
                this.ButtonText = "button Remove clicked";
                /*
                if(loggerLayout.Children.Count>0)
                    loggerLayout.Children.RemoveAt(0);
                    */
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
                    buttonText = value +" " +numClicked;
                    if(PropertyChanged!=null)
                    {
                        numClicked++;
                        PropertyChanged(this, new PropertyChangedEventArgs("ButtonText"));
                    }
                }
            }
        }

    }
}
