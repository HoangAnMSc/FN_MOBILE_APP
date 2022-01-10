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
    public partial class MainPage : ContentPage
    {
        User users;
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(User user)
        {
            InitializeComponent();
            users = user;
        }

        private void loginBtn_Clicked(object sender, EventArgs e)
        {
            var user = new User();
            user.Phone = uPhone.Text;
            Database db = new Database();
            List<User> lstusers = db.GetUser();

            if (user.Phone == "0")
            {
                Navigation.PushAsync(new AdminPage());
            }
            else
            {
                if (user.Phone == null)
                {
                    DisplayAlert("Thông Báo", "Bạn chưa nhập số điện thoại ", "OK");
                }
                else
                {
                    Navigation.PushAsync(new HomePage());
                }
            }
        }
    }
}
