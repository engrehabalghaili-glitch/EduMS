using EduMS.Application.M3_EmployeeManagement.DTOs.StaffCustodySummaries;
using MediatR;

namespace EduMS.Application.M3_EmployeeManagement.Commands.StaffCustodySummaries;

public class CreateStaffCustodySummaryCommand : IRequest<long>
{
    public CreateStaffCustodySummaryDto Dto { get; set; } = new();
}

public class UpdateStaffCustodySummaryCommand : IRequest<bool>
{
    public UpdateStaffCustodySummaryDto Dto { get; set; } = new();
}

public class DeleteStaffCustodySummaryCommand : IRequest<bool>
{
    public long Id { get; set; }
}