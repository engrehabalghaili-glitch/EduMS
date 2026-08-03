using EduMS.Application.M1_SchoolAdmin.DTOs.ExamDistributionTimetables;
using MediatR;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ExamDistributionTimetables;

public class CreateExamDistributionTimetableCommand : IRequest<long>
{
    public CreateExamDistributionTimetableDto Dto { get; set; } = new();
}

public class UpdateExamDistributionTimetableCommand : IRequest<bool>
{
    public UpdateExamDistributionTimetableDto Dto { get; set; } = new();
}

public class DeleteExamDistributionTimetableCommand : IRequest<bool>
{
    public long Id { get; set; }
}