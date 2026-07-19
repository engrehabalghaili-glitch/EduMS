using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetTransferRequests;

public class CreateAssetTransferRequestCommandValidator : AbstractValidator<CreateAssetTransferRequestCommand>
{
    public CreateAssetTransferRequestCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetTransferRequestCommandValidator : AbstractValidator<UpdateAssetTransferRequestCommand>
{
    public UpdateAssetTransferRequestCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetTransferRequestCommandValidator : AbstractValidator<DeleteAssetTransferRequestCommand>
{
    public DeleteAssetTransferRequestCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}