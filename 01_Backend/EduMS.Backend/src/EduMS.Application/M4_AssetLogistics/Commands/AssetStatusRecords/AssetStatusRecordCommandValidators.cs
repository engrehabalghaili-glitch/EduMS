using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetStatusRecords;

public class CreateAssetStatusRecordCommandValidator : AbstractValidator<CreateAssetStatusRecordCommand>
{
    public CreateAssetStatusRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetStatusRecordCommandValidator : AbstractValidator<UpdateAssetStatusRecordCommand>
{
    public UpdateAssetStatusRecordCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetStatusRecordCommandValidator : AbstractValidator<DeleteAssetStatusRecordCommand>
{
    public DeleteAssetStatusRecordCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}