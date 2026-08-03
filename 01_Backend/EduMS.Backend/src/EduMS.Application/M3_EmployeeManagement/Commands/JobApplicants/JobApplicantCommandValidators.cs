using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.JobApplicants;

public class CreateJobApplicantCommandValidator : AbstractValidator<CreateJobApplicantCommand>
{
    public CreateJobApplicantCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateJobApplicantCommandValidator : AbstractValidator<UpdateJobApplicantCommand>
{
    public UpdateJobApplicantCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteJobApplicantCommandValidator : AbstractValidator<DeleteJobApplicantCommand>
{
    public DeleteJobApplicantCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}