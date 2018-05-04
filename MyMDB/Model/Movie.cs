using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    /// <summary>
    /// Model for the movies.
    /// </summary>
    public class Movie
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public IDs IDs { get; set; }
        public string Tagline { get; set; }
        public string Overview { get; set; }
        public string Released { get; set; }
        public int Runtime { get; set; }
        public string Country { get; set; }
        public DateTime Updated_at { get; set; }
        public object Trailer { get; set; }
        public string Homepage { get; set; }
        public float Rating { get; set; }
        public int Votes { get; set; }
        public int Comment_count { get; set; }
        public string Language { get; set; }
        public string[] Available_translations { get; set; }
        public string[] Genres { get; set; }
        public string Certification { get; set; }
        public Images Images { get; set; }
    }
}
