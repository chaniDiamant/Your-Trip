using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourTrip.Models
{
    public class Customer
{
        [Key]
        [DisplayName("מספר דרכון")]
        public int Passport { get; set; }
        [DisplayName("דואר אלקטרוני")]
        public string Mail { get; set; }
        [DisplayName("שם משפחה + שם")]
        public string Name { get; set; }
        [DisplayName("ארץ")]
        public string Country { get; set; }
        [DisplayName("כתובת")]
        public string Address { get; set; }
        [DisplayName("מספר טלפון")]
        public int Phone { get; set; }
        [DisplayName("תאריך לידה")]
        public DateTime DateOfBirth { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
