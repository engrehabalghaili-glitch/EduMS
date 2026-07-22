using FluentValidation;

namespace EduMS.Application.M8_AuthenticationUsers.Commands.BehaviorPermissionRecords;

public class CreateBehaviorPermissionRecordCommandValidator : AbstractValidator<CreateBehaviorPermissionRecordCommand>
{
    public CreateBehaviorPermissionRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateBehaviorPermissionRecordCommandValidator : AbstractValidator<UpdateBehaviorPermissionRecordCommand>
{
    public UpdateBehaviorPermissionRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteBehaviorPermissionRecordCommandValidator : AbstractValidator<DeleteBehaviorPermissionRecordCommand>
{
    public DeleteBehaviorPermissionRecordCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}