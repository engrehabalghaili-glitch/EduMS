using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeLeaves;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeLeaves;

public class GetEmployeeLeaveByIdQuery : IRequest<EmployeeLeaveDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeLeavesQuery : IRequest<IEnumerable<EmployeeLeaveDto>>
{
}