using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Санта.Corp
{
    class Region
    {
        public string Title { get; set; }
        public string UTC { get; set; }
        public Deer Deer { get; set; }

        internal static void Add(Region region)
        {
            throw new NotImplementedException();
        }
    }
}
