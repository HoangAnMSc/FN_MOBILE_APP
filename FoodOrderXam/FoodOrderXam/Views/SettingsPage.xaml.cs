using System;
using FoodOrderXam.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

//ReSharper disable all

namespace FoodOrderXam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private async void ButtonCategories_Clicked(object sender, EventArgs e)
        {
            var addCategoriesData = new AddCategoryData();
            await addCategoriesData.AddCategoriesAsync();
        }

        private async void ButtonProducts_Clicked(object sender, EventArgs e)
        {
            var addPoductsData = new AddFoodItemData();
            await addPoductsData.AddFoodItemAsync();
        }

        private void ButtonCart_Clicked(System.Object sender, System.EventArgs e)
        {
            var cct = new CreateCartTable();
            if (cct.CreateTable())
                DisplayAlert("Success", "Cart Table Created", "Ok");
            else
                DisplayAlert("Error", "Error while creating table", "Ok");
        }
    }
}