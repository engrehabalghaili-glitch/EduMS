using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.StudentPermissionAuditLogs;

public class CreateStudentPermissionAuditLogCommandValidator : AbstractValidator<CreateStudentPermissionAuditLogCommand>
{
    public CreateStudentPermissionAuditLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentPermissionAuditLogCommandValidator : AbstractValidator<UpdateStudentPermissionAuditLogCommand>
{
    public UpdateStudentPermissionAuditLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentPermissionAuditLogCommandValidator : AbstractValidator<DeleteStudentPermissionAuditLogCommand>
{
    public DeleteStudentPermissionAuditLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}