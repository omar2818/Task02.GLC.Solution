using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstraction;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class DepartmentService(IUnitOfWork _unitOfWork, IMapper _mapper) : IDepartmentService
    {
        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var deptRepo = _unitOfWork.GetRepository<Department>();
            var departments = await deptRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentDto>>(departments);
        }
    }
}
