using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissionMatrixes;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.BehaviorPermissionMatrixes;

public class GetBehaviorPermissionMatrixByIdQuery : IRequest<BehaviorPermissionMatrixDto>
{
    public long Id { get; set; }
}

public class GetAllBehaviorPermissionMatrixesQuery : IRequest<IEnumerable<BehaviorPermissionMatrixDto>>
{
}