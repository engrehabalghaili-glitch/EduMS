using EduMS.Application.M4_AssetLogistics.DTOs.AssetAssignments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M4_AssetLogistics.Queries.AssetAssignments;

public class GetAssetAssignmentByIdQuery : IRequest<AssetAssignmentDto>
{
    public long Id { get; set; }
}

public class GetAllAssetAssignmentsQuery : IRequest<IEnumerable<AssetAssignmentDto>>
{
}