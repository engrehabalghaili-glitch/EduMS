using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetWarrantyContracts;

public class CreateAssetWarrantyContractCommandValidator : AbstractValidator<CreateAssetWarrantyContractCommand>
{
    public CreateAssetWarrantyContractCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetWarrantyContractCommandValidator : AbstractValidator<UpdateAssetWarrantyContractCommand>
{
    public UpdateAssetWarrantyContractCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetWarrantyContractCommandValidator : AbstractValidator<DeleteAssetWarrantyContractCommand>
{
    public DeleteAssetWarrantyContractCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}