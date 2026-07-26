using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeInternalTransfers;

public class CreateEmployeeInternalTransferCommandValidator : AbstractValidator<CreateEmployeeInternalTransferCommand>
{
    public CreateEmployeeInternalTransferCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeInternalTransferCommandValidator : AbstractValidator<UpdateEmployeeInternalTransferCommand>
{
    public UpdateEmployeeInternalTransferCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeInternalTransferCommandValidator : AbstractValidator<DeleteEmployeeInternalTransferCommand>
{
    public DeleteEmployeeInternalTransferCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}