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
    class MovieDetailsPageViewModel : ViewModelBase
    {
        public Movie searchedMovie;
        public Movie SearchedMovie
        {
            get { return searchedMovie; }
            set
            {
                Set(ref searchedMovie, value);
            }
        }

        public ObservableCollection<Movie> Related { get; set; } = new ObservableCollection<Movie>();

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
            var movieID = (int)parameter;

            var service = new TraktService();

            SearchedMovie = await service.GetMovieAsync(movieID);
            var related = await service.GetRelatedMovieAsync(movieID);

            foreach (var item in related)
            {
                Related.Add(item);
            }

            Cast_Crew = await service.GetCastCrewForMovieAsync(movieID);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        public void OnRelatedItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Movie)
            {
                Movie selectedMovie = (Movie)e.ClickedItem;
                NavigateToMovieDetails(selectedMovie.Ids.Trakt);
            }

            else if (e.ClickedItem is MovieExtended)
            {
                MovieExtended selectedMovie = (MovieExtended)e.ClickedItem;
                NavigateToMovieDetails(selectedMovie.Movie.Ids.Trakt);
            }
        }

        public void OnCastCrewMemberClick(object sender, ItemClickEventArgs e)
        {
            PersonExtended selectedPerson = (PersonExtended)e.ClickedItem;
            NavigateToPersonDetails(selectedPerson.Person.IDs.Trakt);
        }

        /// <summary>
        /// Navigating to the DetailsPage of the selected movie.
        /// </summary>
        /// <param name="id">ID of the selected movie</param>
        public void NavigateToMovieDetails(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailsPage), id);
        }

        /// <summary>
        /// Navigating to the DetailsPage of the selected person.
        /// </summary>
        /// <param name="id">ID of the selected person</param>
        public void NavigateToPersonDetails(int id)
        {
            NavigationService.Navigate(typeof(PersonDetailsPage), id);
        }
    }
}
