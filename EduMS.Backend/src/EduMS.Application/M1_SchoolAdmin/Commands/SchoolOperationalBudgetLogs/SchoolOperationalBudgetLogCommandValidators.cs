using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.SchoolOperationalBudgetLogs;

public class CreateSchoolOperationalBudgetLogCommandValidator : AbstractValidator<CreateSchoolOperationalBudgetLogCommand>
{
    public CreateSchoolOperationalBudgetLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateSchoolOperationalBudgetLogCommandValidator : AbstractValidator<UpdateSchoolOperationalBudgetLogCommand>
{
    public UpdateSchoolOperationalBudgetLogCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteSchoolOperationalBudgetLogCommandValidator : AbstractValidator<DeleteSchoolOperationalBudgetLogCommand>
{
    public DeleteSchoolOperationalBudgetLogCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}