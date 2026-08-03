using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.UserRoleAssignments;
using EduMS.Application.M8_AuthenticationUsers.DTOs.UserRoleAssignments;
using EduMS.Application.M8_AuthenticationUsers.Queries.UserRoleAssignments;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Domain.Constants;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class UserRoleAssignmentsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    [HasPermission(Permissions.UserRoleAssignments.View)]
    public async Task<ActionResult<ApiResponse<IEnumerable<UserRoleAssignmentDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllUserRoleAssignmentsQuery());
        return Ok(ApiResponse<IEnumerable<UserRoleAssignmentDto>>.Success(result));
    }

    [HttpGet("{id}")]
    [HasPermission(Permissions.UserRoleAssignments.View)]
    public async Task<ActionResult<ApiResponse<UserRoleAssignmentDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetUserRoleAssignmentByIdQuery { Id = id });
        return Ok(ApiResponse<UserRoleAssignmentDto>.Success(result));
    }

    [HttpPost]
    [HasPermission(Permissions.UserRoleAssignments.Assign)]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateUserRoleAssignmentDto dto)
    {
        var id = await sender.Send(new CreateUserRoleAssignmentCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    [HasPermission(Permissions.UserRoleAssignments.Assign)]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateUserRoleAssignmentDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateUserRoleAssignmentCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    [HasPermission(Permissions.UserRoleAssignments.Revoke)]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteUserRoleAssignmentCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



