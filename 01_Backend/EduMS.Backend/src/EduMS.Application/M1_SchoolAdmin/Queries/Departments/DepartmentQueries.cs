using EduMS.Application.M1_SchoolAdmin.DTOs.Departments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.Departments;

public class GetDepartmentByIdQuery : IRequest<DepartmentDto>
{
    public long Id { get; set; }
}

public class GetAllDepartmentsQuery : IRequest<IEnumerable<DepartmentDto>>
{
}