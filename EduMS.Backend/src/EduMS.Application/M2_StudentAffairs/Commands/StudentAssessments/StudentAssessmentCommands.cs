using EduMS.Application.M2_StudentAffairs.DTOs.StudentAssessments;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentAssessments;

public class CreateStudentAssessmentCommand : IRequest<long>
{
    public CreateStudentAssessmentDto Dto { get; set; } = new();
}

public class UpdateStudentAssessmentCommand : IRequest<bool>
{
    public UpdateStudentAssessmentDto Dto { get; set; } = new();
}

public class DeleteStudentAssessmentCommand : IRequest<bool>
{
    public long Id { get; set; }
}