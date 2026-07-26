using EduMS.Application.Common.Responses;
using EduMS.Application.M8_AuthenticationUsers.Commands.PermissionBaseModules;
using EduMS.Application.M8_AuthenticationUsers.DTOs.PermissionBaseModules;
using EduMS.Application.M8_AuthenticationUsers.Queries.PermissionBaseModules;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduMS.WebApi.Controllers.v1.M8_AuthenticationUsers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class PermissionBaseModulesController(MediatR.ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ApiResponse<IEnumerable<PermissionBaseModuleDto>>>> GetAll()
    {
        var result = await sender.Send(new GetAllPermissionBaseModulesQuery());
        return Ok(ApiResponse<IEnumerable<PermissionBaseModuleDto>>.Success(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<PermissionBaseModuleDto>>> GetById(long id)
    {
        var result = await sender.Send(new GetPermissionBaseModuleByIdQuery { Id = id });
        return Ok(ApiResponse<PermissionBaseModuleDto>.Success(result));
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<long>>> Create([FromBody] CreatePermissionBaseModuleDto dto)
    {
        var id = await sender.Send(new CreatePermissionBaseModuleCommand { Dto = dto });
        return Ok(ApiResponse<long>.Success(id, "Created successfully."));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Update(long id, [FromBody] UpdatePermissionBaseModuleDto dto)
    {
        dto.Id = id;
        var result = await sender.Send(new UpdatePermissionBaseModuleCommand { Dto = dto });
        return Ok(ApiResponse<bool>.Success(result, "Updated successfully."));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ApiResponse<bool>>> Delete(long id)
    {
        var result = await sender.Send(new DeletePermissionBaseModuleCommand { Id = id });
        return Ok(ApiResponse<bool>.Success(result, "Deleted successfully."));
    }
}



