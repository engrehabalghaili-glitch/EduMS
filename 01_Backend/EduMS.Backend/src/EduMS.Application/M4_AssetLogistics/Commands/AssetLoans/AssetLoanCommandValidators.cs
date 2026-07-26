using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.AssetLoans;

public class CreateAssetLoanCommandValidator : AbstractValidator<CreateAssetLoanCommand>
{
    public CreateAssetLoanCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateAssetLoanCommandValidator : AbstractValidator<UpdateAssetLoanCommand>
{
    public UpdateAssetLoanCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteAssetLoanCommandValidator : AbstractValidator<DeleteAssetLoanCommand>
{
    public DeleteAssetLoanCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}