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
    public partial class GuestPage : ContentPage
    {
        public GuestPage()
        {
            InitializeComponent();
            ListViewInit();
        }

        void ListViewInit()
        {
            Database db = new Database();
            List<Book> books = db.GetAllBooks();
            avaiBooks.ItemsSource = books;
        }

        private void cartBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CartPage());
        }

        private void avaiBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedBook = (Book)avaiBooks.SelectedItem;
            Navigation.PushAsync(new AddToCartPage(selectedBook));
        }

        private async void logoutBtn_Clicked(object sender, EventArgs e)
        {
            var hoi = await DisplayAlert("Thông Báo", " Bạn muốn đăng xuất?", "Yes", "No");
            if (hoi)
            {
                await Navigation.PushAsync(new MainPage());
            }
            
        }

        private void gohomeBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
    }
}