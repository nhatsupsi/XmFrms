using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClockApp.Core.Forms
{
	public partial class HelloXamarin : ContentPage
    {
        public HelloXamarin()
        {
            InitializeComponent();
        }
        public HelloXamarin(Data.PlatformType type)
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
        }
        protected override void OnDisappearing()
        {
            Debug.WriteLine("OnDisappearing");
        }
    }
}