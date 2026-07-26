using EduMS.Application.M8_AuthenticationUsers.DTOs.RoleMatrixes;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.RoleMatrixes;

public class GetRoleMatrixByIdQuery : IRequest<RoleMatrixDto>
{
    public long Id { get; set; }
}

public class GetAllRoleMatrixesQuery : IRequest<IEnumerable<RoleMatrixDto>>
{
}