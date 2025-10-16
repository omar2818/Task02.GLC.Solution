using AutoMapper;
using DomainLayer.Contracts;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper) : IServiceManager
    {
        private readonly Lazy<IEmployeeService> _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(unitOfWork, mapper));
        private readonly Lazy<IDepartmentService> _departmentService = new Lazy<IDepartmentService>(() => new DepartmentService(unitOfWork, mapper));
        private readonly Lazy<ISalaryService> _salaryService = new Lazy<ISalaryService>(() => new SalaryService(unitOfWork, mapper));
        public IEmployeeService EmployeeService => _employeeService.Value;

        public IDepartmentService DepartmentService => _departmentService.Value;

        public ISalaryService SalaryService => _salaryService.Value;
    }
}
