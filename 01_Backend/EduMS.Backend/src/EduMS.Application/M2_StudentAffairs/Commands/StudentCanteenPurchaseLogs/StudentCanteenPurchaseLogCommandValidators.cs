using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentCanteenPurchaseLogs;

public class CreateStudentCanteenPurchaseLogCommandValidator : AbstractValidator<CreateStudentCanteenPurchaseLogCommand>
{
    public CreateStudentCanteenPurchaseLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentCanteenPurchaseLogCommandValidator : AbstractValidator<UpdateStudentCanteenPurchaseLogCommand>
{
    public UpdateStudentCanteenPurchaseLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentCanteenPurchaseLogCommandValidator : AbstractValidator<DeleteStudentCanteenPurchaseLogCommand>
{
    public DeleteStudentCanteenPurchaseLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}