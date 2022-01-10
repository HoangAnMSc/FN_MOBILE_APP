using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookStore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void cartBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CartPage());
        }

        private void Rice_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestPage());
        }

        

        private void DoUong_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestPage());
        }

        private void AnVat_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestPage());
        }

        private void DoAnNhanh_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestPage());
        }

        private void Healthy_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestPage());
        }

        private void BunPho_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GuestPage());
        }
    }
}