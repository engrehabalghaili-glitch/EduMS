using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.PermissionBaseModules;

public class CreatePermissionBaseModuleCommandValidator : AbstractValidator<CreatePermissionBaseModuleCommand>
{
    public CreatePermissionBaseModuleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdatePermissionBaseModuleCommandValidator : AbstractValidator<UpdatePermissionBaseModuleCommand>
{
    public UpdatePermissionBaseModuleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeletePermissionBaseModuleCommandValidator : AbstractValidator<DeletePermissionBaseModuleCommand>
{
    public DeletePermissionBaseModuleCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}