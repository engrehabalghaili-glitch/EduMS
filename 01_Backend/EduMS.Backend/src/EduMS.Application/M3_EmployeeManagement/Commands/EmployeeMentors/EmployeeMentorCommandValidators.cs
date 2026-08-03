using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeMentors;

public class CreateEmployeeMentorCommandValidator : AbstractValidator<CreateEmployeeMentorCommand>
{
    public CreateEmployeeMentorCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeMentorCommandValidator : AbstractValidator<UpdateEmployeeMentorCommand>
{
    public UpdateEmployeeMentorCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeMentorCommandValidator : AbstractValidator<DeleteEmployeeMentorCommand>
{
    public DeleteEmployeeMentorCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}