using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    class Crew
    {
        public ObservableCollection<PersonExtended> Production { get; set; }
        public ObservableCollection<PersonExtended> Art { get; set; }
        public ObservableCollection<PersonExtended> Crew2 { get; set; }
        public ObservableCollection<PersonExtended> Costume_MakeUp { get; set; }
        public ObservableCollection<PersonExtended> Directing { get; set; }
        public ObservableCollection<PersonExtended> Writing { get; set; }
        public ObservableCollection<PersonExtended> Sound { get; set; }
        public ObservableCollection<PersonExtended> Camera { get; set; }
    }
}
