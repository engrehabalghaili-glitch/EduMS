using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.OfficePermissions;

public class CreateOfficePermissionCommandValidator : AbstractValidator<CreateOfficePermissionCommand>
{
    public CreateOfficePermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateOfficePermissionCommandValidator : AbstractValidator<UpdateOfficePermissionCommand>
{
    public UpdateOfficePermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteOfficePermissionCommandValidator : AbstractValidator<DeleteOfficePermissionCommand>
{
    public DeleteOfficePermissionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}