﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClockApp.Core.Forms.Views
{
    public partial class AClonePage : ContentPage
    {
        Data.PlatformType platformType;
        String textTime = "Clock";

        public AClonePage( Data.PlatformType platformType)
        {
            InitializeComponent();
            this.platformType = platformType;
        }
        /*
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);
            SizeChanged += (object sender, EventArgs args) =>
            {
                if (this.Width > 0)
                    clockLabel.FontSize = this.Width / 6;
            };
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
                if (loggerLayout.Children.Count != 0)
                    loggerLayout.Children.RemoveAt(0);
            }
            removeButton.IsEnabled = loggerLayout.Children.Count > 0;
        }
        */
    }
}