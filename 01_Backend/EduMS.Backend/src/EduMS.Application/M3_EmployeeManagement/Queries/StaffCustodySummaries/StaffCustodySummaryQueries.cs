using EduMS.Application.M3_EmployeeManagement.DTOs.StaffCustodySummaries;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.StaffCustodySummaries;

public class GetStaffCustodySummaryByIdQuery : IRequest<StaffCustodySummaryDto>
{
    public long Id { get; set; }
}

public class GetAllStaffCustodySummariesQuery : IRequest<IEnumerable<StaffCustodySummaryDto>>
{
}