using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ClockApp.Core.Forms.Views
{
    public partial class FSTracker : ContentPage
    {
        Data.PlatformType platformType;
        ViewModel.FSTrackerModel pageModel;
        public FSTracker(Data.PlatformType platformType)
        {
            InitializeComponent();
            pageModel = new ViewModel.FSTrackerModel(platformType);
            BindingContext = pageModel;
        }
        protected override void OnAppearing()
        {
            pageModel.pageOnAppearing();
        }
        protected override void OnDisappearing()
        {
            pageModel.pageOnDisappearing();
        }
    }
}
