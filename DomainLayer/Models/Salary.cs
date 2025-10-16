using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models
{
    public class Salary : BaseEntity
    {
        public decimal Amount { get; set; }
        [ForeignKey(nameof(Employee))]
        public int EmpID { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}
