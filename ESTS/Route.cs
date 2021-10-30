using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTS
{
    class Route
    {
        public Place dep_point;
        public Place dest_point;
        public Route(Place departure, Place destination)
        {
            this.dep_point = departure;
            this.dest_point = destination;
        }
        public override string ToString()
        {
            return dep_point + " — " + dest_point;
        }
    }
}
