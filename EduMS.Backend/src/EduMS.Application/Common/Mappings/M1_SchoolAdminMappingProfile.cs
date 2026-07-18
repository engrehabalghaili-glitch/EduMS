using AutoMapper;
using EduMS.Domain.Entities;
using EduMS.Application.M1_SchoolAdmin.DTOs.Directorates;
using EduMS.Application.M1_SchoolAdmin.DTOs.Departments;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAcademicYears;
using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolSemesters;
using EduMS.Application.M1_SchoolAdmin.DTOs.EducationalStages;

namespace EduMS.Application.Common.Mappings;

public class M1_SchoolAdminMappingProfile : Profile
{
    public M1_SchoolAdminMappingProfile()
    {
        // Directorate
        CreateMap<Directorate, DirectorateDto>().ReverseMap();
        CreateMap<CreateDirectorateDto, Directorate>();
        CreateMap<UpdateDirectorateDto, Directorate>();

        // Department
        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<CreateDepartmentDto, Department>();
        CreateMap<UpdateDepartmentDto, Department>();

        // SchoolAcademicYear
        CreateMap<SchoolAcademicYear, SchoolAcademicYearDto>().ReverseMap();
        CreateMap<CreateSchoolAcademicYearDto, SchoolAcademicYear>();
        CreateMap<UpdateSchoolAcademicYearDto, SchoolAcademicYear>();

        // SchoolSemester
        CreateMap<SchoolSemester, SchoolSemesterDto>().ReverseMap();
        CreateMap<CreateSchoolSemesterDto, SchoolSemester>();
        CreateMap<UpdateSchoolSemesterDto, SchoolSemester>();

        // EducationalStage
        CreateMap<EducationalStage, EducationalStageDto>().ReverseMap();
        CreateMap<CreateEducationalStageDto, EducationalStage>();
        CreateMap<UpdateEducationalStageDto, EducationalStage>();
    }
}
