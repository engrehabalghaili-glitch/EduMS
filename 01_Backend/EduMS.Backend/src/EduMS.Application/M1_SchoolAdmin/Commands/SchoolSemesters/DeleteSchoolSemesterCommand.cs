using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolSemesters;

public class DeleteSchoolSemesterCommand : IRequest<bool>
{
    public long Id { get; set; }
}