using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int DepartmentID { get; set; }
        public Department Department { get; set; } = null!;
        public int? ManagerID { get; set; }
        public Employee? Manager { get; set; }
        public Salary Salary { get; set; } = null!;
    }
}
