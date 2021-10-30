using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESTS
{
    class Ticket
    {
        int id;
        public Trip trip;
        public PaymentHandler payment;
        public string passenger;

        public Ticket(Trip trip, PaymentHandler payment, string passenger)
        {
            this.id = 0;
            this.trip = trip;
            this.payment = payment;
            this.passenger = passenger;
        }
    }
}
