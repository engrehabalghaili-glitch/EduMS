using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeCommittees;

public class CreateEmployeeCommitteeCommandValidator : AbstractValidator<CreateEmployeeCommitteeCommand>
{
    public CreateEmployeeCommitteeCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeCommitteeCommandValidator : AbstractValidator<UpdateEmployeeCommitteeCommand>
{
    public UpdateEmployeeCommitteeCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeCommitteeCommandValidator : AbstractValidator<DeleteEmployeeCommitteeCommand>
{
    public DeleteEmployeeCommitteeCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}