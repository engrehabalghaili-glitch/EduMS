using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetAllocations;

public class CreateAssetAllocationCommandValidator : AbstractValidator<CreateAssetAllocationCommand>
{
    public CreateAssetAllocationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetAllocationCommandValidator : AbstractValidator<UpdateAssetAllocationCommand>
{
    public UpdateAssetAllocationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetAllocationCommandValidator : AbstractValidator<DeleteAssetAllocationCommand>
{
    public DeleteAssetAllocationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}