using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourTrip.Models
{
    public class Destination
    {
        [DisplayName("מספר יעד")]
        public int DestinationId { get; set; }

        [DisplayName("שם")]
        public string Name { get; set; }

        [DisplayName("שפה")]
        public string Language { get; set; }

        [DisplayName("ערך מטבע")]
        public string CurrencyValue { get; set; }

        public ICollection<Flight> Flights { get; set; }
    }
}
