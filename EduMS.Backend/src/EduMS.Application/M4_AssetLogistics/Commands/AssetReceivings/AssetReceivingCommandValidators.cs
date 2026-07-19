using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetReceivings;

public class CreateAssetReceivingCommandValidator : AbstractValidator<CreateAssetReceivingCommand>
{
    public CreateAssetReceivingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetReceivingCommandValidator : AbstractValidator<UpdateAssetReceivingCommand>
{
    public UpdateAssetReceivingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetReceivingCommandValidator : AbstractValidator<DeleteAssetReceivingCommand>
{
    public DeleteAssetReceivingCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}