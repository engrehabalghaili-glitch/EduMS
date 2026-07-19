using FluentValidation;

namespace EduMS.Application.M4_AssetLogistics.Commands.DepreciationTransactions;

public class CreateDepreciationTransactionCommandValidator : AbstractValidator<CreateDepreciationTransactionCommand>
{
    public CreateDepreciationTransactionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateDepreciationTransactionCommandValidator : AbstractValidator<UpdateDepreciationTransactionCommand>
{
    public UpdateDepreciationTransactionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteDepreciationTransactionCommandValidator : AbstractValidator<DeleteDepreciationTransactionCommand>
{
    public DeleteDepreciationTransactionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}