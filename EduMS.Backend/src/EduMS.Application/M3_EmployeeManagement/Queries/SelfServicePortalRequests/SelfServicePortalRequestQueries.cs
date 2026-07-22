using EduMS.Application.M3_EmployeeManagement.DTOs.SelfServicePortalRequests;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.SelfServicePortalRequests;

public class GetSelfServicePortalRequestByIdQuery : IRequest<SelfServicePortalRequestDto>
{
    public long Id { get; set; }
}

public class GetAllSelfServicePortalRequestsQuery : IRequest<IEnumerable<SelfServicePortalRequestDto>>
{
}