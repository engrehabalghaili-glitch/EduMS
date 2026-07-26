using AutoMapper;
using EduMS.Application.M2_StudentAffairs.DTOs.Students;
using EduMS.Domain.Entities;

namespace EduMS.Application.Common.Mappings
{
    public class M2_StudentAffairsMappingProfile : Profile
    {
        public M2_StudentAffairsMappingProfile()
        {
            CreateMap<CreateStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
            CreateMap<Student, StudentDto>();
        }
    }
}
