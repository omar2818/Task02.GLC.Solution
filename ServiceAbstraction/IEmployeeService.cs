using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync();
        Task<EmployeeDTO> GetEmployeeByIdAsync(int id);
        Task<int> AddEmployeeAsync(EmployeeDTO employeeDTO);
        Task<int> UpdateEmployeeAsync(EmployeeDTO employeeDTO);
        Task<int> DeleteEmployeeAsync(int id);
    }
}
