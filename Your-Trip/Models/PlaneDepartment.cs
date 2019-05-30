using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YourTrip.Models
{
    public class PlaneDepartment
{   
    public int PlaneId { get; set; }
    public Plane Plane { get; set; }
    public String DepartmentName { get; set; }
    public Department Department { get; set; }
}
}
