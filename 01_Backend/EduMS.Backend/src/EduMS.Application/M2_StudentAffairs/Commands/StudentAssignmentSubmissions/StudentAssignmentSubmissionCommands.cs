using EduMS.Application.M2_StudentAffairs.DTOs.StudentAssignmentSubmissions;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentAssignmentSubmissions;

public class CreateStudentAssignmentSubmissionCommand : IRequest<long>
{
    public CreateStudentAssignmentSubmissionDto Dto { get; set; } = new();
}

public class UpdateStudentAssignmentSubmissionCommand : IRequest<bool>
{
    public UpdateStudentAssignmentSubmissionDto Dto { get; set; } = new();
}

public class DeleteStudentAssignmentSubmissionCommand : IRequest<bool>
{
    public long Id { get; set; }
}