using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    public class Person
    {
        public string Name { get; set; }
        public IDs IDs { get; set; }
        public string Biography { get; set; }
        public string Birthday { get; set; }
        public object Death { get; set; }
        public string Birthplace { get; set; }
        public string Homepage { get; set; }
    }
}
