using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IServiceManager
    {
        public IEmployeeService EmployeeService { get; }
        public IDepartmentService DepartmentService { get; }
        public ISalaryService SalaryService { get; }
        public IAuthService AuthService { get; }
    }
}
