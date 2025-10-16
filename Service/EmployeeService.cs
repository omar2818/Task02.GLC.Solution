using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models;
using Service.Specifications;
using ServiceAbstraction;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService(IUnitOfWork _unitOfWork, IMapper _mapper) : IEmployeeService
    {
        public async Task<int> AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return 0;
            }
            var employee = new Employee()
            {
                Name = employeeDTO.Name,
                DepartmentID = employeeDTO.DepartmentID,
                ManagerID = employeeDTO.ManagerID,
            };
            var empRepo = _unitOfWork.GetRepository<Employee>();
            await empRepo.AddAsync(employee);
            var salary = new Salary()
            {
                EmpID = employee.ID,
                Amount = employeeDTO.Salary
            };
            var salaryRepo = _unitOfWork.GetRepository<Salary>();
            await salaryRepo.AddAsync(salary);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> DeleteEmployeeAsync(int id)
        {
            var empRepo = _unitOfWork.GetRepository<Employee>();
            var employee = await empRepo.GetByIdAsync(id);
            if (employee == null)
            {
                throw new EmployeeNotFoundException(id);
            }
            empRepo.Remove(employee);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var empRepo = _unitOfWork.GetRepository<Employee>();
            var specifications = new EmployeeSpecification();
            var employees = await empRepo.GetAllAsync(specifications);
            return _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> GetEmployeeByIdAsync(int id)
        {
            var empRepo = _unitOfWork.GetRepository<Employee>();
            var specifications = new EmployeeSpecification(id);
            var employee = await empRepo.GetByIdAsync(specifications);
            if (employee == null)
            {
                throw new EmployeeNotFoundException(id);
            }
            return _mapper.Map<Employee, EmployeeDTO>(employee);
        }

        public async Task<int> UpdateEmployeeAsync(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return 0;
            }
            var empRepo = _unitOfWork.GetRepository<Employee>();
            var specifications = new EmployeeSpecification(employeeDTO.EmpId);
            var employee = await empRepo.GetByIdAsync(specifications);
            if(employee == null)
            {
                throw new EmployeeNotFoundException(employeeDTO.EmpId);
            };
            employee.Name = employeeDTO.Name;
            employee.DepartmentID = employeeDTO.DepartmentID;
            employee.ManagerID = employeeDTO.ManagerID;
            empRepo.Update(employee);
            var salaryRepo = _unitOfWork.GetRepository<Salary>();
            var salary = await salaryRepo.GetByIdAsync(employee.Salary.ID);
            salary.Amount = employeeDTO.Salary;
            salaryRepo.Update(salary);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}
