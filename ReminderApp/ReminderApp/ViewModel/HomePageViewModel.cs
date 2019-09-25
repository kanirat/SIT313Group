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
    public class HomePageViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public HomePageViewModel()
        {

        }

        public INavigation Navigation { get; set; }

        

        Database _database = new Database();

        private ObservableCollection<Reminder> _reminderList;

        public ObservableCollection<Reminder> ReminderList
        {
            get { return _reminderList; }

            set
            {
                _reminderList = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ReminderList"));
            }
        }

        public async Task FetchDataAsync()
        {
            var list = await _database.GetAllRemindersAsync();
            ReminderList = new ObservableCollection<Reminder>(list);
        }
        
        public HomePageViewModel(INavigation navigation)
        {

            this.Navigation = navigation;

            this.AddButtonClicked = new Command(async () => await GoToAdd());
            this.UpdateButtonClicked = new Command(async () => await GoToUpdate());
            


            
            FetchDataAsync();
            
        }

        public ICommand AddButtonClicked
        {
            protected set;
            get;
        }

        

        public async Task GoToAdd()
        {
            await Navigation.PushAsync(new AddPage());
        }

        public ICommand UpdateButtonClicked
        {
            protected set;
            get;
        }

        public async Task GoToUpdate()
        {
            await Navigation.PushAsync(new UpdatePage());
        }

    }
}
