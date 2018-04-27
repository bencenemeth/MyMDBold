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
    class ShowsPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Property of the search textbox.
        /// </summary>
        public string searchText;
        public string SearchText
        {
            get { return searchText; }
            set
            {
                if (!string.Equals(searchText, value))
                {
                    this.searchText = value;
                    this.RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Show lists shown in the page.
        /// </summary>
        public ObservableCollection<ShowExtended> Trending { get; set; } = new ObservableCollection<ShowExtended>();
        public ObservableCollection<Show> Popular { get; set; } = new ObservableCollection<Show>();
        public ObservableCollection<Show> MostWatched { get; set; } = new ObservableCollection<Show>();
        public ObservableCollection<ShowExtended> Anticipated { get; set; } = new ObservableCollection<ShowExtended>();

        public Cast_Crew cast_Crew;
        public Cast_Crew Cast_Crew
        {
            get { return cast_Crew; }
            set
            {
                Set(ref cast_Crew, value);
            }
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var service = new TraktService();

            /// Sizes for the movie lists.
            List<int> sizes = new List<int>();

            var trending = await service.GetTrendingShowsAsync();
            sizes.Add(trending.Count);

            var popular = await service.GetPopularShowsAsync();
            sizes.Add(popular.Count);

            var most_watched = await service.GetWeeklyMostWatchedShowsAsync();
            sizes.Add(most_watched.Count);

            var anticipated = await service.GetAnticipatedShowsAsync();
            sizes.Add(anticipated.Count);

            /// The shortest list length.
            int count = sizes.Min();

            for (int i = 0; i < count; i++)
            {
                Trending.Add(trending[i]);
                Popular.Add(popular[i]);
                MostWatched.Add(most_watched[i]);
                Anticipated.Add(anticipated[i]);
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
            if (e.ClickedItem is Show)
            {
                Show selectedShow = (Show)e.ClickedItem;
                NavigateToDetails(selectedShow.Ids.Trakt);
            }

            else if (e.ClickedItem is ShowExtended)
            {
                ShowExtended selectedShow = (ShowExtended)e.ClickedItem;
                NavigateToDetails(selectedShow.Show.Ids.Trakt);
            }

        }

        /// <summary>
        /// Navigating to the DetailsPage of the selected movie.
        /// </summary>
        /// <param name="id">ID of the selected movie.</param>
        public void NavigateToDetails(int id)
        {
            NavigationService.Navigate(typeof(ShowDetailsPage), id);
        }

        /// <summary>
        /// Search on pressing enter key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
                Search();
        }

        /// <summary>
        /// Clicking on the search icon.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSearchClick(object sender, RoutedEventArgs e)
        {
            Search();
        }

        /// <summary>
        /// Searching for shows.
        /// </summary>
        public void Search()
        {
            NavigationService.Navigate(typeof(ShowsSearchPage), SearchText);
        }
    }
}
