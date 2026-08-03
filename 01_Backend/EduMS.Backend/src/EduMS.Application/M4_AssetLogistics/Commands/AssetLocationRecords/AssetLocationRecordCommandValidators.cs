using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetLocationRecords;

public class CreateAssetLocationRecordCommandValidator : AbstractValidator<CreateAssetLocationRecordCommand>
{
    public CreateAssetLocationRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetLocationRecordCommandValidator : AbstractValidator<UpdateAssetLocationRecordCommand>
{
    public UpdateAssetLocationRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetLocationRecordCommandValidator : AbstractValidator<DeleteAssetLocationRecordCommand>
{
    public DeleteAssetLocationRecordCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}