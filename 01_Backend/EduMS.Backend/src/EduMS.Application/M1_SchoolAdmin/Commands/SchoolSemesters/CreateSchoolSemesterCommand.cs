using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolSemesters;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolSemesters;

public class CreateSchoolSemesterCommand : IRequest<long>
{
    public CreateSchoolSemesterDto Dto { get; set; } = new();
}