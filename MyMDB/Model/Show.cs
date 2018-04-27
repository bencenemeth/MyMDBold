using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    class Show
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public IDs Ids { get; set; }
        public string Tagline { get; set; }
        public string Overview { get; set; }
        public DateTime First_aired { get; set; }
        public Airs Airs { get; set; }
        public int Runtime { get; set; }
        public string Certification { get; set; }
        public string Network { get; set; }
        public string Country { get; set; }
        public DateTime Updated_at { get; set; }
        public object Trailer { get; set; }
        public string Homepage { get; set; }
        public string Status { get; set; }
        public float Rating { get; set; }
        public int Votes { get; set; }
        public int Comment_count { get; set; }
        public string Language { get; set; }
        public string[] Available_translations { get; set; }
        public string[] Genres { get; set; }
        public int Aired_episodes { get; set; }
        public Images Images { get; set; }
    }
}
