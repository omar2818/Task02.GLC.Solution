using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specifications
{
    internal class EmployeeSpecification : BaseSpecification<Employee>
    {
        public EmployeeSpecification() : base(null)
        {
            AddInclude(E => E.Manager);
            AddInclude(E => E.Department);
            AddInclude(E => E.Salary);
        }

        public EmployeeSpecification(int id)
            :base(E => E.ID == id)
        {
            AddInclude(E => E.Manager);
            AddInclude(E => E.Department);
            AddInclude(E => E.Salary);
        }
    }
}
