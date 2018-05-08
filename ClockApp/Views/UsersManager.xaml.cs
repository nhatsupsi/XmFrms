using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace ClockApp.Core.Forms.Views
{
    public partial class UsersManager : ContentPage
    {
        ViewModel.UsersManagerModel pageModel;
        public UsersManager()
        {
            InitializeComponent();
            pageModel = new ViewModel.UsersManagerModel();
            BindingContext = pageModel;
        }
    }
}
