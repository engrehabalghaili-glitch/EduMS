using EduMS.Application.M3_EmployeeManagement.DTOs.EmployeeAdditionalTasks;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M3_EmployeeManagement.Queries.EmployeeAdditionalTasks;

public class GetEmployeeAdditionalTaskByIdQuery : IRequest<EmployeeAdditionalTaskDto>
{
    public long Id { get; set; }
}

public class GetAllEmployeeAdditionalTasksQuery : IRequest<IEnumerable<EmployeeAdditionalTaskDto>>
{
}