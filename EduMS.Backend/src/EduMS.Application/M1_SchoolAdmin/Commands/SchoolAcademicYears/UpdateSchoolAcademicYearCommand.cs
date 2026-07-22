using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolAcademicYears;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolAcademicYears;

public class UpdateSchoolAcademicYearCommand : IRequest<bool>
{
    public UpdateSchoolAcademicYearDto Dto { get; set; } = new();
}