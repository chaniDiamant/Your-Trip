using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourTrip.Models
{
    public class Flight
    {
        [Key]
        [DisplayName("מספר טיסה")]

        public int FlightNumber { get; set; }

        [DisplayName("תאריך המראה")]
        public DateTime TakeOff { get; set; }

        [DisplayName("תאריך נחיתה")]
        public DateTime Landing { get; set; }

        [DisplayName("מחיר")]
        public float Price { get; set; }

        public Terminal Terminal { get; set; }

        public Destination Destination { get; set; }

        public Plane Plane { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
