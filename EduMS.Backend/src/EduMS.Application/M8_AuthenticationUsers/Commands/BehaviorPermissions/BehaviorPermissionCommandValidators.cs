using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.BehaviorPermissions;

public class CreateBehaviorPermissionCommandValidator : AbstractValidator<CreateBehaviorPermissionCommand>
{
    public CreateBehaviorPermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateBehaviorPermissionCommandValidator : AbstractValidator<UpdateBehaviorPermissionCommand>
{
    public UpdateBehaviorPermissionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteBehaviorPermissionCommandValidator : AbstractValidator<DeleteBehaviorPermissionCommand>
{
    public DeleteBehaviorPermissionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}