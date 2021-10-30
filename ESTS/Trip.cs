using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTS
{
    class Trip
    {
        public Route route;
        public DateTime dep_time;
        public DateTime dest_time;
        public int seats_total;
        public int seats_booked;
        public Trip(Route route, DateTime dep_time, DateTime dest_time, int seats_total)
        {
            this.route = route;
            this.dep_time = dep_time;
            this.dest_time = dest_time;
            this.seats_total = seats_total;
            this.seats_booked = 0;
        }
        public bool Book()
        {
            if (this.seats_booked < this.seats_total)
            {
                this.seats_booked++;
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetFreeSeats()
        {
            return this.seats_total - this.seats_booked;
        }
        public override string ToString()
        {
            if (String.Compare(dest_time.ToShortDateString(), dep_time.ToShortDateString()) == 0)
            {
                return dep_time.ToShortTimeString() + " — " + 
                    dest_time.ToShortTimeString() + " " + 
                    dep_time.ToShortDateString() + " " + 
                    route;
            }
            else
            {
                return dep_time.ToShortTimeString() + " " + 
                    dep_time.ToShortDateString() + " — " + 
                    dest_time.ToShortTimeString() + " " + 
                    dest_time.ToShortDateString() + " " + 
                    route;
            }
        }
    }
}
