using EduMS.Application.M1_SchoolAdmin.DTOs.SchoolSemesters;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolSemesters;

public class UpdateSchoolSemesterCommand : IRequest<bool>
{
    public UpdateSchoolSemesterDto Dto { get; set; } = new();
}