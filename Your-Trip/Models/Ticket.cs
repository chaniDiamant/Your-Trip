using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourTrip.Models
{
    public class Ticket
    {
        [Key]
        [DisplayName("מספר כרטיס")]
        public int TicketNumber { get; set; }

        [DisplayName("תאריך המראה")]
        public DateTime LandingDate { get; set; }

        [DisplayName("תאריך נחיתה")]
        public DateTime TakeOffTime { get; set; }

        public Terminal Terminal { get; set; }

        public Flight Flight { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Seat> Seats { get; set; }

        public Department Department { get; set; }

        public Order Order { get; set; }
    }
}
