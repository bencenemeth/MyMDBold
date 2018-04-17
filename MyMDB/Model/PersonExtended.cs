using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    public class PersonExtended
    {
        public Person person { get; set; }
        //public string name { get; set; }
        //public IDs ids { get; set; }
        public string biography { get; set; }
        public string birthday { get; set; }
        public object death { get; set; }
        public string birthplace { get; set; }
        public string homepage { get; set; }
    }
}
