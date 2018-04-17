using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{

    public class Movie
    {
        public string title { get; set; }
        public int year { get; set; }
        public IDs ids { get; set; }
    }
}
