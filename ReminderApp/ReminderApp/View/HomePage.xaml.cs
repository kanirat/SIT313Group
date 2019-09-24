using System;
using System.Collections.Generic;
using ReminderApp.ViewModel;

using Xamarin.Forms;

namespace ReminderApp.View
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModel(Navigation);
        }
    }
}
