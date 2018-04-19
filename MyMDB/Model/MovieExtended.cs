using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{

    public class MovieExtended
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public IDs Ids { get; set; }
        public string tagline { get; set; }
        public string overview { get; set; }
        public string released { get; set; }
        public int runtime { get; set; }
        public string country { get; set; }
        public DateTime updated_at { get; set; }
        public object trailer { get; set; }
        public string homepage { get; set; }
        public int rating { get; set; }
        public int votes { get; set; }
        public int comment_count { get; set; }
        public string language { get; set; }
        public string[] available_translations { get; set; }
        public string[] genres { get; set; }
        public string certification { get; set; }
        public Images Images { get; set; }
    }
}
