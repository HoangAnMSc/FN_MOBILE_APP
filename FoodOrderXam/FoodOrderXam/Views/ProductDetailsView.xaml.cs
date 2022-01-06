using System;
using FoodOrderXam.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodOrderXam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsView : ContentPage
    {
        public ProductDetailsView(FoodItem foodItem)
        {
            InitializeComponent();
        }

        private void ImageButton_OnClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}