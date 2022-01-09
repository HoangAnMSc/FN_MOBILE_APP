using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFDelivery.ViewModels;

namespace XFDelivery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGuest_Clicked(object sender, System.EventArgs e)
        {

        }

        private void btnAdmin_Clicked(object sender, System.EventArgs e)
        {

        }

        private void loginBtn_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HomeViews());
        }
    }
}