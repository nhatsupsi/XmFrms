using System;
using System.Collections.Generic;
using ClockApp.Core.Forms.Services;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.Views
{
    public partial class PasswordSave : ContentPage
    {
        Data.PlatformType platformType;
        public PasswordSave(Data.PlatformType platformType)
        {
            InitializeComponent();
            this.platformType = platformType;
            var pageModel = new ViewModel.PasswordSaveModel();
            BindingContext = pageModel;
        }
        protected override void OnAppearing()
        {
            if (platformType == Data.PlatformType.MacOS)
                DependencyService.Get<IShowStatusBoard>().Create(App.tabbedPageContent);
        }
    }
}
