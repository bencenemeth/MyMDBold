using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    /// <summary>
    /// Model for the movie types from the list. Most of the properties will be null,
    /// but this way, we only need 2 models for the movies.
    /// </summary>
    public class MovieExtended
    {
        public string Type { get; set; }
        public float Score { get; set; }
        public int List_count { get; set; }
        public int Revenue { get; set; }
        public int Watchers { get; set; }
        public Movie Movie { get; set; }
    }
}
