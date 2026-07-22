using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeTerminations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeTerminations;

public class GetEmployeeTerminationByIdQuery : IRequest<EmployeeTerminationDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeTerminationsQuery : IRequest<IEnumerable<EmployeeTerminationDto>>
{
}