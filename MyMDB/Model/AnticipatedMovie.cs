using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    public class AnticipatedMovie
    {
        public string Type { get; set; }
        public float Score { get; set; }
        public int List_count { get; set; }
        public MovieExtended Movie { get; set; }
    }
}
