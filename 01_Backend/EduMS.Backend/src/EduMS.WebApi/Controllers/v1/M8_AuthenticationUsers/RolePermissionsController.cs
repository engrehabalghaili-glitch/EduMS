using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.RolePermissions;
using EduMS.Application.M8_AuthenticationUsers.DTOs.RolePermissions;
using EduMS.Application.M8_AuthenticationUsers.Queries.RolePermissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class RolePermissionsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.RolePermissions.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<RolePermissionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllRolePermissionsQuery());
        return Ok(ApiResponse<IEnumerable<RolePermissionDto>>.Success(result));
    }

    [HasPermission(Permissions.RolePermissions.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<RolePermissionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetRolePermissionByIdQuery { Id = id });
        return Ok(ApiResponse<RolePermissionDto>.Success(result));
    }

    [HasPermission(Permissions.RolePermissions.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateRolePermissionDto dto)
    {
        var id = await sender.Send(new CreateRolePermissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.RolePermissions.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateRolePermissionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateRolePermissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.RolePermissions.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteRolePermissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




