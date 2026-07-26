using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.UserDirectPermissions;

public class CreateUserDirectPermissionCommandValidator : AbstractValidator<CreateUserDirectPermissionCommand>
{
    public CreateUserDirectPermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateUserDirectPermissionCommandValidator : AbstractValidator<UpdateUserDirectPermissionCommand>
{
    public UpdateUserDirectPermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteUserDirectPermissionCommandValidator : AbstractValidator<DeleteUserDirectPermissionCommand>
{
    public DeleteUserDirectPermissionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}