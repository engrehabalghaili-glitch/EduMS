using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.ExamDistributionTimetables;

public class CreateExamDistributionTimetableCommandValidator : AbstractValidator<CreateExamDistributionTimetableCommand>
{
    public CreateExamDistributionTimetableCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateExamDistributionTimetableCommandValidator : AbstractValidator<UpdateExamDistributionTimetableCommand>
{
    public UpdateExamDistributionTimetableCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteExamDistributionTimetableCommandValidator : AbstractValidator<DeleteExamDistributionTimetableCommand>
{
    public DeleteExamDistributionTimetableCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}