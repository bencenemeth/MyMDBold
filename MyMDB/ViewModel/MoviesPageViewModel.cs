using MyMDB.Model;
using MyMDB.Service;
using MyMDB.View;
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
    public class MoviesPageViewModel : ViewModelBase
    {
        public ObservableCollection<TrendingMovie> Trending { get; set; } = new ObservableCollection<TrendingMovie>();
        public ObservableCollection<MovieExtended> Popular { get; set; } = new ObservableCollection<MovieExtended>();
        public ObservableCollection<AnticipatedMovie> Anticipated { get; set; } = new ObservableCollection<AnticipatedMovie>();
        public ObservableCollection<BoxOfficeMovie> BoxOffice { get; set; } = new ObservableCollection<BoxOfficeMovie>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new TraktService();

            List<int> sizes = new List<int> { 10 };

            var trending = await service.GetTrendingMoviesAsync();
            sizes.Add(trending.Count);

            var popular = await service.GetPopularMoviesAsync();
            sizes.Add(popular.Count);

            var anticipated = await service.GetAnticipatedMoviesAsync();
            sizes.Add(anticipated.Count);

            var boxoffice = await service.GetBoxOfficeMoviesAsync();
            sizes.Add(boxoffice.Count);

            int count = sizes.Min();

            for (int i = 0; i < count; i++)
            {
                Trending.Add(trending[i]);
                Popular.Add(popular[i]);
                Anticipated.Add(anticipated[i]);
                BoxOffice.Add(boxoffice[i]);
            }

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void NavigateToDetails(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailsPage), id);
        }
    }
}
