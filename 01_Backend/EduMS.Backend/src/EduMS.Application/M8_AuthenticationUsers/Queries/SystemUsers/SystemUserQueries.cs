using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemUsers;
using MediatR;
using System.Collections.Generic;

namespace EduMS.Application.M8_AuthenticationUsers.Queries.SystemUsers;

public class GetSystemUserByIdQuery : IRequest<SystemUserDto>
{
    public long Id { get; set; }
}

public class GetAllSystemUsersQuery : IRequest<IEnumerable<SystemUserDto>>
{
}