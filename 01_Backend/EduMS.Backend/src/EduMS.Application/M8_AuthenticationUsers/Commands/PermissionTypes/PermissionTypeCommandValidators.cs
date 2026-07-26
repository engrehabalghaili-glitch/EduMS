using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.PermissionTypes;

public class CreatePermissionTypeCommandValidator : AbstractValidator<CreatePermissionTypeCommand>
{
    public CreatePermissionTypeCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdatePermissionTypeCommandValidator : AbstractValidator<UpdatePermissionTypeCommand>
{
    public UpdatePermissionTypeCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeletePermissionTypeCommandValidator : AbstractValidator<DeletePermissionTypeCommand>
{
    public DeletePermissionTypeCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}