using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeePerformanceReviews;

public class CreateEmployeePerformanceReviewCommandValidator : AbstractValidator<CreateEmployeePerformanceReviewCommand>
{
    public CreateEmployeePerformanceReviewCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeePerformanceReviewCommandValidator : AbstractValidator<UpdateEmployeePerformanceReviewCommand>
{
    public UpdateEmployeePerformanceReviewCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeePerformanceReviewCommandValidator : AbstractValidator<DeleteEmployeePerformanceReviewCommand>
{
    public DeleteEmployeePerformanceReviewCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}