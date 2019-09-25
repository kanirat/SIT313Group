using ReminderApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddReminder : ContentPage
    {
        public AddReminder()
        {
            InitializeComponent();
            
        }
        public AddReminder(ReminderListModel data)
        {
            InitializeComponent();
        }

        private void calenderIcon_Tapped(object sender, EventArgs e)
        {
            datepicker.Focus();
        }

        private void clockIcon_Tapped(object sender, EventArgs e)
        {
            timepicker.Focus();
        }

        private void BackButtonTapped(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}