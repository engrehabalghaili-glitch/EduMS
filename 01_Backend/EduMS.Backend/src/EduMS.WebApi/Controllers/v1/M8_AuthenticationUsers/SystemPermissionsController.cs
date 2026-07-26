using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.SystemPermissions;
using EduMS.Application.M8_AuthenticationUsers.DTOs.SystemPermissions;
using EduMS.Application.M8_AuthenticationUsers.Queries.SystemPermissions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class SystemPermissionsController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<SystemPermissionDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllSystemPermissionsQuery());
        return Ok(ApiResponse<IEnumerable<SystemPermissionDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<SystemPermissionDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetSystemPermissionByIdQuery { Id = id });
        return Ok(ApiResponse<SystemPermissionDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreateSystemPermissionDto dto)
    {
        var id = await sender.Send(new CreateSystemPermissionCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdateSystemPermissionDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdateSystemPermissionCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeleteSystemPermissionCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



