using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Санта.Corp
{
    class Data
    {
        public static ObservableCollection<Special> Specials = new ObservableCollection<Special>();
        public static ObservableCollection<Worker> Workers = new ObservableCollection<Worker>();
        public static ObservableCollection<Region> Regions = new ObservableCollection<Region>();
        public static ObservableCollection<Deer> Deers = new ObservableCollection<Deer>();

    }
}
