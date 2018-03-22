using ClockApp.Core.Forms.Data;
using System;
using Xamarin.Forms;

namespace ClockApp.Core.Forms
{
    public partial class ClockAppPage : ContentPage
    {
        public ClockAppPage()
        {
            InitializeComponent();
        }
        public ClockAppPage(PlatformType type)
        {
            InitializeComponent();
            labelWelcome.Text = String.Format("Welcome to Xamarin Forms for {0}!", type);
        }
    }
}
