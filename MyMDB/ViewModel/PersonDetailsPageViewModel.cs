﻿using MyMDB.Model;
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
    class PersonDetailsPageViewModel : ViewModelBase
    {
        public Person person;
        public Person Person
        {
            get { return person; }
            set
            {
                Set(ref person, value);
            }
        }

        public ObservableCollection<Movie> Movies { get; set; } = new ObservableCollection<Movie>();
        public ObservableCollection<Show> Shows { get; set; } = new ObservableCollection<Show>();

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            var id = (int)parameter;

            var service = new TraktService();

            Person = await service.GetPersonAsync(id);

            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Navigating to the DetailsPage of the selected movie.
        /// </summary>
        /// <param name="id">ID of the selected movie</param>
        public void NavigateToMovieDetails(int id)
        {
            NavigationService.Navigate(typeof(MovieDetailsPage), id);
        }
    }
}
