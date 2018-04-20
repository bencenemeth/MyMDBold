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
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace MyMDB.ViewModel
{
    public class MoviesSearchPageViewModel : ViewModelBase
    {
        public ObservableCollection<MovieExtended> Result { get; set; } = new ObservableCollection<MovieExtended>();

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

        /// <summary>
        /// Clicking on a list item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnListItemClick(object sender, ItemClickEventArgs e)
        {
            MovieExtended selectedMovie = (MovieExtended)e.ClickedItem;
            NavigateToDetails(selectedMovie.Movie.Ids.Trakt);
        }

        /// <summary>
        /// Navigating to the DetailsPage of the selected movie.
        /// </summary>
        /// <param name="id">ID of the selected movie.</param>
        public void NavigateToDetails(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailsPage), id);
        }
    }
}
