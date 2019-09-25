using System;
using ReminderApp.Data;
using ReminderApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using ReminderApp.View;

using Xamarin.Forms;
namespace ReminderApp.ViewModel
{
    public class AddPageViewModel : BaseViewModel
    {
        

        private string _title;
        private string _description;
        private DateTime _date;
       // private DateTime _time;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

       /* public string Date
        {
            get { return _date; }
            set
            {
                _date =  value;
                OnPropertyChanged();
            }
        }*/

        public async Task AddReminder()
        {
            Reminder reminder = new Reminder();
            reminder.Title = Title;
            reminder.Description = Description;
            Database _database = new Database();
            await _database.AddReminderAsync(reminder);
        }

        public ICommand AddButtonClicked
        {
            protected set;
            get;
        }

        public AddPageViewModel()
        {
            this.AddButtonClicked = new Command(async () => await AddReminder());
        }
    }
}
