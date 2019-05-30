using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourTrip.Models
{
    public class Terminal
    {
        [Key]
        [DisplayName("שם טרמינל")]
        public string Name { get; set; }

        public ICollection<Flight> Flights { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
