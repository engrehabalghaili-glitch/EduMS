using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.BehaviorPermissions;
using EduMS.Application.M8_AuthenticationUsers.DTOs.BehaviorPermissions;
using EduMS.Application.M8_AuthenticationUsers.Queries.BehaviorPermissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class BehaviorPermissionsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.BehaviorPermissions.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<BehaviorPermissionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllBehaviorPermissionsQuery());
        return Ok(ApiResponse<IEnumerable<BehaviorPermissionDto>>.Success(result));
    }

    [HasPermission(Permissions.BehaviorPermissions.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<BehaviorPermissionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetBehaviorPermissionByIdQuery { Id = id });
        return Ok(ApiResponse<BehaviorPermissionDto>.Success(result));
    }

    [HasPermission(Permissions.BehaviorPermissions.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateBehaviorPermissionDto dto)
    {
        var id = await sender.Send(new CreateBehaviorPermissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.BehaviorPermissions.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateBehaviorPermissionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateBehaviorPermissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.BehaviorPermissions.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteBehaviorPermissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




