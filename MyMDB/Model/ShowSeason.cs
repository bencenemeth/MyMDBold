using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    public class ShowSeason
    {
        public int Number { get; set; }
        public IDs IDs { get; set; }
        public float Rating { get; set; }
        public int Votes { get; set; }
        public int Episode_count { get; set; }
        public int Aired_episodes { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public DateTime First_aired { get; set; }
        public string Network { get; set; }
    }
}
