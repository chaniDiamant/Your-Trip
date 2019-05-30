using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace YourTrip.Models
{
    public class Seat
    {
        [DisplayName("מספר כיסא")]
        public int SeatId { get; set; }

        public Plane Plane { get; set; }

        public Ticket Ticket { get; set; }
    }
}
