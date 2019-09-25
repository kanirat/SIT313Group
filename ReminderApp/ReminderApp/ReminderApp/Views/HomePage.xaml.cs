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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            remindersList.ItemSelected += RemindersList_ItemSelected;
        }

        private void RemindersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            remindersList.SelectedItem = null;
        }
    }
}