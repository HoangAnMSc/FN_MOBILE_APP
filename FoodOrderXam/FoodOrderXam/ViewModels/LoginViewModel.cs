using System;
using System.Threading.Tasks;
using DemoApp.Services;
using FoodOrderXam.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

// ReSharper disable All

namespace FoodOrderXam.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;

        public string Username
        {
            set
            {
                this._username = value;
                OnPropertyChanged();
            }
            get => this._username;
        }

        private string _password;

        public string Password
        {
            set
            {
                this._password = value;
                OnPropertyChanged();
            }
            get => this._password;
        }

        private bool _isBusy;

        public bool IsBusy
        {
            set
            {
                this._isBusy = value;
                OnPropertyChanged();
            }
            get => this._isBusy;
        }

        private bool _result;

        public bool Result
        {
            set
            {
                this._result = value;
                OnPropertyChanged();
            }
            get => this._result;
        }

        public Command LoginCommand { get; set; }
        public Command RegisterCommand { get; set; }

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await LoginCommandAsync());
            RegisterCommand = new Command(async () => await RegisterCommandAsync());
        }

        private async Task RegisterCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Password);

                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error",
                        "User Already Exists with this details", "OK");
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LoginCommandAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    Preferences.Set("Username", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error",
                        "Invalid Username or Password", "OK");
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}