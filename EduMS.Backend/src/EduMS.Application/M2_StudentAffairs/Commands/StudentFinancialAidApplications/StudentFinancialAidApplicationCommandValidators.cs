using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentFinancialAidApplications;

public class CreateStudentFinancialAidApplicationCommandValidator : AbstractValidator<CreateStudentFinancialAidApplicationCommand>
{
    public CreateStudentFinancialAidApplicationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentFinancialAidApplicationCommandValidator : AbstractValidator<UpdateStudentFinancialAidApplicationCommand>
{
    public UpdateStudentFinancialAidApplicationCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentFinancialAidApplicationCommandValidator : AbstractValidator<DeleteStudentFinancialAidApplicationCommand>
{
    public DeleteStudentFinancialAidApplicationCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}