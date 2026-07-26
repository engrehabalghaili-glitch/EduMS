using AutoMapper;
using EduMS.Application.M3_EmployeeManagement.DTOs.Employees;
using EduMS.Domain.Entities;

namespace EduMS.Application.Common.Mappings
{
    public class M3_EmployeeManagementMappingProfile : Profile
    {
        public M3_EmployeeManagementMappingProfile()
        {
            CreateMap<CreateEmployeeDto, Employee>();
            CreateMap<UpdateEmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
        }
    }
}
