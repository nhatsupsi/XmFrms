using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.Views
{
    public partial class PasswordSave : ContentPage
    {
        public PasswordSave()
        {
            InitializeComponent();
            var pageModel = new ViewModel.PasswordSaveModel();
            BindingContext = pageModel;
        }
    }
}
