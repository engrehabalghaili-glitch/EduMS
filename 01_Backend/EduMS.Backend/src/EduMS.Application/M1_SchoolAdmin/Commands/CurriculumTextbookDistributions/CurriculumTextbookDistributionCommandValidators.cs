using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.CurriculumTextbookDistributions;

public class CreateCurriculumTextbookDistributionCommandValidator : AbstractValidator<CreateCurriculumTextbookDistributionCommand>
{
    public CreateCurriculumTextbookDistributionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateCurriculumTextbookDistributionCommandValidator : AbstractValidator<UpdateCurriculumTextbookDistributionCommand>
{
    public UpdateCurriculumTextbookDistributionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteCurriculumTextbookDistributionCommandValidator : AbstractValidator<DeleteCurriculumTextbookDistributionCommand>
{
    public DeleteCurriculumTextbookDistributionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}