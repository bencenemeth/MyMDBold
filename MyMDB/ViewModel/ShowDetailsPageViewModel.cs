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
    class ShowDetailsPageViewModel : ViewModelBase
    {
        /// <summary>
        /// The show
        /// </summary>
        public Show searchedShow;
        public Show SearchedShow
        {
            get { return searchedShow; }
            set
            {
                Set(ref searchedShow, value);
            }
        }

        /// <summary>
        /// List of the show's seasons
        /// </summary>
        public ObservableCollection<ShowSeason> Seasons { get; set; } = new ObservableCollection<ShowSeason>();

        /// <summary>
        /// List of related shows
        /// </summary>
        public ObservableCollection<Show> Related { get; set; } = new ObservableCollection<Show>();

        /// <summary>
        /// Cast and crew members
        /// </summary>
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
            // Getting the ID of the show from the parameter object
            var showID = (int)parameter;

            var service = new TraktService();

            // API calls
            SearchedShow = await service.GetShowAsync(showID);
            var seasons = await service.GetShowSeasonsAsync(showID);
            var related = await service.GetRelatedShowsAsync(showID);

            foreach (var item in seasons)
            {
                Seasons.Add(item);
            }

            foreach (var item in related)
            {
                Related.Add(item);
            }

            Cast_Crew = await service.GetCastCrewForShowAsync(showID);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Clicking on a related show
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnRelatedItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Show)
            {
                Show selectedShow = (Show)e.ClickedItem;
                NavigateToShowDetails(selectedShow.IDs.Trakt);
            }

            else if (e.ClickedItem is ShowExtended)
            {
                ShowExtended selectedShow = (ShowExtended)e.ClickedItem;
                NavigateToShowDetails(selectedShow.Show.IDs.Trakt);
            }
        }

        /// <summary>
        /// Clicking on a season
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSeasonClick(object sender, ItemClickEventArgs e)
        {
            // Getting the ShowSeason object
            ShowSeason selectedSeason = (ShowSeason)e.ClickedItem;
            // Put it in a KeyValuePair with the ID of the show
            KeyValuePair<int, ShowSeason> keyValuePair = new KeyValuePair<int, ShowSeason>(searchedShow.IDs.Trakt, selectedSeason);
            NavigateToShowSeasonDetails(keyValuePair);
        }

        /// <summary>
        /// Clicking on a cast or crew member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnCastCrewMemberClick(object sender, ItemClickEventArgs e)
        {
            PersonExtended selectedPerson = (PersonExtended)e.ClickedItem;
            NavigateToPersonDetails(selectedPerson.Person.IDs.Trakt);
        }


        /// <summary>
        /// Navigating to the DetailsPage of the selected movie
        /// </summary>
        /// <param name="id">ID of the selected movie</param>
        public void NavigateToShowDetails(int id)
        {
            NavigationService.Navigate(typeof(ShowDetailsPage), id);
        }

        /// <summary>
        /// Navigating to the DetailsPage of the selected movie
        /// </summary>
        /// <param name="id">ID of the selected movie</param>
        public void NavigateToShowSeasonDetails(KeyValuePair<int, ShowSeason> keyValuePair)
        {
            NavigationService.Navigate(typeof(ShowSeasonPage), keyValuePair);
        }

        /// <summary>
        /// Navigating to the DetailsPage of the selected person
        /// </summary>
        /// <param name="id">ID of the selected person</param>
        public void NavigateToPersonDetails(int id)
        {
            NavigationService.Navigate(typeof(PersonDetailsPage), id);
        }
    }
}
