using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolAcademicYears;

public class DeleteSchoolAcademicYearCommand : IRequest<bool>
{
    public long Id { get; set; }
}