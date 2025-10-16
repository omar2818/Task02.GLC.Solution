using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class EmployeeDTO
    {
        public int EmpId { get; set; }
        public string Name { get; set; } = null!;
        public string? Manager { get; set; }
        public int? ManagerID { get; set; }
        public string? Department { get; set; }
        public int DepartmentID { get; set; }
        public decimal Salary { get; set; }
        public int? SalaryID { get; set; }
    }
}
