using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.RolePermissions;

public class CreateRolePermissionCommandValidator : AbstractValidator<CreateRolePermissionCommand>
{
    public CreateRolePermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateRolePermissionCommandValidator : AbstractValidator<UpdateRolePermissionCommand>
{
    public UpdateRolePermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteRolePermissionCommandValidator : AbstractValidator<DeleteRolePermissionCommand>
{
    public DeleteRolePermissionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}