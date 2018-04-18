using MyMDB.Model;
using MyMDB.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace MyMDB.ViewModel
{
    class MovieDetailsPageViewModel : ViewModelBase
    {
        public MovieExtended Movie { get; set; }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var movieID = (int)parameter;
            var service = new TraktService();
            Movie = await service.GetMovieExtendedAsync(movieID);
            await base.OnNavigatedToAsync(parameter, mode, state);
        }
    }
}
