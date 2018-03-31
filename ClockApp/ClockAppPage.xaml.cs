using ClockApp.Core.Forms.Data;
using System;
using System.Diagnostics;
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
        public void labelWelcomeAdd(String text)
        {
            labelWelcome.Text += " " + text;
        }
        protected override void OnAppearing()
        {
            Debug.WriteLine("OnAppearing");
            Button a = new Button();
        }
        protected override void OnDisappearing()
        {
            Debug.WriteLine("OnDisappearing");
        }
    }
}
