using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.SystemPermissions;

public class CreateSystemPermissionCommandValidator : AbstractValidator<CreateSystemPermissionCommand>
{
    public CreateSystemPermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSystemPermissionCommandValidator : AbstractValidator<UpdateSystemPermissionCommand>
{
    public UpdateSystemPermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSystemPermissionCommandValidator : AbstractValidator<DeleteSystemPermissionCommand>
{
    public DeleteSystemPermissionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}