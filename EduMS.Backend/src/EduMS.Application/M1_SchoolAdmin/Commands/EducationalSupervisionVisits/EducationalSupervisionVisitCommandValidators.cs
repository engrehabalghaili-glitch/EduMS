using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.EducationalSupervisionVisits;

public class CreateEducationalSupervisionVisitCommandValidator : AbstractValidator<CreateEducationalSupervisionVisitCommand>
{
    public CreateEducationalSupervisionVisitCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEducationalSupervisionVisitCommandValidator : AbstractValidator<UpdateEducationalSupervisionVisitCommand>
{
    public UpdateEducationalSupervisionVisitCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEducationalSupervisionVisitCommandValidator : AbstractValidator<DeleteEducationalSupervisionVisitCommand>
{
    public DeleteEducationalSupervisionVisitCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}