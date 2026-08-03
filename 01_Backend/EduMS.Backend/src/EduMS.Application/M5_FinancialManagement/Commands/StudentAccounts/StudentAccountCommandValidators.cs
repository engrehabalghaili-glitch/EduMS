using FluentValidation;

namespace EduMS.Application.M5_FinancialManagement.Commands.StudentAccounts;

public class CreateStudentAccountCommandValidator : AbstractValidator<CreateStudentAccountCommand>
{
    public CreateStudentAccountCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentAccountCommandValidator : AbstractValidator<UpdateStudentAccountCommand>
{
    public UpdateStudentAccountCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentAccountCommandValidator : AbstractValidator<DeleteStudentAccountCommand>
{
    public DeleteStudentAccountCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}