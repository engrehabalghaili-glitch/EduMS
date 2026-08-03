using EduMS.Application.M2_StudentAffairs.DTOs.StudentComplaintLogs;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentComplaintLogs;

public class CreateStudentComplaintLogCommand : IRequest<long>
{
    public CreateStudentComplaintLogDto Dto { get; set; } = new();
}

public class UpdateStudentComplaintLogCommand : IRequest<bool>
{
    public UpdateStudentComplaintLogDto Dto { get; set; } = new();
}

public class DeleteStudentComplaintLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}