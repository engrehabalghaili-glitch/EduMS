using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.UserRoleAssignments;

public class CreateUserRoleAssignmentCommandValidator : AbstractValidator<CreateUserRoleAssignmentCommand>
{
    public CreateUserRoleAssignmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateUserRoleAssignmentCommandValidator : AbstractValidator<UpdateUserRoleAssignmentCommand>
{
    public UpdateUserRoleAssignmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteUserRoleAssignmentCommandValidator : AbstractValidator<DeleteUserRoleAssignmentCommand>
{
    public DeleteUserRoleAssignmentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}