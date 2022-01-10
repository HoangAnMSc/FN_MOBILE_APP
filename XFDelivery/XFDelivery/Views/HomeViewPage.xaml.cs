using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFDelivery.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFDelivery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeViewPage : ContentPage
    {
        public HomeViewPage()
        {
            InitializeComponent();
            BindingContext = new HomePageViewModels(Navigation);

        }

        private void listGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}