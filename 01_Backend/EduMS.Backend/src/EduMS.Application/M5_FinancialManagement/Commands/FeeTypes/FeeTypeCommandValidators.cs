using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.FeeTypes;

public class CreateFeeTypeCommandValidator : AbstractValidator<CreateFeeTypeCommand>
{
    public CreateFeeTypeCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateFeeTypeCommandValidator : AbstractValidator<UpdateFeeTypeCommand>
{
    public UpdateFeeTypeCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteFeeTypeCommandValidator : AbstractValidator<DeleteFeeTypeCommand>
{
    public DeleteFeeTypeCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}