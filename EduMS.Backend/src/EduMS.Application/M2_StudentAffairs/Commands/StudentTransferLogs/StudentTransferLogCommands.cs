using EduMS.Application.M2_StudentAffairs.DTOs.StudentTransferLogs;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentTransferLogs;

public class CreateStudentTransferLogCommand : IRequest<long>
{
    public CreateStudentTransferLogDto Dto { get; set; } = new();
}

public class UpdateStudentTransferLogCommand : IRequest<bool>
{
    public UpdateStudentTransferLogDto Dto { get; set; } = new();
}

public class DeleteStudentTransferLogCommand : IRequest<bool>
{
    public long Id { get; set; }
}