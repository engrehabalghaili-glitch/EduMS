using FluentValidation;

namespace EduMS.Application.M2_StudentAffairs.Commands.StudentTransportationSubscriptions;

public class CreateStudentTransportationSubscriptionCommandValidator : AbstractValidator<CreateStudentTransportationSubscriptionCommand>
{
    public CreateStudentTransportationSubscriptionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStudentTransportationSubscriptionCommandValidator : AbstractValidator<UpdateStudentTransportationSubscriptionCommand>
{
    public UpdateStudentTransportationSubscriptionCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStudentTransportationSubscriptionCommandValidator : AbstractValidator<DeleteStudentTransportationSubscriptionCommand>
{
    public DeleteStudentTransportationSubscriptionCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}