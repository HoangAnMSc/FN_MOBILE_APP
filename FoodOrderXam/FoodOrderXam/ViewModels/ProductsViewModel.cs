using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using FoodOrderXam.Models;
using FoodOrderXam.Services;
using FoodOrderXam.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

// ReSharper disable All

namespace FoodOrderXam.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private string _UserName;

        public string UserName
        {
            get => _UserName;
            set
            {
                _UserName = value;
                OnPropertyChanged();
            }
        }

        private int _UserCartItemsCount;

        public int UserCartItemsCount
        {
            get => _UserCartItemsCount;
            set
            {
                _UserCartItemsCount = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<FoodItem> LatestItems { get; set; }

        public Command ViewCartCommand { get; set; }
        public Command LogooutCommand { get; set; }

        public ProductsViewModel()
        {
            var username = Preferences.Get("Username", String.Empty);
            UserName = String.IsNullOrEmpty(username) ? "Guest" : username;

            UserCartItemsCount = new CartItemService().GetUserCartCount();

            Categories = new ObservableCollection<Category>();
            LatestItems = new ObservableCollection<FoodItem>();

            ViewCartCommand = new Command(async () => await ViewCartAsync());
            LogooutCommand = new Command(async () => await LogoutAsync());

            GetCategories();
            GetLatestItems();
        }

        private async Task LogoutAsync()
        {
            // ReSharper disable once AsyncConverter.AsyncAwaitMayBeElidedHighlighting
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());
        }

        private async Task ViewCartAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new CartView());
        }

        private async void GetLatestItems()
        {
            var data = await new CategoryDataService().GetCategoriesAsync();
            Categories.Clear();
            foreach (var item in data)
            {
                Categories.Add(item);
            }
        }

        private async void GetCategories()
        {
            var data = await new FoodItemService().GetLatestFoodItemsAsync();
            LatestItems.Clear();
            foreach (var item in data)
            {
                LatestItems.Add(item);
            }
        }
    }
}