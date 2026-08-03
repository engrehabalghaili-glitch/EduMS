using EduMS.Application.M2_StudentAffairs.DTOs.StudentIdentityDocuments;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentIdentityDocuments;

public class CreateStudentIdentityDocumentCommand : IRequest<long>
{
    public CreateStudentIdentityDocumentDto Dto { get; set; } = new();
}

public class UpdateStudentIdentityDocumentCommand : IRequest<bool>
{
    public UpdateStudentIdentityDocumentDto Dto { get; set; } = new();
}

public class DeleteStudentIdentityDocumentCommand : IRequest<bool>
{
    public long Id { get; set; }
}