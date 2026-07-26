using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetInspectionLogs;

public class CreateAssetInspectionLogCommandValidator : AbstractValidator<CreateAssetInspectionLogCommand>
{
    public CreateAssetInspectionLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetInspectionLogCommandValidator : AbstractValidator<UpdateAssetInspectionLogCommand>
{
    public UpdateAssetInspectionLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetInspectionLogCommandValidator : AbstractValidator<DeleteAssetInspectionLogCommand>
{
    public DeleteAssetInspectionLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}