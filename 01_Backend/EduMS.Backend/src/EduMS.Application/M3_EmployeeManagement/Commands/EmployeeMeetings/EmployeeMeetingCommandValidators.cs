using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeMeetings;

public class CreateEmployeeMeetingCommandValidator : AbstractValidator<CreateEmployeeMeetingCommand>
{
    public CreateEmployeeMeetingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeMeetingCommandValidator : AbstractValidator<UpdateEmployeeMeetingCommand>
{
    public UpdateEmployeeMeetingCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeMeetingCommandValidator : AbstractValidator<DeleteEmployeeMeetingCommand>
{
    public DeleteEmployeeMeetingCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}