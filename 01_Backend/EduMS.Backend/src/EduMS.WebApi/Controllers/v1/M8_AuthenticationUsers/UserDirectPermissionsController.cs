using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.UserDirectPermissions;
using EduMS.Application.M8_AuthenticationUsers.DTOs.UserDirectPermissions;
using EduMS.Application.M8_AuthenticationUsers.Queries.UserDirectPermissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class UserDirectPermissionsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<UserDirectPermissionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllUserDirectPermissionsQuery());
        return Ok(ApiResponse<IEnumerable<UserDirectPermissionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<UserDirectPermissionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetUserDirectPermissionByIdQuery { Id = id });
        return Ok(ApiResponse<UserDirectPermissionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateUserDirectPermissionDto dto)
    {
        var id = await sender.Send(new CreateUserDirectPermissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateUserDirectPermissionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateUserDirectPermissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteUserDirectPermissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



