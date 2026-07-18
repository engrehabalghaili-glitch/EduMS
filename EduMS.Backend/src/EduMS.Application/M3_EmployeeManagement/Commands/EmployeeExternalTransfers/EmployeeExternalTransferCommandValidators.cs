using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.EmployeeExternalTransfers;

public class CreateEmployeeExternalTransferCommandValidator : AbstractValidator<CreateEmployeeExternalTransferCommand>
{
    public CreateEmployeeExternalTransferCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateEmployeeExternalTransferCommandValidator : AbstractValidator<UpdateEmployeeExternalTransferCommand>
{
    public UpdateEmployeeExternalTransferCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteEmployeeExternalTransferCommandValidator : AbstractValidator<DeleteEmployeeExternalTransferCommand>
{
    public DeleteEmployeeExternalTransferCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}