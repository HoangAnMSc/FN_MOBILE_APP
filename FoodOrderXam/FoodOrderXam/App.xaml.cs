using System;
using FoodOrderXam.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FoodOrderXam
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // MainPage = new MainPage();
            // MainPage = new LoginView();
            // MainPage = new NavigationPage(new SettingsPage());
            string username = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(username))
            {
                MainPage = new LoginView();
            }
            else
            {
                MainPage = new ProductsView();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}