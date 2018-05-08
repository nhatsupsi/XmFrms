using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.Views
{
    public partial class ClockSaveBinding : ContentPage
    {
        public ClockSaveBinding()
        {
            InitializeComponent();
            var pageModel = new ViewModel.ClockSaveBindingModel();
            BindingContext = pageModel;
        }
    }
}
