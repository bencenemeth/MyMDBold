using MyMDB.Service;
using MyMDB.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace MyMDB.ViewModel
{
    class MainPageViewModel : ViewModelBase
    {
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void MovieClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(MoviesPage));
        }
    }
}
