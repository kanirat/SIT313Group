using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

using ReminderApp.Models;
using ReminderApp.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ReminderApp.ViewModels
{
    public class AddReminderViewModel : BaseViewModel
    {
        #region Private Variables
        private string _title;
        private string _description;
        private DateTime _date;
        private TimeSpan _time;
        #endregion

        #region Public Variables
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public DateTime Date
        {
            get { return _date; }

            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }

        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged("Time");
            }
        }
        #endregion
        #region Constructor
        public AddReminderViewModel()
        {
            this.AddButtonClicked = new Command(async () => await AddReminder());

        }
        #endregion
        #region Commands
        /*    public ICommand AddReminderCommand
            {
                get
                {
                    return new Command(() =>
                    {
                        try
                        {
                            // App.Current.MainPage.Navigation.PopAsync();

                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message);
                        }
                        finally
                        {

                        }

                    });
                }
            }*/

        public ICommand AddButtonClicked
        {
            protected set;
            get;
        }
        #endregion


        public async Task AddReminder()
        {
            Reminder reminder = new Reminder();
            reminder.Title = Title;
            reminder.Description = Description;
            reminder.Date = Date.ToShortDateString();
            await App.Current.MainPage.DisplayAlert("Alert", reminder.Date, "Ok");
            reminder.Time = Time.ToString();
            Database _database = new Database();
            await _database.AddReminderAsync(reminder);
        }

    }
}
