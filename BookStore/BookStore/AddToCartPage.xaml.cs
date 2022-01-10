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
    public partial class AddToCartPage : ContentPage
    {
        Book book;
        public AddToCartPage(Book book)
        {
            InitializeComponent();
            Title = book.title;
            bookImg.Source = book.img;
            bookTitle.Text = book.title;
            bookPrice.Text = book.price.ToString();
            this.book = book;
        }

        private void addToCartBtn_Clicked(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.bId = book.bID;
            cart.totalAmount = book.price;

            Database db = new Database();
            if (db.AddCart(cart))
            {
                DisplayAlert("Thông Báo", "Thêm Vào Giỏ Thành Công", "OK");
                Navigation.PushAsync(new GuestPage());
            }
            else
            {
                DisplayAlert("Thông Báo", "Thêm Vào Giỏ Thất Bại", "OK");
            }
        }
    }
}