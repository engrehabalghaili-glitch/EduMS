using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAcademicYears;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolAcademicYears;

public class CreateSchoolAcademicYearCommand : IRequest<long>
{
    public CreateSchoolAcademicYearDto Dto { get; set; } = new();
}