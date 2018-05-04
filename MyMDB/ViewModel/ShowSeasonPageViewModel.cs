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
        public Show searchedShow;
        public Show SearchedShow
        {
            get { return searchedShow; }
            set
            {
                Set(ref searchedShow, value);
            }
        }

        public ShowSeason showSeason;
        public ShowSeason ShowSeason
        {
            get { return showSeason; }
            set
            {
                Set(ref showSeason, value);
            }
        }

        public ObservableCollection<ShowEpisode> Episodes { get; set; } = new ObservableCollection<ShowEpisode>();
        public ObservableCollection<ShowSeason> Seasons { get; set; } = new ObservableCollection<ShowSeason>();

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
            KeyValuePair<int, ShowSeason> keyValuePair = (KeyValuePair<int, ShowSeason>)parameter;
            ShowSeason = keyValuePair.Value;

            var service = new TraktService();

            SearchedShow = await service.GetShowAsync(keyValuePair.Key);
            var seasons = await service.GetShowSeasonsAsync(keyValuePair.Key);

            foreach (var item in seasons)
            {
                Seasons.Add(item);
            }

            Cast_Crew = await service.GetCastCrewForShowAsync(keyValuePair.Key);

            await base.OnNavigatedToAsync(parameter, mode, state);
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
