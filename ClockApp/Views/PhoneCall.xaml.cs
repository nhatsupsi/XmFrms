using System;
using System.Collections.Generic;
using ClockApp.Core.Forms.Services;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.Views
{
    public partial class PhoneCall : ContentPage
    {
        Data.PlatformType platformType;
        public PhoneCall(Data.PlatformType platformType)
        {
            InitializeComponent();
            this.platformType = platformType;
            var pageModel = new ViewModel.PhoneCallModel(platformType);
            BindingContext = pageModel;
        }
        protected override void OnAppearing()
        {
            //if (platformType == Data.PlatformType.MacOS)
            //    DependencyService.Get<IShowStatusBoard>().Create(App.tabbedPageContent);
        }
    }
}
