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
    public partial class CartPage : ContentPage
    {
        int total = 0;
        public CartPage()
        {
            InitializeComponent();
            CartInit();
            amount.Text = "Total: " + total.ToString();
        }

        void CartInit()
        {
            List<Book> books = new List<Book>();
            Database db = new Database();
            List<Cart> carts = db.GetCart();

            foreach(Cart cart in carts)
            {
                var bookId = cart.bId;
                List<Book> temp = db.GetOneBook(bookId);
                if (temp.Count > 0)
                {
                    books.Add(temp.ElementAt(0));
                    total += temp.ElementAt(0).price;
                }  
                
            };
            lstCart.ItemsSource = books;
        }

        private void thanhtoan_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Thông báo ", "Bạn làm gì có tiền để thanh toán 😞😞😞", "OK, I'm fine.");
        }

        private async void lstCart_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Book selectedBook = (Book)lstCart.SelectedItem;
            //Navigation.PushAsync(new BookDetailPage(selectedBook));
            Database db = new Database();
            var hoi = await DisplayAlert("Thông Báo", " < " + selectedBook.title + " > sẽ bị Xóa khỏi cart??", "Yes", "No");
            if (hoi)
            {
                if (db.DeleteOnebook(selectedBook))
                {
                    await DisplayAlert("Thông Báo", "Xóa Sách Thành Công", "OK");
                    await Navigation.PushAsync(new CartPage());
                }
                else
                {
                    await DisplayAlert("Thông Báo", "Xóa Sách Thất bại", "OK");
                }
                db.AddBook(selectedBook);
            }

        }

        private void gohomeBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
    }
}