using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    class ShowExtended
    {
        public int Watchers { get; set; }
        public int List_count { get; set; }
        public int Watcher_count { get; set; }
        public int Play_count { get; set; }
        public int Collected_count { get; set; }
        public int Collector_count { get; set; }
        public float Score { get; set; }
        public Show Show { get; set; }
    }
}
