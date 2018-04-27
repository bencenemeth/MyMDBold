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
        public Show searchedShow;
        public Show SearchedShow
        {
            get { return searchedShow; }
            set
            {
                Set(ref searchedShow, value);
            }
        }

        public ObservableCollection<ShowSeason> Seasons { get; set; } = new ObservableCollection<ShowSeason>();

        public ObservableCollection<Show> Related { get; set; } = new ObservableCollection<Show>();


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
            var showID = (int)parameter;

            var service = new TraktService();

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

        public void OnRelatedItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem is Show)
            {
                Show selectedShow = (Show)e.ClickedItem;
                NavigateToShowDetails(selectedShow.Ids.Trakt);
            }

            else if (e.ClickedItem is ShowExtended)
            {
                ShowExtended selectedShow = (ShowExtended)e.ClickedItem;
                NavigateToShowDetails(selectedShow.Show.Ids.Trakt);
            }
        }

        public void OnCastCrewMemberClick(object sender, ItemClickEventArgs e)
        {
            PersonExtended selectedPerson = (PersonExtended)e.ClickedItem;
            NavigateToPersonDetails(selectedPerson.Person.IDs.Trakt);
        }

        public void OnSeasonClick(object sender, ItemClickEventArgs e)
        {
            ShowSeason selectedSeason = (ShowSeason)e.ClickedItem;
            //KeyValuePair<int, int> keyValuePair = new KeyValuePair<int, int>(searchedShow.Ids.Trakt, selectedSeason.Number);
            KeyValuePair<int, ShowSeason> keyValuePair = new KeyValuePair<int, ShowSeason>(searchedShow.Ids.Trakt, selectedSeason);
            NavigateToShowSeasonDetails(keyValuePair);
        }

        /// <summary>
        /// Navigating to the DetailsPage of the selected movie.
        /// </summary>
        /// <param name="id">ID of the selected movie.</param>
        public void NavigateToShowDetails(int id)
        {
            NavigationService.Navigate(typeof(ShowDetailsPage), id);
        }

        /// <summary>
        /// Navigating to the DetailsPage of the selected movie.
        /// </summary>
        /// <param name="id">ID of the selected movie.</param>
        public void NavigateToShowSeasonDetails(KeyValuePair<int, ShowSeason> keyValuePair)
        {
            NavigationService.Navigate(typeof(ShowSeasonPage), keyValuePair);
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
