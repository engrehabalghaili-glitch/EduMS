using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeInventoryCustodies;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeInventoryCustodies;

public class GetEmployeeInventoryCustodyByIdQuery : IRequest<EmployeeInventoryCustodyDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeInventoryCustodiesQuery : IRequest<IEnumerable<EmployeeInventoryCustodyDto>>
{
}