using EduMS.Application.M2_StudentAffairs.DTOs.StudentAttachments;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentAttachments;

public class CreateStudentAttachmentCommand : IRequest<long>
{
    public CreateStudentAttachmentDto Dto { get; set; } = new();
}

public class UpdateStudentAttachmentCommand : IRequest<bool>
{
    public UpdateStudentAttachmentDto Dto { get; set; } = new();
}

public class DeleteStudentAttachmentCommand : IRequest<bool>
{
    public long Id { get; set; }
}