using MyMDB.Model;
using MyMDB.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;

namespace MyMDB.ViewModel
{
    public class MoviesSearchPageViewModel : ViewModelBase
    {
        public ObservableCollection<AnticipatedMovie> Result { get; set; } = new ObservableCollection<AnticipatedMovie>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var query = (string)parameter;
            var service = new TraktService();

            var result = await service.GetSearchMovieAsync(query);
            foreach (var item in result)
            {
                Result.Add(item);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }
    }
}
