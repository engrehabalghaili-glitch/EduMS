using EduMS.Application.M1_SchoolAdmin.DTOs.ClassroomResourceAllocations;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M1_SchoolAdmin.Queries.ClassroomResourceAllocations;

public class GetClassroomResourceAllocationByIdQuery : IRequest<ClassroomResourceAllocationDto>
{
    public long Id { get; set; }
}

public class GetAllClassroomResourceAllocationsQuery : IRequest<IEnumerable<ClassroomResourceAllocationDto>>
{
}