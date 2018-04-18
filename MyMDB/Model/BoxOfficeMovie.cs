using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    public class BoxOfficeMovie
    {
        public int Revenue { get; set; }
        public MovieExtended Movie { get; set; }
    }
}
