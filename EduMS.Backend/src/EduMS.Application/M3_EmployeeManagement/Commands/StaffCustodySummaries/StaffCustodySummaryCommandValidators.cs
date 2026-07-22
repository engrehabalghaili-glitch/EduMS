using FluentValidation;

namespace EduMS.Application.M3_EmployeeManagement.Commands.StaffCustodySummaries;

public class CreateStaffCustodySummaryCommandValidator : AbstractValidator<CreateStaffCustodySummaryCommand>
{
    public CreateStaffCustodySummaryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
    }
}

public class UpdateStaffCustodySummaryCommandValidator : AbstractValidator<UpdateStaffCustodySummaryCommand>
{
    public UpdateStaffCustodySummaryCommandValidator()
    {
        RuleFor(x => x.Dto).NotNull();
        RuleFor(x => x.Dto.Id).GreaterThan(0);
    }
}

public class DeleteStaffCustodySummaryCommandValidator : AbstractValidator<DeleteStaffCustodySummaryCommand>
{
    public DeleteStaffCustodySummaryCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}