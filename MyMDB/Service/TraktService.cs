﻿using MyMDB.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Service
{
    class TraktService
    {
        private async Task<T> GetAsync<T>(Uri uri)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("trakt-api-version", "2");
                client.DefaultRequestHeaders.Add("trakt-api-key", clientKey);
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var response = await client.GetAsync(uri);
                var json = await response.Content.ReadAsStringAsync();
                T result = JsonConvert.DeserializeObject<T>(json, settings);
                return result;
            }
        }

        /// <summary>
        /// Server URL
        /// </summary>
        private readonly Uri serverUrl = new Uri("https://api.trakt.tv");

        /// <summary>
        /// Key for network calls
        /// </summary>
        private readonly string clientKey = "1c59074b39a0bbc9d7a626ed048bfa0134df28af13d613206e176f807fdc13ee";

        /// <summary>
        /// Returns a single movie's  details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Movie> GetMovieAsync(int id)
        {
            return await GetAsync<Movie>(new Uri(serverUrl, $"movies/{id}?extended=full"));
        }

        /// <summary>
        /// Returns all movies being watched right now. Movies with the most users are returned first.
        /// </summary>
        /// <returns></returns>
        public async Task<List<MovieExtended>> GetTrendingMoviesAsync()
        {
            return await GetAsync<List<MovieExtended>>(new Uri(serverUrl, "movies/trending"));
        }

        /// <summary>
        /// Returns the most popular movies. Popularity is calculated using the rating percentage and the number of ratings.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Movie>> GetPopularMoviesAsync()
        {
            return await GetAsync<List<Movie>>(new Uri(serverUrl, "movies/popular"));
        }

        /// <summary>
        /// Returns the most anticipated movies based on the number of lists a movie appears on.
        /// </summary>
        /// <returns></returns>
        public async Task<List<MovieExtended>> GetAnticipatedMoviesAsync()
        {
            return await GetAsync<List<MovieExtended>>(new Uri(serverUrl, "movies/anticipated"));
        }

        /// <summary>
        /// Returns the top 10 grossing movies in the U.S. box office last weekend. Updated every Monday morning.
        /// </summary>
        /// <returns></returns>
        public async Task<List<MovieExtended>> GetBoxOfficeMoviesAsync()
        {
            return await GetAsync<List<MovieExtended>>(new Uri(serverUrl, "movies/boxoffice"));
        }

        /// <summary>
        /// Returns a single person's details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Person> GetPersonAsync(int id)
        {
            return await GetAsync<Person>(new Uri(serverUrl, $"people/{id}"));
        }

        /// <summary>
        /// Returns a single person's extended details.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Person> GetPersonExtendedAsync(int id)
        {
            return await GetAsync<Person>(new Uri(serverUrl, $"people/{id}?extended=full"));
        }

        /// <summary>
        /// Returns the result of the movie search. (only for movies)
        /// </summary>
        /// <param name="query">Searched text.</param>
        /// <returns></returns>
        public async Task<List<MovieExtended>> GetSearchMovieAsync(string query)
        {
            return await GetAsync<List<MovieExtended>>(new Uri(serverUrl, $"search/?type=movie&query={query}"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<Movie>> GetRelatedMovieAsync(int id)
        {
            return await GetAsync<List<Movie>>(new Uri(serverUrl, $"movies/{id}/related"));
        }
    }
}
