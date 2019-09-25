using ReminderApp.Models;
using ReminderApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ReminderApp.Data;

namespace ReminderApp.ViewModels
{
    public class HomePageViewModel : BaseViewModel
    {
        #region Private Variables
        private ObservableCollection<ReminderListModel> _remindersList = new ObservableCollection<ReminderListModel>();
        private ReminderListModel _reminderItem;
        #endregion


        public ReminderListModel ReminderItem
        {
            get { return _reminderItem; }
            set
            {
                _reminderItem = value;
                OnPropertyChanged("ReminderItem");
                if (ReminderItem != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new AddReminder(ReminderItem));
                }
            }
        }




        #region Public Variables
        public ObservableCollection<ReminderListModel> RemindersList
        {
            get { return _remindersList; }
            set
            {
                _remindersList = value;
                OnPropertyChanged("RemindersList");
            }
        }
        #endregion
        #region Constructor
        public HomePageViewModel()
        {
            //GetRemindersData();
            FetchDataAsync();
        }

        
        #endregion
        #region Commands
        public ICommand AddReminderTap
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        App.Current.MainPage.Navigation.PushAsync(new AddReminder());
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    finally
                    {

                    }

                });
            }
        }

        public ICommand LogoutTap
        {
            get
            {
                return new Command(() =>
                {
                    try
                    {
                        App.Current.MainPage.Navigation.PopToRootAsync();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }
                    finally
                    {

                    }

                });
            }
        }
        #endregion





        #region Methods
        /*private void GetRemindersData()
        {
            Database _data = new Database();
            foreach (Reminder _reminder in _data.GetAllRemindersAsync())
                {
                }

           // var item = new ReminderListModel() { Id = 1, Title = "Meeting", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.", Date = "10 Sep 2019", Time = "05 : 00 PM" };
            for(var i = 0; i < 5 ; i++)
            {
                RemindersList.Add(item);
            }
        }*/
        #endregion

        Database _database = new Database();

        private ObservableCollection<Reminder> _reminderList;

        public ObservableCollection<Reminder> ReminderList
        {
            get { return _reminderList; }

            set
            {
                _reminderList = value;
                OnPropertyChanged("RemindersList");
            }
        }



        public async Task FetchDataAsync()
        {
            var list = await _database.GetAllRemindersAsync();
            ReminderList = new ObservableCollection<Reminder>(list);
        }

    }
}
