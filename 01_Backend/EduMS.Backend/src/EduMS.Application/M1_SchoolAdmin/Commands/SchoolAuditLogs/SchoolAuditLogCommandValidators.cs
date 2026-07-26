using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolAuditLogs;

public class CreateSchoolAuditLogCommandValidator : AbstractValidator<CreateSchoolAuditLogCommand>
{
    public CreateSchoolAuditLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolAuditLogCommandValidator : AbstractValidator<UpdateSchoolAuditLogCommand>
{
    public UpdateSchoolAuditLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolAuditLogCommandValidator : AbstractValidator<DeleteSchoolAuditLogCommand>
{
    public DeleteSchoolAuditLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}