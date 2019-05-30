using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourTrip.Models
{
    public class Department
{
    [Key]
    [DisplayName("שם המחלקה")]
    public string Name { get; set; }
    [DisplayName("תוספת למחיר")]
    public float ExtraPrice { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
    public ICollection<PlaneDepartment> PlaneDepartments { get; set; }
}
}
