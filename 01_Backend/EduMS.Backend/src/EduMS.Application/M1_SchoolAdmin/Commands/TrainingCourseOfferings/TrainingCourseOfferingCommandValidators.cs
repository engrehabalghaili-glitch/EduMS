using FluentValidation;

namespace EduMS.Application.M1_SchoolAdmin.Commands.TrainingCourseOfferings;

public class CreateTrainingCourseOfferingCommandValidator : AbstractValidator<CreateTrainingCourseOfferingCommand>
{
    public CreateTrainingCourseOfferingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateTrainingCourseOfferingCommandValidator : AbstractValidator<UpdateTrainingCourseOfferingCommand>
{
    public UpdateTrainingCourseOfferingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteTrainingCourseOfferingCommandValidator : AbstractValidator<DeleteTrainingCourseOfferingCommand>
{
    public DeleteTrainingCourseOfferingCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}