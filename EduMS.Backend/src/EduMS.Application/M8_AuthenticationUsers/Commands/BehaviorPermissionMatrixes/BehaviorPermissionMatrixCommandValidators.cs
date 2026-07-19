using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.BehaviorPermissionMatrixes;

public class CreateBehaviorPermissionMatrixCommandValidator : AbstractValidator<CreateBehaviorPermissionMatrixCommand>
{
    public CreateBehaviorPermissionMatrixCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateBehaviorPermissionMatrixCommandValidator : AbstractValidator<UpdateBehaviorPermissionMatrixCommand>
{
    public UpdateBehaviorPermissionMatrixCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteBehaviorPermissionMatrixCommandValidator : AbstractValidator<DeleteBehaviorPermissionMatrixCommand>
{
    public DeleteBehaviorPermissionMatrixCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}