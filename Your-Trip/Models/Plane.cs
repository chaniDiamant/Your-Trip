using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace YourTrip.Models
{
    public class Plane
    {
        [DisplayName("מספר מטוס")]
        public int PlaneId { get; set; }

        [DisplayName("מספר מושבים")]
        public int NumberOfSeats { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public ICollection<Seat> Seatses { get; set; }

        public ICollection<PlaneDepartment> PlaneDepartments { get; set; }
    }
}
