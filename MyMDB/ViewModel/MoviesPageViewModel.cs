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
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace MyMDB.ViewModel
{
    public class MoviesPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Property of the search textbox
        /// </summary>
        public string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if(!string.Equals(searchText, value))
                {
                    this.searchText = value;
                    // Notify UI elements that the data has changed.
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Movie lists shown in the page
        /// </summary>
        public ObservableCollection<MovieExtended> Trending { get; set; } = new ObservableCollection<MovieExtended>();
        public ObservableCollection<Movie> Popular { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<MovieExtended> Anticipated { get; set; } = new ObservableCollection<MovieExtended>();
        public ObservableCollection<MovieExtended> BoxOffice { get; set; } = new ObservableCollection<MovieExtended>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new TraktService();

            // Sizes for the movie lists
            List<int> sizes = new List<int>();

            // API calls
            var trending = await service.GetTrendingMoviesAsync();
            sizes.Add(trending.Count);

            var popular = await service.GetPopularMoviesAsync();
            sizes.Add(popular.Count);

            var anticipated = await service.GetAnticipatedMoviesAsync();
            sizes.Add(anticipated.Count);

            var boxoffice = await service.GetBoxOfficeMoviesAsync();
            sizes.Add(boxoffice.Count);

            // The shortest list length
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

        /// <summary>
        /// Clicking on a list item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnListItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Movie)
            {
                Movie selectedMovie = (Movie)e.ClickedItem;
                NavigateToDetails(selectedMovie.IDs.Trakt);
            }
                
            else if(e.ClickedItem is MovieExtended)
            {
                MovieExtended selectedMovie = (MovieExtended)e.ClickedItem;
                NavigateToDetails(selectedMovie.Movie.IDs.Trakt);
            }
            
        }

        /// <summary>
        /// Navigating to the DetailsPage of the selected movie
        /// </summary>
        /// <param name="id">ID of the selected movie</param>
        public void NavigateToDetails(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailsPage), id);
        }

        /// <summary>
        /// Search on pressing enter key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                Search();
        }

        /// <summary>
        /// Clicking on the search icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSearchClick(object sender, RoutedEventArgs e)
        {
            Search();
        }

        /// <summary>
        /// Searching for movies
        /// </summary>
        public void Search()
        {
            NavigationService.Navigate(typeof(MoviesSearchPage), SearchText);
        }
    }
}
