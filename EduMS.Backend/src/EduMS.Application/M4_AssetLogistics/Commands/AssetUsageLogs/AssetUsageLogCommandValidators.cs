using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetUsageLogs;

public class CreateAssetUsageLogCommandValidator : AbstractValidator<CreateAssetUsageLogCommand>
{
    public CreateAssetUsageLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetUsageLogCommandValidator : AbstractValidator<UpdateAssetUsageLogCommand>
{
    public UpdateAssetUsageLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetUsageLogCommandValidator : AbstractValidator<DeleteAssetUsageLogCommand>
{
    public DeleteAssetUsageLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}