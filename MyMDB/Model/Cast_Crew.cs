using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    class Cast_Crew
    {
        public ObservableCollection<PersonExtended> Cast { get; set; }
        public Crew Crew { get; set; }
    }
}
