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
    public partial class BookDetailPage : ContentPage
    {
        Book book;
        public BookDetailPage(Book book)
        {
            InitializeComponent();
            bookImg.Source = book.img;
            bookTitle.Text = book.title;
            bookPrice.Text = book.price.ToString();
            this.book = book;
        }

        private async void delBtn_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            var hoi = await DisplayAlert("Thông Báo", " < " + book.title + " > sẽ bị Xóa??", "Yes", "No");
            if (hoi)
            {
                if (db.DeleteOnebook(book))
                {
                    await DisplayAlert("Thông Báo", "Xóa Sách Thành Công", "OK");
                    await Navigation.PushAsync(new AdminPage());
                }
                else
                {
                    await DisplayAlert("Thông Báo", "Xóa Sách Thất bại", "OK");
                }
            }
        }

        private void editBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UpdateBookPage(book));

        }
    }
}