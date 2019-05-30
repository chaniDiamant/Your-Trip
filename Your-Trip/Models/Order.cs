using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace YourTrip.Models
{
    public class Order
    {
        [DisplayName("מספר הזמנה")]
        public int OrderId { get; set; }

        [DisplayName("תאריך הזמנה")]
        public DateTime Date { get; set; }

        public Customer Customer { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
