using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFDelivery.ViewModels;

namespace XFDelivery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeViews : ContentPage
    {
        public HomeViews()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModels(Navigation);
        }
    }
}