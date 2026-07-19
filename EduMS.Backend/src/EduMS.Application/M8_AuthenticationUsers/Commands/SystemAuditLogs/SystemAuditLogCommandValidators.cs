using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.SystemAuditLogs;

public class CreateSystemAuditLogCommandValidator : AbstractValidator<CreateSystemAuditLogCommand>
{
    public CreateSystemAuditLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSystemAuditLogCommandValidator : AbstractValidator<UpdateSystemAuditLogCommand>
{
    public UpdateSystemAuditLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSystemAuditLogCommandValidator : AbstractValidator<DeleteSystemAuditLogCommand>
{
    public DeleteSystemAuditLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}