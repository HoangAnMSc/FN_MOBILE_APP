using System.ComponentModel;
using System.Runtime.CompilerServices;
using FoodOrderXam.Annotations;

namespace FoodOrderXam.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}