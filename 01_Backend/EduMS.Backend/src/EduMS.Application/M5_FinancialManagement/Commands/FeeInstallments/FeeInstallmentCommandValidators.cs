using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.FeeInstallments;

public class CreateFeeInstallmentCommandValidator : AbstractValidator<CreateFeeInstallmentCommand>
{
    public CreateFeeInstallmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateFeeInstallmentCommandValidator : AbstractValidator<UpdateFeeInstallmentCommand>
{
    public UpdateFeeInstallmentCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteFeeInstallmentCommandValidator : AbstractValidator<DeleteFeeInstallmentCommand>
{
    public DeleteFeeInstallmentCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}