using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.SystemUsers;

public class CreateSystemUserCommandValidator : AbstractValidator<CreateSystemUserCommand>
{
    public CreateSystemUserCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSystemUserCommandValidator : AbstractValidator<UpdateSystemUserCommand>
{
    public UpdateSystemUserCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSystemUserCommandValidator : AbstractValidator<DeleteSystemUserCommand>
{
    public DeleteSystemUserCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}