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
    public partial class UpdateBookPage : ContentPage
    {
        Book books;  
        public UpdateBookPage(Book book)
        {
            InitializeComponent();
            books = book;
        }

        private async void updateBookBtn_Clicked(object sender, EventArgs e)
        {
            Book updateBook = books;
            updateBook.title = bookTitle.Text;
            updateBook.price = Int32.Parse(bookPrice.Text);
            updateBook.img = bookImg.Text;

            Database db = new Database();   
            var hoi = await DisplayAlert("Thông báo","Thông tin sửa đổi sẽ không thể khôi phục ?", "Yes", "No");
            if(hoi)
            {
                if (db.UpdateOnebook(updateBook))
                {
                    await DisplayAlert("Thông Báo", "Cập nhật đồ ăn thành công", "OK");
                    await Navigation.PushAsync(new AdminPage());
                }
                else
                {
                    await DisplayAlert("Thông Báo", "Cập nhật đồ ăn thất bại", "OK");
                }
            }
        }
    }
}