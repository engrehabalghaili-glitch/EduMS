using EduMS.Application.M8_AuthenticationUsers.DTOs.UserRoleAssignments;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.UserRoleAssignments;

public class GetUserRoleAssignmentByIdQuery : IRequest<UserRoleAssignmentDto>
{
    public long Id { get; set; }
}

public class GetAllUserRoleAssignmentsQuery : IRequest<IEnumerable<UserRoleAssignmentDto>>
{
}