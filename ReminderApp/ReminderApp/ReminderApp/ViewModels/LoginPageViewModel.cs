using ReminderApp.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ReminderApp.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Private Variables
        private string _email;
        private string _password;
        #endregion

        #region Public Variables
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        #endregion
        #region Constructor
        public LoginPageViewModel()
        {

        }
        #endregion
        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new Command(async (obj) =>
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(Email))
                        {
                            if (!String.IsNullOrEmpty(Password))
                            {
                                if (Email == "Admin" && Password == "Admin")
                                {
                                    await App.Current.MainPage.Navigation.PushAsync(new HomePage());
                                }
                                else
                                {
                                    await App.Current.MainPage.DisplayAlert("Alert", "Incorrect username or password", "Ok");
                                }
                            }
                            else
                            {
                                await App.Current.MainPage.DisplayAlert("Alert", "Please fill the password", "Ok");
                            }
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("Alert", "Please fill the email address", "Ok");
                        }
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
    }
}
