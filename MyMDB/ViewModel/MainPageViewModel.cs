﻿using MyMDB.Service;
using MyMDB.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace MyMDB.ViewModel
{
    class MainPageViewModel : ViewModelBase
    {
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            await base.OnNavigatedToAsync(parameter, mode, state);
        }

        /// <summary>
        /// Click on the movies image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void MovieClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(MoviesPage));
        }

        /// <summary>
        /// Click on the series image.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SeriesClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(typeof(ShowsPage));
        }
    }
}
