using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.FeeStructures;

public class CreateFeeStructureCommandValidator : AbstractValidator<CreateFeeStructureCommand>
{
    public CreateFeeStructureCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateFeeStructureCommandValidator : AbstractValidator<UpdateFeeStructureCommand>
{
    public UpdateFeeStructureCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteFeeStructureCommandValidator : AbstractValidator<DeleteFeeStructureCommand>
{
    public DeleteFeeStructureCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}