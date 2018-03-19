using System;
using System.Collections.Generic;
using ClockApp.ViewModel;
using Xamarin.Forms;

namespace ClockApp.Views
{
    public partial class ClockSaveBinding : ContentPage
    {
        public ClockSaveBinding()
        {
            InitializeComponent();
            var pageModel = new ClockSaveBindingModel();
            BindingContext = pageModel;
        }
    }
}
