using AutoMapper;
using DomainLayer.Models;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(Dist => Dist.EmpId, options => options.MapFrom(src => src.ID))
                .ForMember(Dist => Dist.Department, options => options.MapFrom(src => src.Department.Name))
                .ForMember(Dist => Dist.Manager, options => options.MapFrom(src => src.Manager.Name))
                .ForMember(Dist => Dist.Salary, options => options.MapFrom(src => src.Salary.Amount))
                .ForMember(Dist => Dist.SalaryID, options => options.MapFrom(src => src.Salary.ID))
                .ReverseMap();
            CreateMap<Department, DepartmentDto>();
            CreateMap<Salary, SalaryDto>();
        }
    }
}
