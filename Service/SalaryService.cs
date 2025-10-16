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
    internal class SalaryService(IUnitOfWork _unitOfWork, IMapper _mapper) : ISalaryService
    {
        public async Task<IEnumerable<SalaryDto>> GetAllSalariesAsync()
        {
            var salaryRepo = _unitOfWork.GetRepository<Salary>();
            var salaries = await salaryRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<Salary>, IEnumerable<SalaryDto>>(salaries);
        }

    }
}
