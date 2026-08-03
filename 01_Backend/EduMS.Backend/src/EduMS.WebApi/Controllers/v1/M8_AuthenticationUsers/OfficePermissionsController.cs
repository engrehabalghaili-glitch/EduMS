using EduMS.Domain.Constants;
using EduMS.Infrastructure.Security.Authorization;
using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.OfficePermissions;
using EduMS.Application.M8_AuthenticationUsers.DTOs.OfficePermissions;
using EduMS.Application.M8_AuthenticationUsers.Queries.OfficePermissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class OfficePermissionsController(MediatR.ISender sender) : ControllerBase
{

    [HasPermission(Permissions.OfficePermissions.View)]
    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<OfficePermissionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllOfficePermissionsQuery());
        return Ok(ApiResponse<IEnumerable<OfficePermissionDto>>.Success(result));
    }

    [HasPermission(Permissions.OfficePermissions.View)]
    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<OfficePermissionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetOfficePermissionByIdQuery { Id = id });
        return Ok(ApiResponse<OfficePermissionDto>.Success(result));
    }

    [HasPermission(Permissions.OfficePermissions.Create)]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateOfficePermissionDto dto)
    {
        var id = await sender.Send(new CreateOfficePermissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HasPermission(Permissions.OfficePermissions.Update)]
    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateOfficePermissionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateOfficePermissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HasPermission(Permissions.OfficePermissions.Delete)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteOfficePermissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}




