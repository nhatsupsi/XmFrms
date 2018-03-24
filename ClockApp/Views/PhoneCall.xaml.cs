using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ClockApp.Core.Forms.Views
{
    public partial class PhoneCall : ContentPage
    {
        public PhoneCall()
        {
            InitializeComponent();
            var pageModel = new ViewModel.PhoneCallModel();
            BindingContext = pageModel;
        }
        public PhoneCall(Data.PlatformType platformType)
        {
            InitializeComponent();
            var pageModel = new ViewModel.PhoneCallModel(platformType);
            BindingContext = pageModel;
        }
    }
}
