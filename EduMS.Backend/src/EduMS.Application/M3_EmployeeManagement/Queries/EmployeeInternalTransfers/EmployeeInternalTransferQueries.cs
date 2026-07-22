using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeInternalTransfers;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeInternalTransfers;

public class GetEmployeeInternalTransferByIdQuery : IRequest<EmployeeInternalTransferDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeInternalTransfersQuery : IRequest<IEnumerable<EmployeeInternalTransferDto>>
{
}