using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeCommittees;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeCommittees;

public class GetEmployeeCommitteeByIdQuery : IRequest<EmployeeCommitteeDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeCommitteesQuery : IRequest<IEnumerable<EmployeeCommitteeDto>>
{
}