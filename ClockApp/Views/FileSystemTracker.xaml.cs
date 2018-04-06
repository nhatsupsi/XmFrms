using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClockApp.Core.Forms.Views
{
    public partial class FileSystemTracker : ContentPage
    {
        Data.PlatformType platformType;
        ViewModel.FileSystemTrackerModel pageModel;

        public FileSystemTracker(Data.PlatformType platformType)
        {
            InitializeComponent();
            this.platformType = platformType;
            pageModel = new ViewModel.FileSystemTrackerModel(platformType);
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