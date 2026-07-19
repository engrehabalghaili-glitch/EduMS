using EduMS.Application.M4_AssetLogistics.DTOs.FacilityDepartmentAssignments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.FacilityDepartmentAssignments;

public class GetFacilityDepartmentAssignmentByIdQuery : IRequest<FacilityDepartmentAssignmentDto>
{
    public long Id { get; set; }
}

public class GetAllFacilityDepartmentAssignmentsQuery : IRequest<IEnumerable<FacilityDepartmentAssignmentDto>>
{
}