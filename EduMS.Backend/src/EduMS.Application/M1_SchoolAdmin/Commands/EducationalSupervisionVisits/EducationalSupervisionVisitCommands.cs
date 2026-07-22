using EduMS.Application.M1_SchoolAdmin.DTOs.EducationalSupervisionVisits;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.EducationalSupervisionVisits;

public class CreateEducationalSupervisionVisitCommand : IRequest<long>
{
    public CreateEducationalSupervisionVisitDto Dto { get; set; } = new();
}

public class UpdateEducationalSupervisionVisitCommand : IRequest<bool>
{
    public UpdateEducationalSupervisionVisitDto Dto { get; set; } = new();
}

public class DeleteEducationalSupervisionVisitCommand : IRequest<bool>
{
    public long Id { get; set; }
}