using EduMS.Application.M2_StudentAffairs.DTOs.StudentGuardianRelationships;
using MediatR;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentGuardianRelationships;

public class CreateStudentGuardianRelationshipCommand : IRequest<long>
{
    public CreateStudentGuardianRelationshipDto Dto { get; set; } = new();
}

public class UpdateStudentGuardianRelationshipCommand : IRequest<bool>
{
    public UpdateStudentGuardianRelationshipDto Dto { get; set; } = new();
}

public class DeleteStudentGuardianRelationshipCommand : IRequest<bool>
{
    public long Id { get; set; }
}