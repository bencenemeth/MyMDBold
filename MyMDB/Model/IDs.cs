using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    /// <summary>
    /// Model for IDs of movies, series and people.
    /// </summary>
    public class IDs
    {
        public int Trakt { get; set; }
        public string Slug { get; set; }
        public string Imdb { get; set; }
        public int Tmdb { get; set; }
    }
}
