using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeExternalTransfers;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeExternalTransfers;

public class GetEmployeeExternalTransferByIdQuery : IRequest<EmployeeExternalTransferDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeExternalTransfersQuery : IRequest<IEnumerable<EmployeeExternalTransferDto>>
{
}