using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.SystemRoles;

public class CreateSystemRoleCommandValidator : AbstractValidator<CreateSystemRoleCommand>
{
    public CreateSystemRoleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSystemRoleCommandValidator : AbstractValidator<UpdateSystemRoleCommand>
{
    public UpdateSystemRoleCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSystemRoleCommandValidator : AbstractValidator<DeleteSystemRoleCommand>
{
    public DeleteSystemRoleCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}