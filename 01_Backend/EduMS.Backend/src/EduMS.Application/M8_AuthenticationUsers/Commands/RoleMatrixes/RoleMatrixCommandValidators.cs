using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.RoleMatrixes;

public class CreateRoleMatrixCommandValidator : AbstractValidator<CreateRoleMatrixCommand>
{
    public CreateRoleMatrixCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateRoleMatrixCommandValidator : AbstractValidator<UpdateRoleMatrixCommand>
{
    public UpdateRoleMatrixCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteRoleMatrixCommandValidator : AbstractValidator<DeleteRoleMatrixCommand>
{
    public DeleteRoleMatrixCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}