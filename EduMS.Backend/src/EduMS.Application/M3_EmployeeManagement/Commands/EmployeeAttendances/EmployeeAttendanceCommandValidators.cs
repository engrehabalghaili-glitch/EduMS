using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeAttendances;

public class CreateEmployeeAttendanceCommandValidator : AbstractValidator<CreateEmployeeAttendanceCommand>
{
    public CreateEmployeeAttendanceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeAttendanceCommandValidator : AbstractValidator<UpdateEmployeeAttendanceCommand>
{
    public UpdateEmployeeAttendanceCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeAttendanceCommandValidator : AbstractValidator<DeleteEmployeeAttendanceCommand>
{
    public DeleteEmployeeAttendanceCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}