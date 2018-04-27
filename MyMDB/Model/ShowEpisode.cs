using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    public class ShowEpisode
    {
        public int Season { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public IDs IDs { get; set; }
        public object Number_abs { get; set; }
        public string Overview { get; set; }
        public DateTime First_aired { get; set; }
        public DateTime Updated_at { get; set; }
        public int Rating { get; set; }
        public int Votes { get; set; }
        public int Comment_count { get; set; }
        public string[] Available_translations { get; set; }
        public int Runtime { get; set; }
    }
}
