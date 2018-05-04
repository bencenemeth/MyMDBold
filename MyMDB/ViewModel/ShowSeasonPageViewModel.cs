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
    class ShowSeasonPageViewModel : ViewModelBase
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
        /// The season of the show
        /// </summary>
        public ShowSeason showSeason;
        public ShowSeason ShowSeason
        {
            get { return showSeason; }
            set
            {
                Set(ref showSeason, value);
            }
        }

        /// <summary>
        /// List of the show's episodes
        /// </summary>
        public ObservableCollection<ShowEpisode> Episodes { get; set; } = new ObservableCollection<ShowEpisode>();

        /// <summary>
        /// List of the show's seasons
        /// </summary>
        public ObservableCollection<ShowSeason> Seasons { get; set; } = new ObservableCollection<ShowSeason>();

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
            // Getting the ID of the show and the season from the parameter object
            KeyValuePair<int, ShowSeason> keyValuePair = (KeyValuePair<int, ShowSeason>)parameter;
            ShowSeason = keyValuePair.Value;

            var service = new TraktService();

            // API calls
            SearchedShow = await service.GetShowAsync(keyValuePair.Key);
            var seasons = await service.GetShowSeasonsAsync(keyValuePair.Key);

            foreach (var item in seasons)
            {
                Seasons.Add(item);
            }

            Cast_Crew = await service.GetCastCrewForShowAsync(keyValuePair.Key);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Clicking on a season
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnSeasonClick(object sender, ItemClickEventArgs e)
        {
            ShowSeason selectedSeason = (ShowSeason)e.ClickedItem;
            //KeyValuePair<int, int> keyValuePair = new KeyValuePair<int, int>(searchedShow.Ids.Trakt, selectedSeason.Number);
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
