using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeInventoryCustodies;

public class CreateEmployeeInventoryCustodyCommandValidator : AbstractValidator<CreateEmployeeInventoryCustodyCommand>
{
    public CreateEmployeeInventoryCustodyCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeInventoryCustodyCommandValidator : AbstractValidator<UpdateEmployeeInventoryCustodyCommand>
{
    public UpdateEmployeeInventoryCustodyCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeInventoryCustodyCommandValidator : AbstractValidator<DeleteEmployeeInventoryCustodyCommand>
{
    public DeleteEmployeeInventoryCustodyCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}