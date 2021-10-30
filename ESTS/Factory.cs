using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTS
{
    class Factory
    {
        static Lazy<Factory> myFactory = new Lazy<Factory>(() => new Factory());

        public static Factory MyFactory
        {
            get
            {
                return myFactory.Value;
            }
        }
        public Place AddPlace(string name, string type, string description)
        {
            Place p = new Place(name, type, description);
            return p;
        }
        public Route AddRoute(Place dep, Place dest)
        {
            Route r = new Route(dep, dest);
            return r;
        }
        public Trip AddTrip(Route route, DateTime dep_time, DateTime dest_time, int seats_total)
        {
            Trip t = new Trip(route, dep_time, dest_time, seats_total);
            return t;
        }
    }
}
