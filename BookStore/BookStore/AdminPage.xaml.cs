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
    public partial class AdminPage : ContentPage
    {

        public AdminPage()
        {
            InitializeComponent();
            ListViewInit();
        }

        public AdminPage(string name)
        {
            InitializeComponent();
            ListViewInit();
        }

        void ListViewInit()
        {
            Database db = new Database();
            List<Book> books;

            books = db.GetAllBooks();
            avaiBooks.ItemsSource = books;
        }

        private void addBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddBookPage());
        }

        private void avaiBooks_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book seletedBook = e.SelectedItem as Book;
            Navigation.PushAsync(new BookDetailPage(seletedBook));
        }

        private async void logoutBtn_Clicked(object sender, EventArgs e)
        {
            var hoi = await DisplayAlert("Thông Báo", " Bạn muốn đăng xuất?", "Yes", "No");
            if (hoi)
            {
                await Navigation.PushAsync(new MainPage());
            }
        }
    }
}