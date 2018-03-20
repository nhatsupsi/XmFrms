using Xamarin.Forms;
using System;
using System.Collections.Generic;
namespace ClockApp.Views
{
    public partial class ClockSave : ContentPage
    {
        String textTime = "Clock";
        public ClockSave()
        {
            InitializeComponent();
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
            SizeChanged += (object sender, EventArgs args) =>
            {
                if (this.Width > 0)
                    clockLabel.FontSize = this.Width / 6;
            };
        }
        bool OnTimerTick()
        {
            textTime = DateTime.Now.ToString("h:mm:ss tt");
            clockLabel.Text = textTime;
            return true;
        }
        void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            if (button == addButton)
            {
                loggerLayout.Children.Add(new Label
                {
                    Text = "Button clicked at " + textTime
                });
            }
            else
            {
                loggerLayout.Children.RemoveAt(0);
            }
            removeButton.IsEnabled = loggerLayout.Children.Count > 0;
        }
    }
}